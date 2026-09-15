from math import isqrt, sqrt

while True:
    try:
        x = int(input("x = "))
        break
    except ValueError:
        print("Please enter a number")

if isqrt(x) ** 2 == x:
    x += 2

Y = sqrt(x)
y = round(Y, 2)

abs_hiba = abs(Y - y)
rel_hiba = abs_hiba / abs(Y)


print(f"x = {x}")
print(f"Y = {Y}")
print(f"y = {y}\n")
print(f"abs_hiba = {abs_hiba}")
print(f"rel_hiba = {rel_hiba}\n")

Y_4 = Y ** 4
y_4 = y ** 4

abs_hiba_4 = abs(Y_4 - y_4)
rel_hiba_4 = abs_hiba_4 / abs(Y_4)

print(f"Y^4 = {Y_4}")
print(f"y^4 = {y_4}\n")
print(f"abs_hiba_4 = {abs_hiba_4}")
print(f"rel_hiba_4 = {rel_hiba_4}")

