from selenium import webdriver

driver = webdriver.PhantomJS(executable_path=r'D:\phantomjs-2.1.1-windows\bin\phantomjs.exe')
driver.get('http://pala.tw/js-example/')
pageSource = driver.page_source
print(pageSource)

driver.close()