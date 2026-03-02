def vigenere_cipher(text, key, mode="encrypt"):
    if not key.isalpha():
        raise ValueError("Key must contain only letters")

    result = []
    key = key.lower()
    key_index = 0

    for char in text:
        if char.isalpha():
            shift = ord(key[key_index % len(key)]) - ord("a")
            if mode == "decrypt":
                shift = -shift

            base = ord("A") if char.isupper() else ord("a")
            shifted = (ord(char) - base + shift) % 26 + base
            result.append(chr(shifted))

            key_index += 1
        else:
            result.append(char)

    return "".join(result)
