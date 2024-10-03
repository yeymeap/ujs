from PIL import Image, ImageDraw
import random

def GenerateImage():
    imageWidth = random.randint(200, 400)  
    imageHeight = random.randint(imageWidth + 100, 600)  

    backgroundColor = (random.randint(180, 230), random.randint(180, 230), random.randint(180, 230))
    #print(f"Background color: {backgroundColor}")
    img = Image.new('RGB', (imageWidth, imageHeight), backgroundColor)
    draw = ImageDraw.Draw(img)

    rectWidth = random.randint(50, imageWidth - 50)
    rectHeight = random.randint(50, imageHeight - 50)
    rect_x = random.randint(0, imageWidth - rectWidth)
    rect_y = random.randint(0, imageHeight - rectHeight)

    rectColor = (random.randint(0, 100), random.randint(0, 100), random.randint(0, 100))

    draw.rectangle((rect_x, rect_y, rect_x + rectWidth, rect_y + rectHeight), fill=rectColor)

    circleRadius = random.randint(20, 80)
    circleCenter_x = random.randint(circleRadius, imageWidth - circleRadius)
    circleCenter_y = random.randint(circleRadius, imageHeight - circleRadius)
    
    draw.ellipse(
        (
            (circleCenter_x - circleRadius, circleCenter_y - circleRadius,
             circleCenter_x + circleRadius, circleCenter_y + circleRadius)
        ),
        fill=(255, 0, 0)
    )

    img.show()

for i in range(5):
    GenerateImage()