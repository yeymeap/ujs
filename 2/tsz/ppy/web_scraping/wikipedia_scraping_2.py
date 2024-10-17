from bs4 import BeautifulSoup as bs # könyvtárak
import requests as re
import time

url = "https://hu.wikipedia.org/w/index.php?title=Kateg%C3%B3ria:Magyarorsz%C3%A1g_madarai" #scrapelni való url

response = re.get(url) # response kód
#print(response.status_code)
#if response.status_code == 200:
    #print("OK")
soup = bs(response.text, "html.parser") # soup

title = soup.find(class_="mw-page-title-main").text #  cím
print(title)

links = soup.select("div.mw-category-group > ul > li > a") # linkek kiválasztása
#print(links)

links_2  = [] # lista

for link in links:
    links_2.append("https://hu.wikipedia.org" + link["href"]) # listába rakás
    #print(link["href"])
    
links_2 = links_2[2:] # lista sliceolása, első kettő eltávolítása
#print(links_2) # lista linkek printelése 

bird_name = []
bird_description = []

print(len(links_2))

for i in range(198):
    #time.sleep(0.5)
    response = re.get(links_2[i]) # response kód, links_2 az url-ek listája
    bird_soup = bs(response.text, "html.parser") # soup
    if response.status_code == 200:
        try:
            print(f"OK -", response.status_code, "-", links_2[i])
            bird_name.append(bird_soup.find(class_="mw-page-title-main").text.strip()) #  cím
            print(bird_name[i])
            bird_description.append(bird_soup.select_one("p:nth-child(3)").text.strip()) # leírás
        except:
            print(f"ERROR -", links_2[i])
    else:
        print(f"ERROR -", response.status_code, "-", links_2[i]) # hibakezelés
        
#print(bird_name)
#print(len(bird_name))
#print(bird_description)
#print(len(bird_description))

# adatok kimentése csv fájlba

f = open("web_scraping/bird_data.csv", "w", encoding="utf-8")

for i in range(5):
    f.write(bird_name[i] + "; " + bird_description[i] + "\n")
f.close

# adatok felhasználása html fájlban
with open("web_scraping/bird_index.html", "w", encoding="utf-8") as f:
    f.write("<!DOCTYPE html>\n")
    f.write("<html>\n")
    f.write("<head>\n")
    f.write("<title>Magyarország madarai</title>\n")
    f.write("</head>\n")
    f.write("<body>\n")
    for i in range(5):
        f.write(f"<h1>{bird_name[i]}</h1>\n")
        f.write(f"<p>{bird_description[i]}</p>\n")
        f.write("<hr>\n")
        
    f.write("</body>\n")
    f.write("</html>\n")