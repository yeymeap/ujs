from bs4 import BeautifulSoup as bs # könyvtárak
import requests as re

url = "https://hu.wikipedia.org/w/index.php?title=Kateg%C3%B3ria:Magyarorsz%C3%A1g_madarai" #scrapelni való url

response = re.get(url) # response kód
print(response.status_code)
if response.status_code == 200:
    print("OK")
soup = bs(response.text, "html.parser") # soup

title = soup.find(class_="mw-page-title-main").text #  cím
print(title)

#div.mw-category-group:nth-child(3) > ul > li > a
links = soup.select("div.mw-category-group > ul > li > a") # linkek kiválasztása
#print(links)

links_2  = [] # lista

for link in links:
    links_2.append("https://hu.wikipedia.org" + link["href"]) # listába rakás
    print(link["href"])
    
links_2 = links_2[2:] # lista sliceolása, első kettő eltávolítása
