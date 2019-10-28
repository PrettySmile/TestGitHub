let soundList = [
    {
        name: "汪蘇瀧-有點甜"
        , file: "汪蘇瀧-有點甜"
    }
    , {
        name: "鄧紫棋-光年之外"
        , file: "鄧紫棋-光年之外"
    }
    , {
        name: "方大同-Nothings Gonna Change My Love For You"
        , file: "方大同-NothingsGonnaChangeMyLoveForYou"
    }
];
let soundListIndex = 0;
let isPlay = false;
let isOnceLoop = false;
let isTotalLoop = false;
let isRandom = false;

let audio = document.getElementById("audio");
let controlPanel = document.getElementById("controlPanel");
let btnSoundList = document.getElementById("btnSoundList");
let btnOnceLoop = document.getElementById("btnOnceLoop");
let btnTotalLoop = document.getElementById("btnTotalLoop");
let btnRandom = document.getElementById("btnRandom");
let btnSoundProgressBar = document.getElementById("btnSoundProgressBar");
let btnVolumeRange = document.getElementById("btnVolumeRange");

let sBook = document.getElementById("sBook");
let tBook = document.getElementById("tBook");
let btnUpdateBook = document.getElementById("btnUpdateBook");
let book = document.getElementById("book");

window.onload = function () {
    initEventListener();
    initBtnSoundList();
    initVolumeInfo();
    initBook();
    showMsgInfo();
    showMsgLoopStatus();
    showBook(false);
    resetPlayer();
};

function resetPlayer() {
    soundListIndex = 0;
    stopMusic();
    showMsgInfo();
    setBtnPlayPauseState();
    showMsgNowDuration();
    updateSoundProgress();
    setMusic(soundListIndex);
}

function initEventListener() {
    controlPanel.addEventListener("click", onControlPanelClick);
    audio.addEventListener("canplay", onSoundCanPlay);
    audio.addEventListener("play", onSoundPlay);
    audio.addEventListener('ended', onPlayEndedHandler);
    btnSoundList.addEventListener("change", onBtnSoundList);
    if (isIE()) {
        btnSoundProgressBar.addEventListener("change", onBtnSoundProgressBar);    
        btnVolumeRange.addEventListener("change", onBtnVolumeRange);        
    } else {
        btnSoundProgressBar.addEventListener("input", onBtnSoundProgressBar);    
        btnVolumeRange.addEventListener("input", onBtnVolumeRange);        
    }
    sBook.addEventListener("drop", function (e) { onDrop(this, e) });
    sBook.addEventListener("dragover", onDragover);
    tBook.addEventListener("drop", function (e) { onDrop(this, e) });
    tBook.addEventListener("dragover", onDragover);
    btnUpdateBook.addEventListener("click", onUpdateSoundList);
}

function initBtnSoundList() {
    for (let i = btnSoundList.options.length - 1; i >= 0; i--) {
        btnSoundList.remove(i);
    }

    for (let i = 0; i < soundList.length; i++) {
        let option = new Option(soundList[i]["name"]/*text*/, i/*value*/);
        btnSoundList.options.add(option);
    }
}

function initVolumeInfo() {
    setBtnVolumeRangeValue(100);
    showVolume(100);
}

function initBook() {
    for (let i = 0; i < soundList.length; i++) {
        let div = document.createElement("div");        
        div.innerText = soundList[i]["name"].replace("-", "\n");
        div.name = soundList[i]["name"];
        div.file = soundList[i]["file"];
        div.draggable = true;
        div.id = i;
        tBook.appendChild(div);
        div.addEventListener("dragstart", onDragstart);
        div.style.backgroundColor = getRandomColor();
    }
}

//Util------------------
function getRandomOtherSound(disNum) {
    if (soundList.length == 1) return 0;
    let arr = [];
    for (let i = 0; i < soundList.length; i++) {
        if (i != disNum) arr.push(i);
    }
    let randomIndex = Math.floor(Math.random() * arr.length);    
    return arr[randomIndex];
}

function getSecTurnMinSecTime(totalSec) {
    if (isNaN(totalSec)) return "00:00";
    let min = Math.floor(totalSec / 60);
    let sec = Math.floor(totalSec % 60);
    if (min < 10) min = "0" + min;
    if (sec < 10) sec = "0" + sec;
    return min + ":" + sec;
}

function isIE() {
    if (navigator.userAgent.search("Chrome") != -1
        || navigator.userAgent.search("Firefox") != -1
        || navigator.userAgent.search("Opera") != -1) {
        return false;
    } else {
        return true;
    }
}

function getRandomColor() {
    let color = "#";
    for (let i = 0; i < 6; i++) {
        color += turnNumberToHexStr(getRandomNumber(11, 14) + "");
    }
    return color;
}

function getRandomNumber(min, max) {
    return Math.floor((Math.random() * (max - min + 1))) + min;
}

