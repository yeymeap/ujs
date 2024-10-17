from bs4 import BeautifulSoup as bs # könyvtárak
import requests as re
import re as regex
import os

def findData(css_selector, listname): # adatok kinyerése függvény
    tempList = soup.select(css_selector) # kiválasztás selector alapján
    for temp in tempList: 
        listname.append(temp.text.strip()) #listához adás
    return listname # lista return

def findImage(css_selector, listname): # kép keresése függvény
    tempList = soup.select(css_selector) # kép kiválasztása selector alapján
    for temp in tempList:
        listname.append(temp.get("src")) # listához adás, már src attribútumban lévő adattal
    return listname # lista return

def saveImage(length, img_list): # képek mentése függvény
    images_directory = "images" # images mappa
    if not os.path.exists(images_directory): # ha nem létezik images mappa
        os.makedirs("images") # készít egyet
    for i in range(length): # listák hosszúsága
        image = re.get(img_list[i]) # kép megszerzése requesttel
        with open(f"images/{i+1}.jpg", "wb") as f: # fájl megnyitása bináris írásra
            f.write(image.content) # kép írása
    icon = soup.select_one("head > link:nth-child(73)").get("href") # ikon kiválasztás selector alapján, href attribútumban lévő adattal
    icon_ico = re.get(icon) # ikon requesttel
    with open("images/favicon.ico", "wb") as f: # fájl megnyitása bináris írásra
        f.write(icon_ico.content) # kép írása

url = "https://www.imdb.com/chart/top" #scrapelni való url
headers = {"user-agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:131.0) Gecko/20100101 Firefox/131.0", # user-agent, hogy ne legyen 403 error :]
    "Accept-Language": "en-US,en;q=0.5"} # nyelvválasztás

response = re.get(url, headers=headers) # response kód

if response.status_code == 200: # response kód ellenőrzés
    print(f"OK - {response.status_code}")
else:
    print(f"ERROR - {response.status_code}")

soup = bs(response.text, "html.parser") # soup

titles_list = [] # listák
year_list = []
length_list = []
image_list = []
guide_list = []
rating_list = []
votes_list = []

title = soup.find("title").text #  cím
findData("li.ipc-metadata-list-summary-item > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > div:nth-child(1) > a:nth-child(1) > h3:nth-child(1)", titles_list) # függvények
findData("li.ipc-metadata-list-summary-item > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > div:nth-child(2) > span:nth-child(1)", year_list)
findData("li.ipc-metadata-list-summary-item > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > div:nth-child(2) > span:nth-child(2)", length_list)
findImage("li.ipc-metadata-list-summary-item > div:nth-child(1) > div:nth-child(1) > div:nth-child(2) > img:nth-child(1)", image_list)
findData("li.ipc-metadata-list-summary-item > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > div:nth-child(2) > span:nth-child(3)", guide_list)
findData("li.ipc-metadata-list-summary-item > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > span:nth-child(3) > div:nth-child(1) > span:nth-child(1) > span:nth-child(2)", rating_list)
findData("li.ipc-metadata-list-summary-item > div:nth-child(2) > div:nth-child(1) > div:nth-child(2) > span:nth-child(3) > div:nth-child(1) > span:nth-child(1) > span:nth-child(3)", votes_list)

lists_length = len(image_list) # listák elemeinek száma, ideális esetben mindegyikben ugyanennyi van

saveImage(lists_length, image_list)

titles_list = [regex.sub(r"^\d+\.\s*", "", title) for title in titles_list] # regex list comprehension, rangok eltávolítása a névből
votes_list = [regex.sub(r'\((.*?)\)', r'\1', votes) for votes in votes_list] # regex list comprehension, zárójelek eltávolítása a szavazatszámból

#print(title)
#print(titles_list)
#print(year_list)
#print(length_list)
#print(image_list)
#print(guide_list)
#print(rating_list)
#print(votes_list)

with open("movies_data.csv", "w", encoding = "utf-8") as f: # csv fájl megnyitása irásra
    f.write(f"Title,Year of release,Running time,Parental guide,Rating,Votes\n")
    for i in range(lists_length):
        f.write(f'"{titles_list[i]}",{year_list[i]},{length_list[i]},"{guide_list[i]}","{rating_list[i]}","{votes_list[i]}"\n') # csv fájlba kiírás, pár adat ""-ba van rakva, hogy ne számolja hibásan a "," delimitert
                
with open("movies_imdb_index.html", "w", encoding="utf-8") as f: # html fájlba kiírás
    f.write("<!DOCTYPE html>\n")
    f.write("<html>\n")
    f.write("<head>\n")
    f.write("<link href='images/favicon.ico' rel='icon'>\n")
    f.write("<style>body { font-family: Arial, sans-serif; background-color: #f8f9fa; color: #333; line-height: 1.6; margin: 0; padding: 20px; } h1 { text-align: center; font-size: 40px; color: #007bff; margin-bottom: 30px; } h2 { font-size: 30px; color: #0056b3; margin-top: 20px; } h3 { font-size: 18px; color: #555; margin: 5px 0; } img { max-width: 100%; height: auto; display: block; margin: 10px auto; } hr { border: 1px solid #007bff; margin: 20px 0; }</style>\n")
    f.write(f"<title>{title}</title>\n")
    f.write("</head>\n")
    f.write("<body>\n")
    f.write(f"<h1>{title}</h1>\n")
    for i in range(len(titles_list)):
        f.write(f"<h2>{i+1}. {titles_list[i]}</h2>\n")
        f.write(f"<h3>Year of release: {year_list[i]}</h3>\n")
        f.write(f"<h3>Running time: {length_list[i]}</h3>\n")
        f.write(f"<h3>Parental guide: {guide_list[i]}</h3>\n")
        f.write(f"<h3>Rating: {rating_list[i]} from {votes_list[i]} votes</h3>\n")
        f.write(f"<img src  ='images/{i+1}.jpg'>\n")
        f.write("<hr>\n")
    f.write("</body>\n")
    f.write("</html>\n")