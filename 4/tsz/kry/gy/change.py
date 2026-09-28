from frequency_analysis import frequency_analysis
from rot_n import rot_n

with open("text.txt", "r") as f:
    file_text = f.read()

print(f"Original text:\n{file_text}")
encrypted_text = rot_n(file_text, 13)
print(f"Encrypted text:\n{encrypted_text}")

print("Original text frequency: ")
original_frequency = frequency_analysis(file_text)
print("Encrypted text frequency: ")
encrypted_frequency = frequency_analysis(encrypted_text)

frequency_map = {}

for i in range(len(encrypted_frequency)):
    encrypted_char = encrypted_frequency[i][0]
    original_char = original_frequency[i][0]

    frequency_map[encrypted_char] = original_char

print(f"Frequency map:\n{frequency_map}")

decrypted_text = ""

for char in encrypted_text:
    if char.isalpha():
        decrypted_char = frequency_map.get(char.lower(), char)

        if char.isupper():
            decrypted_char = decrypted_char.upper()

        decrypted_text += decrypted_char
    else:
        decrypted_text += char

with open("decrypted.txt", "w") as f:
    f.write(decrypted_text)

print(f"Decrypted text:\n{decrypted_text}")