function turnNumberToHexStr(a) {
    let sixteen = "";
    switch (a) {
        case "10":
            sixteen = "a";
            break;
        case "11":
            sixteen = "b";
            break;
        case "12":
            sixteen = "c";
            break;
        case "13":
            sixteen = "d";
            break;
        case "14":
            sixteen = "e";
            break;
        case "15":
            sixteen = "f";
            break;
        default:
            sixteen = a;
            break;
    }
    return sixteen;
}

//------------------
function onDragstart(e) {
    e.dataTransfer.setData("dragItemId", e.target.id);
}

function onDragover(e) {
    e.preventDefault();
}

function onDrop(whichBook, e) {
    e.preventDefault();
    let divId = e.dataTransfer.getData("dragItemId");
    whichBook.appendChild(document.getElementById(divId));
}

function onControlPanelClick(e) {
    let btn = e.target;
    switch (btn.id) {
        case "btnPlay":
            if (playMusic()) showMsgInfo("現正播放 : " + soundList[soundListIndex]["name"]);                
            setBtnPlayPauseState();
            break;
        case "btnPause":
            pauseMusic();
            showMsgInfo();
            setBtnPlayPauseState();
            break;
        case "btnStop":
            stopMusic();
            showMsgInfo();
            setBtnPlayPauseState();
            showMsgNowDuration();
            updateSoundProgress();
            break;
        case "btnPreSound":
            preMusic();
            break;
        case "btnNextSound":
            nextMusic();
            break;
        case "btnPreTime":
            preTimeMusic();
            updateSoundProgress();
            break;
        case "btnNextTime":
            nextTimeMusic();
            updateSoundProgress();
            break;
        case "btnMute":
            muteMusic();
            break;
        case "btnOnceLoop":
            setSoundMode(!isOnceLoop, false, false);
            break;
        case "btnTotalLoop":
            setSoundMode(false, !isTotalLoop, false);
            break;
        case "btnRandom":
            setSoundMode(false, false, !isRandom);
            break;
        case "btnVolumeAdd":
            changeVolume(true);
            break;
        case "btnVolumeSub":
            changeVolume(false);
            break;
        case "btnBook":
            book["isOpen"] = !book["isOpen"];
            showBook(book["isOpen"]);
            setButtonStatus(btn, book["isOpen"]);
            break;
    }
}

function onSoundCanPlay() {
    if(!checkSoundList()) return;
    if (isPlay && playMusic()) showMsgInfo("現正播放 : " + soundList[soundListIndex]["name"]);            
    setBtnPlayPauseState();
    showMsgTotalDuration();
    updateSoundProgress();
}

function onSoundPlay() {
    loopUpdate();
}

function loopUpdate() {
    setTimeout(function () {
        if (isPlay) {
            showMsgNowDuration();
            updateSoundProgress();
            loopUpdate();
        }
    }, 100);
}

function onPlayEndedHandler() {
    if (isOnceLoop) {
        stopMusic();
        showMsgInfo();
        if (playMusic()) showMsgInfo("現正播放 : " + soundList[soundListIndex]["name"]);
        setBtnPlayPauseState();
        showMsgNowDuration();
        updateSoundProgress();
    } else if (isTotalLoop) {
        nextMusic();
    } else if (isRandom) {
        soundListIndex = getRandomOtherSound(soundListIndex);
        setMusic(soundListIndex);
    } else {
        stopMusic();
        showMsgInfo();
        setBtnPlayPauseState();
        showMsgNowDuration();
        updateSoundProgress();
    }
}

function onBtnSoundList(e) {
    soundListIndex = e.target.value;
    setMusic(soundListIndex);
}

function onBtnSoundProgressBar(e) {
    audio.currentTime = btnSoundProgressBar.value;
    showMsgNowDuration();
    updateSoundProgress();
}

function onBtnVolumeRange() {
    let volumePercent = btnVolumeRange.value;
    audio.volume = volumePercent / 100;
    setBtnVolumeRangeValue(volumePercent);
    showVolume(volumePercent);
}

function onUpdateSoundList() {
    soundList.length = 0;
    soundList = [];
    for (let i = 0; i < tBook.children.length; i++) {
        let obj = {};
        obj.name = tBook.children[i].name;
        obj.file = tBook.children[i].file;
        soundList.push(obj);
    }
    initBtnSoundList();
    resetPlayer();
}

//-----------------------------------------------
function setBtnPlayPauseState() {
    let btnPlay = document.getElementById("btnPlay");
    let btnPause = document.getElementById("btnPause");
    if (isPlay) {
        btnPlay.className = "hideDisplay";
        btnPause.className = "";
    } else {
        btnPlay.className = "";
        btnPause.className = "hideDisplay";
    }
}

