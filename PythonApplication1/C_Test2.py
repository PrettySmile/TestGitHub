import requests
from bs4 import BeautifulSoup

# # 從檔案讀取 HTML 程式碼進行解析
# with open("index.html") as f:
#     soup = BeautifulSoup(f)

# 下載Yahoo首頁內容
r = requests.get('https://tw.yahoo.com/')
# 確認是否下載成功
if r.status_code == requests.codes.ok:
    # 以 BeautifulSoup解析HTML程式碼
    soup = BeautifulSoup(r.text,"html.parser")
    # 以 CSS 的 class抓出各類頭條新聞
    stories = soup.find_all('a',class_='story-title')
    for s in stories:
        print("標題：" + s.text)
        print("網址：" + s.get('href'))


