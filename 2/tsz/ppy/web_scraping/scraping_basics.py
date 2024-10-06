from bs4 import BeautifulSoup as bs # könyvtárak
import requests as re
import pandas as pd
from tabulate import tabulate

url = "https://www.scrapethissite.com/pages/simple/" #s crapelni való url

response = re.get(url) # response kód
#print(response)

soup = bs(response.text, "html.parser") # soup 

#print(soup.prettify()) # szépítés
#print(soup.title) # weboldal cím
#print(soup.h3.text.strip()) # h3

#print(soup.findAll("h3")) # minden h3 keresése
countriesList = []
countries = soup.findAll("h3") # minden h3 keresése
#print(type(countries)) # típus

for country in countries:
    countriesList.append(country.text.strip()) # listához hozzáadás
#print("countries:", countriesList)


capitals = soup.findAll(class_="country-capital") # class alapján keresés
capitalsList = []
for capital in capitals:
    capitalsList.append(capital.text.strip()) # listához hozzáadás
#print("capitals: ", capitalsList)


population = soup.findAll(class_="country-population") # class alapján keresés
populationList= []
for pop in population:
    populationList.append(pop.text.strip()) # listához hozzáadás, helyköz eltávolítása
    
populationList = list(map(int, populationList)) # lista elemeinek konvertálása intre
#print("population sum:", sum(populationList))


popMin = min(x for x in populationList if x !=0) # min keresése listában
#print("population min:", popMin)
popMax = max(populationList) # max keresése listában
#print("population max:", popMax)


countryArea = soup.findAll(class_="country-area") # class alapján keresés
countryAreaList = []
for area in countryArea:
    countryAreaList.append(area.text.strip()) # listához hozzáadás, helyköz eltávolítása
countryAreaList = list(map(float, countryAreaList)) # lista elemeinek konvertálása floatra
#print("country area:", countryAreaList)

areaMin = min(x for x in countryAreaList if x != 0) # min keresése listában
#print("area min:",areaMin)
areaMax = max(countryAreaList) # max keresése listában
#print("area max:", areaMax)


popDensityList = []
for i in range(len(populationList)):
    if countryAreaList[i] != 0: # ha nem egyenlő 0
        popdensity = round(populationList[i] / countryAreaList[i], 2) # kiszámolja a népsűrűséget, közben kezeli a 0-val osztást
        popDensityList.append(popdensity) # listához hozzáadás
    elif countryAreaList[i] == 0: # kivetelkezelés az olyan ország(ok)ra, ahol a terület == 0 és populáció > 0
        popdensity = populationList[i] # adott ország populációja
        popDensityList.append(popdensity) # listához hozzáadás
    
#print("pop density:", popDensityList)

#print("country:",len(countriesList))
#print("capital:",len(capitalsList))
#print("population:",len(populationList))
#print("area:",len(countryAreaList))
#print("density:",len(popDensityList))

df = pd.DataFrame({ # táblázat
    'Ország': countriesList,
    'Főváros': capitalsList,
    'Populáció': populationList,
    'Terület (km²)': countryAreaList,
    'Népsűrűség (ember/km²)': popDensityList
})

print(tabulate(df, headers='keys', tablefmt='grid')) #grid a táblázat köré