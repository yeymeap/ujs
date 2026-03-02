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
