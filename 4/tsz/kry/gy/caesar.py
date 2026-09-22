def caesar_cipher(text, shift, mode="encrypt"):
    if mode not in ("encrypt", "decrypt"):
        raise ValueError("Mode must be 'encrypt' or 'decrypt'")

    if mode == "decrypt":
        shift = -shift

    result = []

    for char in text:
        if char.isalpha():
            base = ord("A") if char.isupper() else ord("a")
            shifted = (ord(char) - base + shift) % 26 + base
            result.append(chr(shifted))
        else:
            result.append(char)

    return "".join(result)

text_value = input("Text to Encrypt or Decrypt : ")
mode_value = input("Encrypt or Decrypt : ")
shift_value = int(input("Shift: "))

message = caesar_cipher(text_value, shift_value, mode_value)
print(f"message: {message}")

def brute_force_cipher(text):
    result = []

    for shift in range(26):
        for char in text:
            if char.isalpha():
                base = ord("A") if char.isupper() else ord("a")
                shifted = (ord(char) - base + shift) % 26 + base
                result.append(chr(shifted))
            else:
                result.append(char)
        print("".join(result))
        result = []


brute_force_cipher(message)
