num = int(input("Collatz number: "))
counter = 0
array = []
while num != 1:
    counter += 1
    if num % 2 == 0:
        var = num
        num = num / 2
        txt = f"{counter}. Even {var} / 2 = {num}"
        array.append(num)
        print(txt)
    elif num % 2 != 0:
        var = num
        num = num * 3 + 1
        txt = f"{counter}. Odd {var} * 3 + 1 = {num}"
        array.append(num)
        print(txt)
maxValue = max(array)
minValue = min(array)
print("Max: ", maxValue)
print("Min: ", minValue)