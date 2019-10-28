import requests
from bs4 import BeautifulSoup

# Google 搜尋 URL
google_url = 'https://www.google.com/search'

# 查詢參數
my_params = {'q':'寒流'}

# 下載Google搜尋結果
r = requests.get(google_url, params=my_params)

# 確認是否下載成功
if r.status_code == requests.codes.ok:
    # 以BeautifulSoup解析HTML原始碼
    soup = BeautifulSoup(r.text,'html.parser')
    # 觀察HTML原始碼，prettify為美化工能
    print(soup.prettify())

    print('-----------------------------')
    # 以CSS的選擇器來抓取Google的搜尋結果
    # (它可以抓出 class 為 g 的 <div>，底下緊接著 class 為 r 的 <h3>，底下又接著網址為 /url 開頭的超連結。)
    #items = soup.select('div.g > h3.r > a[href^="/url"]')
    items = soup.select('div.kCrYT > a[href^="/url"]')
    list=[]
    for i in items:
        #print(i.text)
        urlStr = i.get("href")
        urlStr = urlStr[urlStr.find("http"):]
        urlStr = urlStr[:urlStr.find("&")]
        #print(urlStr)
        dict={'title':i.text,'url':urlStr}
        list.append(dict)
    print(list)
    file = open('D:\WebApp\WebApplication\PythonApplication1\C_Test3.txt','w',encoding='UTF-8')
    file.write(str(list))
    file.close()