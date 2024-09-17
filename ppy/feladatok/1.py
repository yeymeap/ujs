from PIL import Image, ImageDraw
import random

imageWidth = 800
imageHeight = 600

def clearCanvas(color="black"):
    draw.rectangle((0, 0, imageWidth, imageHeight), fill=color)
    
image = Image.new("RGB", (imageWidth, imageHeight), color="red")
draw = ImageDraw.Draw(image)

draw.rectangle((50,50,200,200), fill="black")
draw.ellipse((100,100,200,200), fill="gray", outline="green")
draw.ellipse((450,470,500,500), fill="gray", outline="green")
#image.show()

clearCanvas("white")

for i in range(10):
    x1 = random.randint(0, imageWidth - 100)
    y1 = random.randint(0, imageHeight - 50)
    x2 = x1 + 100
    y2 = y1 + 50
    draw.rectangle((x1, y1, x2, y2), fill="red")
#image.show()

clearCanvas("white")

for i in range(5):
    x1 = random.randint(0, imageWidth - 100)
    y1 = random.randint(0, imageHeight - 50)
    x2 = random.randrange(x1, imageWidth)
    y2 = random.randrange(y1, imageHeight)
    draw.rectangle((x1, y1, x2, y2), fill="red")
    print(x1 ,y1 ,x2 ,y2)
image.show()