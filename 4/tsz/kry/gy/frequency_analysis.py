
with open("text.txt", "r") as f:
    file_text = f.read()

frequency = {}

def frequency_analysis(text):
    for letter in "abcdefghijklmnopqrstuvwxyz":
        frequency[letter] = 0

    for char in text.lower():
        if char in frequency:
            frequency[char] += 1

    for char in frequency:
        if frequency[char] > 0:
            print(f"{char}: {frequency[char]}")

    sorted_frequency = sorted(frequency.items(), key=lambda item: item[1], reverse=True)

    return sorted_frequency
