from PIL import Image, ImageDraw
import random

# github profilkep generalas
# 5 sor 5 oszlop, el kell tolni az 1. oszlop x 400-al, 2. oszlopot x 200-all, ezaltal az 5.-ik es 4.-ik oszlopba kerulnek
# kozeppontot nem kell tukrozni, tehat 3 eset, veletlen szin, van keret

imageWidth = 500
imageHeight = 500
tile = 100

image = Image.new("RGB", (imageWidth, imageHeight), color="grey")
draw = ImageDraw.Draw(image)

for i in range(0, imageWidth, tile):
    for j in range(0, imageHeight, tile):
        limit = random.randint(0, imageWidth)
        if limit > i: # innen ez valoszinu nem jo
            if (j == 100):
                x1 = i
                y1 = j
                x2 = i + tile
                y2 = j + tile
                draw.rectangle((x1, y1, x2, y2), fill="red")
                x1 = x1 + 400
                x2 = x2 + 400
            elif(j == 200):
                x1 = i
                y1 = j
                x2 = i + tile
                y2 = j + tile
                draw.rectangle((x1, y1, x2, y2), fill="red")
                x1 = x1 + 200
                x2 = x2 + 200
image.show()
