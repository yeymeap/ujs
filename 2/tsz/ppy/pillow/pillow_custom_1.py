from PIL import Image, ImageDraw
import random

image_width = 1920
image_height = 1080
image = Image.new("RGB", (image_width, image_height), color="white")
draw = ImageDraw.Draw(image)
color_list = ["red", "blue", "green", "gray", "purple", "yellow", "hotpink", "black", "orange"]
shape_list = ["line", "rectangle", "ellipse", "polygon", "arc"]
default_canvas_color = "white"

def ClearCanvas():
    draw.rectangle((0, 0, image_width, image_height), fill=default_canvas_color)
        
def DrawShape():
    color_fill_randomize = random.choice(color_list)
    color_outline_randomize = random.choice(color_list)
    shape_randomize = random.choice(shape_list)
    x1 = random.randint(0, image_width)
    y1 = random.randint(0, image_height)        
    x2 = random.randint(x1, image_width)
    y2 = random.randint(y1, image_height)
    
    if(shape_randomize == "line"):
        draw.line([x1, y1, x2, y2], fill=color_fill_randomize)
    elif(shape_randomize == "rectangle"):
        draw.rectangle([x1, y1, x2, y2], fill=color_fill_randomize, outline=color_outline_randomize)
    elif(shape_randomize == "ellipse"):
        draw.ellipse([x1, y1, x2, y2], fill=color_fill_randomize, outline=color_outline_randomize)

for i in range(1000):
    DrawShape()
image.show()