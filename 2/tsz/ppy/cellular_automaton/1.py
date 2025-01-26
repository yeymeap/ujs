import tkinter as tk

# Constants
WINDOW_SIZE = 500
GRID_SIZE = 50
CELL_SIZE = WINDOW_SIZE // GRID_SIZE

# Global Variables
grid = [[0 for _ in range(GRID_SIZE)] for _ in range(GRID_SIZE)]
running = False

def draw_grid(canvas):
    canvas.delete("all")
    for i in range(GRID_SIZE):
        for j in range(GRID_SIZE):
            x0, y0 = i * CELL_SIZE, j * CELL_SIZE
            x1, y1 = x0 + CELL_SIZE, y0 + CELL_SIZE
            color = "black" if grid[i][j] == 1 else "white"
            canvas.create_rectangle(x0, y0, x1, y1, fill=color, outline="gray")

def update_grid():
    global grid
    new_grid = [[0 for _ in range(GRID_SIZE)] for _ in range(GRID_SIZE)]
    for i in range(GRID_SIZE):
        for j in range(GRID_SIZE):
            live_neighbors = count_live_neighbors(i, j)

            # Rules of the game
            if grid[i][j] == 1:
                if live_neighbors in [2, 3]:
                    new_grid[i][j] = 1
            else:
                if live_neighbors == 3:
                    new_grid[i][j] = 1
    grid = new_grid

def count_live_neighbors(x, y):
    count = 0
    for dx in [-1, 0, 1]:
        for dy in [-1, 0, 1]:
            if dx == 0 and dy == 0:
                continue
            nx, ny = x + dx, y + dy
            if 0 <= nx < GRID_SIZE and 0 <= ny < GRID_SIZE:
                count += grid[nx][ny]
    return count

def toggle_cell(event, canvas):
    x, y = event.x // CELL_SIZE, event.y // CELL_SIZE
    if 0 <= x < GRID_SIZE and 0 <= y < GRID_SIZE:
        grid[x][y] = 1 if grid[x][y] == 0 else 0
        draw_grid(canvas)

def start_game(canvas):
    global running
    running = True
    run_game(canvas)

def stop_game():
    global running
    running = False

def reset_game(canvas):
    global grid
    grid = [[0 for _ in range(GRID_SIZE)] for _ in range(GRID_SIZE)]
    draw_grid(canvas)

def run_game(canvas):
    if running:
        update_grid()
        draw_grid(canvas)
        canvas.after(100, run_game, canvas)

def main():
    root = tk.Tk()
    root.title("Conway's Game of Life")

    canvas = tk.Canvas(root, width=WINDOW_SIZE, height=WINDOW_SIZE, bg="white")
    canvas.pack()

    canvas.bind("<Button-1>", lambda event: toggle_cell(event, canvas))

    start_btn = tk.Button(root, text="Start", command=lambda: start_game(canvas))
    start_btn.pack(side=tk.LEFT)

    stop_btn = tk.Button(root, text="Stop", command=stop_game)
    stop_btn.pack(side=tk.LEFT)

    reset_btn = tk.Button(root, text="Reset", command=lambda: reset_game(canvas))
    reset_btn.pack(side=tk.LEFT)

    draw_grid(canvas)

    root.mainloop()

if __name__ == "__main__":
    main()
