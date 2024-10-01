from bs4 import BeautifulSoup as bs
import requests as re

url = "https://www.scrapethissite.com/pages/simple/"

response = re.get(url)
#print(response)

soup = bs(response.text, "html.parser")

#print(soup.prettify())
#print(soup.title)
#print(soup.h3.text.strip())

#print(soup.findAll("h3"))
countriesList = []
countries = soup.findAll("h3")
#print(type(countries))

for country in countries:
    countriesList.append(country.text.strip())

print(countriesList)

capitals = soup.findAll(class_="country-capital")
capitalsList = []
for capital in capitals:
    capitalsList.append(capital.text.strip())
print(capitalsList)

population = soup.findAll(class_="country-population")
populationList= []
for pop in population:
    populationList.append(pop.text.strip())
    
populationList = list(map(int,populationList))
print(sum(populationList))