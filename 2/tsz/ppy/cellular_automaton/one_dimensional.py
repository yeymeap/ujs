import time
import numpy as np
import plotly.express as px
from IPython.display import clear_output

# élettér
# állapotok
# szabályok
# szomszédság
# rule 30 https://mathworld.wolfram.com/images/eps-svg/ElementaryCA30Rules_750.svg

ROW_LENGTH = 10
COLUMN_WIDTH = 5

grid = np.zeros([ROW_LENGTH, COLUMN_WIDTH])
grid[0, int(COLUMN_WIDTH/2)] = 1

def reset_grid(): # grid nullázása
    global grid
    grid = np.zeros([ROW_LENGTH, COLUMN_WIDTH])
    grid[0, int(COLUMN_WIDTH / 2)] = 1

def calc_rules(): # szabályok
    for i in range(1, ROW_LENGTH):
        for j in range(0, COLUMN_WIDTH):
            #grid[i, j]
            left = grid[i - 1, j - 1] if j > 0 else 0 # pythonos csúnyaság
            mid = grid[i - 1, j]
            right = grid[i - 1, j + 1] if j < COLUMN_WIDTH - 1 else 0 # itt szintén

            if (left, mid, right) == (1, 1, 1):
                grid[i, j] = 0
            elif (left, mid, right) == (1, 1, 0):
                grid[i, j] = 0
            elif (left, mid, right) == (1, 0, 1):
                grid[i, j] = 0
            elif (left, mid, right) == (1, 0, 0):
                grid[i, j] = 1
            elif (left, mid, right) == (0, 1, 1):
                grid[i, j] = 1
            elif (left, mid, right) == (0, 1, 0):
                grid[i, j] = 1
            elif (left, mid, right) == (0, 0, 1):
                grid[i, j] = 1
            elif (left, mid, right) == (0, 0, 0):
                grid[i, j] = 0
        time.sleep(1)
        clear_output(wait = True)
        plot_grid()

def plot_grid(): # animáció
    fig = px.imshow(grid, binary_string=True)
    fig.update_xaxes(showticklabels=False)
    fig.show()

reset_grid()
calc_rules()
