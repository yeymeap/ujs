from bs4 import BeautifulSoup as bs # könyvtárak
import requests as re

url = "https://www.scrapethissite.com/pages/simple/" #s crapelni való url

response = re.get(url) # response kód
print(response)

soup = bs(response.text, "html.parser") # soup 

print(soup.prettify()) # szépítés
print(soup.title) # weboldal cím
print(soup.h3.text.strip()) # h3

print(soup.findAll("h3")) # minden h3 keresése
countriesList = []
countries = soup.findAll("h3") # minden h3 keresése
print(type(countries)) # típus

for country in countries:
    countriesList.append(country.text.strip()) # listához hozzáadás
print("countries:", countriesList)


capitals = soup.findAll(class_="country-capital") # class alapján keresés
capitalsList = []
for capital in capitals:
    capitalsList.append(capital.text.strip()) # listához hozzáadás
print("capitals: ", capitalsList)