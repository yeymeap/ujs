population = soup.findAll(class_="country-population")
populationList= []
for pop in population:
    populationList.append(pop.text.strip())
    
populationList = list(map(int,populationList))
print(sum(populationList))