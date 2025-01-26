from PIL import Image, ImageDraw
import random

# konstansok
IMAGE_WIDTH = 1920 # kép szélessége
IMAGE_HEIGHT = 1080 # kép magassága
default_canvas_color = "white" # canvas alap színe
image = Image.new("RGB", (IMAGE_WIDTH, IMAGE_HEIGHT), color=default_canvas_color)
draw = ImageDraw.Draw(image)

# rajz paraméterek
color_list = ["red", "blue", "green", "gray", "purple", "yellow", "hotpink", "black", "orange"] # színek
shape_list = ["line", "rectangle", "ellipse", "polygon", "arc", "chord"] # alakzatok

def main():
    num_shapes = int(input("Number of shapes: ")) # alakzatok száma
    randomization_level = float(input("Enter the randomization level (0-1): ")) # súlyozás
    add_gradient = input("Add gradient background? (yes/no): ").strip().lower() # gradiens

    if add_gradient in ("yes", "y"):
        AddGradient()

    for _ in range(num_shapes):
        DrawShape(randomization_level)
        
    image.show()

def ClearCanvas(): # canvas törlése
    draw.rectangle((0, 0, IMAGE_WIDTH, IMAGE_HEIGHT), fill=default_canvas_color)

def DrawShape(randomization_level): # alakzat rajzolása
    color_fill_randomize = random.choice(color_list)
    color_outline_randomize = random.choice(color_list)
    shape_randomize = random.choices(shape_list, k=1,
    weights=[ randomization_level if s == "polygon" else 1-randomization_level for s in shape_list])[0] # súlyozással

    # koordináták súlyozása
    x1_weight = randomization_level
    y1_weight = randomization_level
    x2_weight = 1 - randomization_level
    y2_weight = 1 - randomization_level

    # koordináták
    x1 = int(random.triangular(0, IMAGE_WIDTH, IMAGE_WIDTH * x1_weight))
    y1 = int(random.triangular(0, IMAGE_HEIGHT, IMAGE_HEIGHT * y1_weight))
    x2 = int(random.triangular(x1, IMAGE_WIDTH, IMAGE_WIDTH * x2_weight))
    y2 = int(random.triangular(y1, IMAGE_HEIGHT, IMAGE_HEIGHT * y2_weight))
    
    # x és y koordináták rendezése, hogy a második koordináta nagyobb legyen mint az első
    x1, x2 = sorted([x1, x2])
    y1, y2 = sorted([y1, y2])
    
    # alakzat
    if shape_randomize == "line":
        draw.line([x1, y1, x2, y2], fill=color_fill_randomize, width=random.randint(1, 10))
    elif shape_randomize == "rectangle":
        draw.rectangle([x1, y1, x2, y2], fill=color_fill_randomize, outline=color_outline_randomize, width=random.randint(1, 5))
    elif shape_randomize == "ellipse":
        draw.ellipse([x1, y1, x2, y2], fill=color_fill_randomize, outline=color_outline_randomize, width=random.randint(1, 5))
    elif shape_randomize == "polygon":
        num_points = random.randint(3, 10)
        points = [(int(random.triangular(0, IMAGE_WIDTH, IMAGE_WIDTH * randomization_level)),
                   int(random.triangular(0, IMAGE_HEIGHT, IMAGE_HEIGHT * randomization_level))) for _ in range(num_points)]
        draw.polygon(points, fill=color_fill_randomize, outline=color_outline_randomize)
    elif shape_randomize == "arc":
        start_angle = random.randint(0, 360)
        end_angle = random.randint(start_angle, 360)
        draw.arc([x1, y1, x2, y2], start=start_angle, end=end_angle, fill=color_outline_randomize, width=random.randint(1, 5))
    elif shape_randomize == "chord":
        start_angle = random.randint(0, 360)
        end_angle = random.randint(start_angle, 360)
        draw.chord([x1, y1, x2, y2], start=start_angle, end=end_angle, fill=color_fill_randomize, outline=color_outline_randomize)


# gradiens
def AddGradient():
    for y in range(IMAGE_HEIGHT):
        r = int(255 * (y / IMAGE_HEIGHT))
        g = int(255 * ((IMAGE_HEIGHT - y) / IMAGE_HEIGHT))
        b = 128
        draw.line([(0, y), (IMAGE_WIDTH, y)], fill=(r, g, b))

main()
