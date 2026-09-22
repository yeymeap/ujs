from matplotlib import pyplot as plt

text = str(input("Text to analyze: "))

frequency = {}

for letter in "abcdefghijklmnopqrstuvwxyz":
    frequency[letter] = 0

for char in text.lower():
    if char in frequency:
        frequency[char] += 1

for char in frequency:
    if frequency[char] > 0:
        print(f"{char}: {frequency[char]}")

sorted_frequency = sorted(frequency.items(), key=lambda item: item[1], reverse=True)

letters = list(frequency.keys())
counts = list(frequency.values())

plt.bar(letters, counts)
plt.xlabel("Letters")
plt.ylabel("Frequency")
plt.title("Frequency of Letters")

plt.show()
