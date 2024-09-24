from PIL import Image, ImageDraw
import random

imageWidth = 800
imageHeight = 600
tile = 10

def clearCanvas(color="black"):
    draw.rectangle((0, 0, imageWidth, imageHeight), fill=color)
    
image = Image.new("RGB", (imageWidth, imageHeight), color="grey")
draw = ImageDraw.Draw(image)

for i in range(0, imageWidth, tile):
    for j in range(0, imageHeight, tile):
        limit = random.randint(0, 400)
        if limit < i:
            x1 = i
            y1 = j
            x2 = i + tile
            y2 = j + tile
            draw.rectangle((x1, y1, x2, y2), fill="red")
            
for i in range(0, imageWidth, tile):
    for j in range(0, imageHeight, tile):
        limit = random.randint(0, imageWidth)
        if limit > i:
            x1 = i
            y1 = j
            x2 = i + tile
            y2 = j + tile
            draw.rectangle((x1, y1, x2, y2), fill="blue")
            
image.show()
