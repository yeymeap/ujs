from bs4 import BeautifulSoup as bs # könyvtárak
import requests as re

url = "https://hu.wikipedia.org/wiki/K%C3%A9kfark%C3%BA_gyurgyalag" #scrapelni való url

response = re.get(url) # response kód
print(response.status_code)
if response.status_code == 200:
    print("OK")
soup = bs(response.text, "html.parser") # soup

title = soup.find(class_="mw-page-title-main").text #  cím
print(title)

#mw-content-text > div.mv-content-ltr.mr-parser-output > p:nth-child(3)

#paragraph_2 = soup.select("p:nth-child(3)") # összeset kiválasztja, ez lista lesz
#print(paragraph_2[0].text)

paragraph = soup.select_one("p:nth-child(3)").text # csak az elsőt választja ki, amelyre a feltétel igaz
print(paragraph)

#.infobox > tbody:nth-child(1) > tr:nth-child(3) > td:nth-child(1) > span:nth-child(1) > a:nth-child(1) > img:nth-child(1)
image = soup.select_one(".infobox > tbody:nth-child(1) > tr:nth-child(3) > td:nth-child(1) > span:nth-child(1) > a:nth-child(1) > img:nth-child(1)") #selectorral kiválasztás
#print(image.get("src"))

image_link = "https:" + image.get("src") # link
print(image_link)
image_jpg = re.get(image_link) # link mentése 

with open("madár.jpg", "wb") as f: #mentés
    f.write(image_jpg.content) # mentés
    
