from PIL import Image, ImageDraw
import random

imageWidth = 600
imageHeight = 600
tile = 100
border = 50

def GenerateImage():
    image = Image.new("RGB", (imageWidth, imageHeight), color="white")
    draw = ImageDraw.Draw(image)

    myList = ["red", "blue", "green", "gray", "purple", "yellow", "hotpink", "black", "orange"]
    colorRandomize = random.choice(myList)
    
    for i in range(border, imageWidth - border, tile):
        for j in range(border, imageHeight - border, tile):
            drawProbability = random.random()
            if drawProbability > 0.5: # minel nagyobb annal kevesebb az eselye, hogy kiszinezi a tilet
                x1 = i
                y1 = j
                x2 = i + tile
                y2 = j + tile
                draw.rectangle((x1, y1, x2, y2), fill=colorRandomize)
                print(x1, y1, x2, y2)
                x1Mirror = imageWidth - x2 
                x2Mirror = imageWidth - x1
                draw.rectangle((x1Mirror, y1, x2Mirror, y2), fill=colorRandomize)
                print(x1Mirror, y1, x2Mirror, y2)
    image.show()
    
for i in range(1):
    GenerateImage()