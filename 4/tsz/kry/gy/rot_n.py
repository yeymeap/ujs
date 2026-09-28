def rot_n(text, rotation):
    result = ""

    for char in text:
        if 'a' <= char <= 'z':
            result += chr((ord(char) - ord('a') + rotation) % 26 + ord('a'))
        elif 'A' <= char <= 'Z':
            result += chr((ord(char) - ord('A') + rotation) % 26 + ord('A'))
        else:
            result += char

    return result