function setMusic(index) {
    showMsgNowDuration("00:00");
    if (!checkSoundList()) return;
    btnSoundList.selectedIndex = index;
    audio.type = "audio/mp3";
    audio.src = "sound/" + soundList[index]["file"] + ".mp3";
    audio.load();
    updateSoundProgress();
}

function playMusic() {
    if (!checkSoundList()) return false;
    isPlay = true;
    audio.play();
    return true;
}

function pauseMusic() {
    isPlay = false;
    audio.pause();
}

function stopMusic() {
    pauseMusic();
    audio.currentTime = 0;    
}

function preMusic() {
    soundListIndex--;
    if (soundListIndex < 0) {
        soundListIndex = soundList.length - 1;
    }
    setMusic(soundListIndex);
}

function nextMusic() {
    soundListIndex++;
    if (soundListIndex >= soundList.length) {
        soundListIndex = 0;
    }
    setMusic(soundListIndex);
}

function preTimeMusic() {
    audio.currentTime -= 10;
    if (audio.currentTime <= 0) audio.currentTime = 0;    
}

function nextTimeMusic() {
    audio.currentTime += 10;
    if (audio.currentTime >= audio.duration) audio.currentTime = audio.duration;    
}

function muteMusic() {
    let btnMute = document.getElementById("btnMute");
    audio.muted = !audio.muted;
    if (audio.muted) {
        btnMute.innerText = "V";
    } else {
        btnMute.innerText = "U";
    }
}

function setSoundMode(onceLoop, totalLoop, random) {
    isOnceLoop = onceLoop;
    isTotalLoop = totalLoop;
    isRandom = random;
    setButtonStatus(btnOnceLoop, isOnceLoop);
    setButtonStatus(btnTotalLoop, isTotalLoop);
    setButtonStatus(btnRandom, isRandom);
    showMsgLoopStatus();
}

function setButtonStatus(btn, isShow) {
    if (isShow) {
        btn.className = "show";
    } else {
        btn.className = "hide";
    }
}

function changeVolume(isAdd) {
    let volumePercent = audio.volume * 100;
    if (isAdd) {
        volumePercent += 1;
    } else {
        volumePercent -= 1;
    }
    if (volumePercent >= 100) volumePercent = 100;
    if (volumePercent <= 0) volumePercent = 0;
    audio.volume = volumePercent / 100;
    setBtnVolumeRangeValue(volumePercent);
    showVolume(volumePercent);
}

function checkSoundList() {
    if (soundList.length == 0) {
        showMsgTotalDuration("00:00");
        showMsgInfo("請添加歌曲至歌本~");
        return false;
    }
    return true;
}

//show---------------------------------------------------------------------
function updateSoundProgress() {    
    if (isNaN(audio.currentTime) || isNaN(audio.duration)) {
        btnSoundProgressBar.max = 1;
        btnSoundProgressBar.value = 0;
    } else {
        btnSoundProgressBar.max = audio.duration;
        btnSoundProgressBar.value = audio.currentTime;
        let w = (audio.currentTime / audio.duration * 100);
        if (w <= 50) w++;
        btnSoundProgressBar.style.backgroundImage = "-webkit-linear-gradient(left,#a17272,#a17272 " + w +"%,#3c0404 "+w+"%,#3c0404)";        
    }
}

function setBtnVolumeRangeValue(value) {
    btnVolumeRange.value = Math.floor(value);
}

function showVolume(value) {
    let txtVolume = document.getElementById("txtVolume");
    txtVolume.value = Math.floor(value);
}

function showMsgInfo(msg) {
    let msgInfo = document.getElementById("msgInfo");
    let status = "";
    if (msg) {
        status = msg;
    } else {
        status = "請點擊播放鈕~";
    }
    msgInfo.innerText = status;
}

function showMsgLoopStatus() {
    let msgLoopStatus = document.getElementById("msgLoopStatus");
    let status = "";
    if (isOnceLoop) {
        status = "單曲循環";
    } else if (isTotalLoop) {
        status = "全部循環";
    } else if (isRandom) {
        status = "隨機播放";
    } else {
        status = "單歌播放";
    }
    msgLoopStatus.innerText = status;
}

function showMsgTotalDuration(msg) {
    let msgTotalDuration = document.getElementById("msgTotalDuration");
    let text = "";
    if (msg) {
        text = msg;
    } else {
        text = getSecTurnMinSecTime(audio.duration);
    }
    msgTotalDuration.innerText = text;
}

function showMsgNowDuration(msg) {
    let msgNowDuration = document.getElementById("msgNowDuration");
    let text = "";
    if (msg) {
        text = msg;
    } else {
        text = getSecTurnMinSecTime(audio.currentTime);
    }
    msgNowDuration.innerText = text;
}

function showBook(isShow) {
    if (isShow) {
        book.className = "";
    } else {
        book.className = "hideDisplay";
    }
}