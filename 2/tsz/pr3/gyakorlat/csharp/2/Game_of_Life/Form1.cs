using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_Life
{
    public partial class Form1 : Form
    {
        private Cells[,] cells;
        private Timer timer;
        private int rows;
        private int cols;
        private List<Cells> activeCells = new List<Cells>();
        private bool gameState = false;
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 500; // add slider to change speed
            timer.Tick += new EventHandler(TimerTick);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.icon;
            this.Text = "Game of Life";
            rows = 30; // add grid size modification
            cols = 30; // add grid size modification
            cells = new Cells[rows, cols];
            int gridWidth = cols * Cells.SIZE;
            int gridHeight = rows * Cells.SIZE;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    cells[i, j] = new Cells();
                    cells[i, j].Location = new Point(Cells.SIZE * j, Cells.SIZE * i);
                    cells[i, j].Click += new EventHandler(Clicked);
                    this.Controls.Add(cells[i, j]);
                }
            }
            GroupBox radioGroup = new GroupBox()
            {
                Text = "Type",
                Location = new Point(gridWidth + 10, 10),
                Size = new Size(100, 100)
            };
            string[] options = { "Game of Life", "Brian's Brain", "Seeds" }; // seperate the logic for each type of game
            int radioHeight = 20;
            for (int i = 0; i < options.Length; i++)
            {
                RadioButton radio = new RadioButton()
                {
                    Text = options[i],
                    Location = new Point(10, 20 + i * radioHeight),
                    AutoSize = true,
                    Checked = i == 0
                };
                radioGroup.Controls.Add(radio);
            }
            this.Controls.Add(radioGroup);
            string[] buttons = { "Start", "Stop", "Clear", "Reset" }; // combine buttons by making them change text and functionality based on state
            int buttonWidth = 100;
            int buttonHeight = 30;
            EventHandler[] eventHandlers = { StartClicked, StopClicked,ClearClicked, ResetClicked };
            for (int i = 0; i < buttons.Length; i++)
            {
                Button button = new Button()
                {
                    Text = buttons[i],
                    Location = new Point(gridWidth + 10, 120 + i * buttonHeight),
                    Size = new Size(buttonWidth, buttonHeight)
                };
                button.Click += eventHandlers[i];
                this.Controls.Add(button);
            }
            this.ClientSize = new Size(gridWidth + radioGroup.Width + 20, Math.Max(gridHeight, radioGroup.Height + 10));
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = true;
            this.MaximizeBox = false;
        }
        private void Clicked(object sender, EventArgs e)
        {
            if (gameState == false)
            {
                Cells c = (Cells)sender;
                switch (c.GetState())
                {
                    case Cells.CellState.Dead:
                        c.SetAlive();
                        activeCells.Add(c);
                        break;
                    case Cells.CellState.Alive:
                        c.SetDead();
                        activeCells.Remove(c);
                        break;
                    case Cells.CellState.Suspended:
                        c.SetDead();
                        activeCells.Remove(c);
                        break;
                }
            }
        }
        private void StartClicked(object sender, EventArgs e)
        {
            timer.Start();
            //gameState = true;
        }
        private void StopClicked(object sender, EventArgs e)
        {
            timer.Stop();
            //gameState = false;
        }
        private void ClearClicked(object _, EventArgs __)
        {
            foreach (Cells c in activeCells)
            {
                c.SetDead();
            }
            activeCells.Clear();
        }
        private void ResetClicked(object _, EventArgs __)
        {
            
        }
        private int CountAliveNeighbours(int row, int col)
        {
            int aliveCount = 0;
            for(int i = -1; i <= 1; i++)
            {
                for(int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    int neighbourRow = row + i;
                    int neighbourCol = col + j;
                    if (neighbourRow >= 0 && neighbourRow < rows && neighbourCol >= 0 && neighbourCol < cols)
                    {
                        Cells.CellState state = cells[neighbourRow, neighbourCol].GetState();
                        if (state == Cells.CellState.Alive)
                        {
                            aliveCount++;
                        }
                    }
                }
            }
            return aliveCount;
        }
        private void UpdateCells()
        {
            Cells[,] nextGrid = new Cells[rows, cols];
            List<Cells> cellsToAdd = new List<Cells>();
            List<Cells> cellsToRemove = new List<Cells>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    nextGrid[i, j] = new Cells();
                    int aliveNeighbours = CountAliveNeighbours(i, j);
                    Cells.CellState state = cells[i, j].GetState();
                    if (state == Cells.CellState.Alive)
                    {
                        if (aliveNeighbours < 2 || aliveNeighbours > 3)
                        {
                            nextGrid[i, j].SetDead();
                            cellsToRemove.Add(cells[i, j]);
                        }
                        else
                        {
                            nextGrid[i, j].SetAlive();
                            cellsToAdd.Add(cells[i, j]);
                        }
                    }
                    else
                    {
                        if (aliveNeighbours == 3)
                        {
                            nextGrid[i, j].SetAlive();
                            cellsToAdd.Add(cells[i, j]);
                        }
                        else
                        {
                            nextGrid[i, j].SetDead();
                            cellsToRemove.Add(cells[i, j]);
                        }
                    }
                }
            }
            foreach (Cells c in cellsToAdd)
            {
                activeCells.Add(c);
            }
            foreach (Cells c in cellsToRemove)
            {
                activeCells.Remove(c);
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    cells[i, j].SetState(nextGrid[i, j].GetState());
                }
            }
        }
        private void TimerTick(object sender, EventArgs e)
        {
            UpdateCells();// pause the game if all cells are dead
            Console.WriteLine(activeCells.Count);
        }
    }
}