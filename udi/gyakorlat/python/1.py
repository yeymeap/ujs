import random
#x = 0
#print(x)
#x = 'c'
#print(x)
#x = 5.5
#print(x)
#x = 'haha'
#print(x)
#x = [5,6,7]
#print(x)
#print(x[0])
#print(sum(x))

for i in range(1, 10):
    y = random.randint(-20, 40)
    if(y <= 5):
        print("naon hideg van:", y)
    elif(y > 5 and y <= 15):
        print("mersekelt ido van: ", y)
    elif(y > 15 and y <= 30):
        print("meleg van:", y)
    else:
        print("naon meleg van:", y)
z = input("hany eves vagy:")
print("te", z, "eves vagy")

for i in range(1,11):
    print(i)
    
for i in range(1,21):
    if i % 2 == 0:
        print(i)

for i in range(2023, 0, -1):
    print(i)

x = int(input("x = "))
y = int(input("y = "))
lista = []
for i in range(x, y+1):
    print(i)
    lista.append(i)
print(sum(lista)/len(lista))

a = int(input("a = "))
b = int(input("b = "))
perimeter = 2 * (a + b)
area = a * b

print("perimeter = ", perimeter, "area =", area)

c = int(input("c = "))
factorial = 1
for i in range(1, c + 1):
    factorial = factorial * i
print("c factorial =", factorial)

for i in range(1, 2021):
    if(i % 4 == 0 and i % 7 == 0):
        print(i)
        
for i in range(1, 2021):
    if(i % 4 == 0 or i % 7 == 0):
        print(i)

for i in range(1, 2021):
    print(i * i)

age = int(input("Your age: "))
if(age < 18):
    print("You are not old enough to enter!")
elif(age >= 18):
    if(age >= 18 and age < 96):
        print("Welcome!")
    else:
        print("I've never seen anyone above age 95, but welcome anyway!")

array1 = [1,5,3,4,6,8,7,2]
array2 = [4,5,6, "korte", "alma"]
array3 = ["alma", "korte"]
print(array1)
array1.append(9)
print(array1)
print(type(array1))
print(sum(array1))
print(len(array1))
print(sum(array1)/len(array1))
print(array2[0:3])
print(sum(array2[0:3]))
print(type(array2))
print(type(array1[1]))
array1.sort()
print(array1)
array1.sort(reverse=True)
print(array1)

num = int(input('num: '))
if num > 1:
	for i in range(2, int(num/2)+1):
		if (num % i) == 0:
			print(num, "is not a prime number")
			break
	else:
		print(num, "is a prime number")
else:
	print(num, "is not a prime number")

n = float(input("n = "))
m = float(input("m = "))
if(n > m):
    print("n nagyobb")
elif(n < m):
    print("m nagyobb")
else:
    print("egyenloek")
    
times = int(input("hany datumot akarsz beirni?"))
datearray = []
for i in range(1, times+1):
    date = str(input("date: "))
    datearray.append(date)

datearray.sort(reverse=True)
print(datearray[0])

import random
perpetrators = ["Aladar", "Geza", "Bloki"]
victims = ["Kajla", "Maszla", "Kaszla"]
places = ["house", "market", "forest"]
weapons = ["knife", "spear", "pistol"]
sentence = []
sentence.append(random.choice(perpetrators))
sentence.append(random.choice(victims))
sentence.append(random.choice(places))
sentence.append(random.choice(weapons))
print(sentence[0], "killed", sentence[1], "with a", sentence[3], "at a", sentence[2]+"!")

import matplotlib.pyplot as plt
import numpy as np
