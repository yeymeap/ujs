import numpy as np

# élettér
# állapotok
# szabályok
# szomszédság

ROW_LENGTH = 10
COLUMN_WIDTH = 10

grid = np.zeros([ROW_LENGTH, COLUMN_WIDTH])
grid[0, int(COLUMN_WIDTH/2)] = 1