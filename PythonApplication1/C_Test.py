from bs4 import BeautifulSoup

# 原始 HTML 程式碼
html_doc = """
<html><head><title>Hello World</title></head>
<body><h2>Test Header</h2>
<p>This is a test.</p>
<a id="link1" href="/my_link1">Link 1</a>
<a id="link2" href="/my_link2">Link 2</a>
<p>Hello, <b class="boldtext">Bold Text</b></p>
</body></html>
"""

# 以 Beautiful Soup 解析 HTML 程式碼
soup = BeautifulSoup(html_doc, 'html.parser')
print(soup.prettify())

title_tag = soup.title
print(title_tag)
print(title_tag.string)

# 抓所有a節點
a_tags = soup.find_all('a')
for tag in a_tags:
    print(tag.string)
    print(tag.get('href'))
    print(tag.get('id'))

tags = soup.find_all(['a','b'])
print(tags)

# 抓所有a和b節點，只抓2個
tags = soup.find_all(['a','b'], limit=2)
print(tags)

# 只抓第一個符合的節點
a_tag = soup.find("a")
print(a_tag)

#只找一層的節點，不往下找，(預設會往下找所有子節點)
#soup.html.find_all("title",recursive=False)

#-------------------------------------------------
print('---------------------------------------------')
#根據id搜尋
link2_tag = soup.find(id='link2')
print(link2_tag)

a_tag = soup.find_all('a',href='/my_link1')
print(a_tag)

import re
links = soup.find_all(href=re.compile("^/my_link\d"))
print(links)

link = soup.find_all(href=re.compile("^/my_link\d"),id="link1")
print(link)

#-------------------------------------------------
print('---------------------------------------------')
#根據CSS搜尋
b_tag = soup.find_all('b',class_="boldtext")
print(b_tag)

b_tag = soup.find_all(class_=re.compile(("^bold")))
print(b_tag)


css_soup=BeautifulSoup('<p class="body strikeout"></p>','html.parser')
# 只符合一個class也可以
p_tag = css_soup.find_all('p', class_="strikeout")
print(p_tag)

# 全部符合也可以
p_tag = css_soup.find_all('p', class_="body strikeout")
print(p_tag)

# 順序不同會失敗
p_tag = css_soup.find_all('p', class_="strikeout body")
print(p_tag)

# 多個class，可用css選擇器來篩選
p_tag = css_soup.select("p.strikeout.body")
print(p_tag)
p_tag = css_soup.select("p.body")
print(p_tag)
p_tag = css_soup.select("p.strikeout")
print(p_tag)
p_tag = css_soup.select("p")
print(p_tag)
p_tag = css_soup.select("all")
print(p_tag)

#-------------------------------------------------
print('---------------------------------------------')
#根據文字內容搜尋
links_html = """
<a id="link1" href="/my_link1">Link One</a>
<a id="link2" href="/my_link2">Link Two</a>
<a id="link3" href="/my_link3">Three</a>
"""

soup = BeautifulSoup(links_html,"html.parser")

a = soup.find_all("a",string="Link One")
print(a)

a = soup.find_all("a",string=re.compile("^Link"))
print(a)


#-------------------------------------------------
print('---------------------------------------------')
#向上搜尋
html_doc = """
<body><p class="my_par">
<a id="link1" href="/my_link1">Link 1</a>
<a id="link2" href="/my_link2">Link 2</a>
<a id="link3" href="/my_link3">Link 3</a>
<a id="link3" href="/my_link4">Link 4</a>
</p></body>
"""
soup = BeautifulSoup(html_doc,"html.parser")
link2_tag = soup.find(id="link2")
print(link2_tag)

p_tag = link2_tag.find_parents("p")
print(p_tag)

print('---------------------------------------------')
#同層搜尋
link_tag = link2_tag.find_previous_siblings("a")
print(link_tag)

link_tag = link2_tag.find_next_siblings("a")
print(link_tag)