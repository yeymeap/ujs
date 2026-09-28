def frequency_analysis(text):
    frequency = {}

    for letter in "abcdefghijklmnopqrstuvwxyz":
        frequency[letter] = 0

    for char in text.lower():
        if char in frequency:
            frequency[char] += 1

    for char in frequency:
        if frequency[char] > 0:
            print(f"{char}: {frequency[char]}")

    sorted_frequency = sorted(
        ((char, count) for char, count in frequency.items() if count > 0),
        key=lambda item: item[1],
        reverse=True
    )

    return sorted_frequency
