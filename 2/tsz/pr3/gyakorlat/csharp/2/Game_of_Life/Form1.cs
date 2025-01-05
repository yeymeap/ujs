using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
        private bool gameRunning = false;
        private Label runningText;
        private List<Button> buttonList = new List<Button>();
        private List<RadioButton> radioButtonList = new List<RadioButton>();
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += new EventHandler(TimerTick);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.icon;
            this.Text = "Game of Life";
            rows = 30;
            cols = 30;
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
            string[] options = { "Game of Life", "Brian's Brain", "Seeds" };// add more colors, especially for brians brain, add checkmark/x image based on game state
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
                radioButtonList.Add(radio);
                radio.CheckedChanged += new EventHandler(ChangingType);
            }
            this.Controls.Add(radioGroup);
            string[] buttonTexts = { "Start", "Reset/Clear"}; // combine buttons by making them change text and functionality based on state, disable reset/clear when game is running
            int buttonWidth = 100;
            int buttonHeight = 30;
            EventHandler[] eventHandlers = { StartStopClicked, ClearResetClicked };
            for (int i = 0; i < buttonTexts.Length; i++)
            {
                Button button = new Button()
                {
                    Text = buttonTexts[i],
                    Location = new Point(gridWidth + 10, 120 + i * buttonHeight),
                    Size = new Size(buttonWidth, buttonHeight)
                };
                button.Click += eventHandlers[i];
                buttonList.Add(button);
                this.Controls.Add(button);
            }
            runningText = new Label()
            {
                Text = "Game is not running",
                Location = new Point(gridWidth + 10, 200),
                AutoSize = true,
                ForeColor = Color.Red,
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(runningText);
            this.ClientSize = new Size(gridWidth + radioGroup.Width + 20, Math.Max(gridHeight, radioGroup.Height + 10));
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = true;
            this.MaximizeBox = false;
        }
        private void Clicked(object sender, EventArgs e)
        {
            if (gameRunning == false)
            {
                if (radioButtonList[0].Checked || radioButtonList[2].Checked)
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
                    }
                }
                else if(radioButtonList[1].Checked)
                {
                    Cells c = (Cells)sender;
                    switch (c.GetState())
                    {
                        case Cells.CellState.Dead:
                            c.SetAlive();
                            activeCells.Add(c);
                            break;
                        case Cells.CellState.Alive:
                            c.SetSuspended();
                            break;
                        case Cells.CellState.Suspended:
                            c.SetDead();
                            activeCells.Remove(c);
                            break;
                    }
                }
            }
        }
        private void StartStopClicked(object sender, EventArgs e)
        {
            if (!gameRunning && activeCells.Count > 0)
            {
                gameRunning = true;
                timer.Start();
                StartStopButtonTextUpdate();
                GameStateTextUpdate(runningText);
                RadioEnableDisable();
            }
            else if (gameRunning)
            {
                gameRunning = false;
                timer.Stop();
                StartStopButtonTextUpdate();
                GameStateTextUpdate(runningText);
                RadioEnableDisable();
            }
        }
        private void ClearResetClicked(object sender, EventArgs e)
        {
            if (!gameRunning)
            {

                foreach (Cells c in activeCells)
                {
                    c.SetDead();
                }
              activeCells.Clear();
            }
        }
        private void GameStateTextUpdate(Label label)
        {
            if (gameRunning)
            {
                label.Text = "Game is running";
                label.ForeColor = Color.Green;
            }
            else if(!gameRunning)
            {
                label.Text = "Game is not running";
                label.ForeColor = Color.Red;
            }
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
        private void UpdateCellsGameOfLife()
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
            CopyGrid(nextGrid, cells);
        }
        private void UpdateCellsSeeds()
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
                    if (state == Cells.CellState.Dead && aliveNeighbours == 2)
                    {
                        nextGrid[i, j].SetAlive();
                        cellsToAdd.Add(cells[i, j]);
                    }
                    else if(state == Cells.CellState.Alive)
                    {
                        nextGrid[i, j].SetDead();
                        cellsToRemove.Add(cells[i, j]);
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
            CopyGrid(nextGrid, cells);
        }
        private void UpdateCellsBriansBrain()
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
                    if (state == Cells.CellState.Dead && aliveNeighbours == 2)
                    {
                        nextGrid[i, j].SetAlive();
                        cellsToAdd.Add(cells[i, j]);
                    }
                    else if (state == Cells.CellState.Alive)
                    {
                        nextGrid[i, j].SetSuspended();
                    }
                    else if (state == Cells.CellState.Suspended)
                    {
                        nextGrid[i, j].SetDead();
                        cellsToRemove.Add(cells[i, j]);
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
            CopyGrid(nextGrid, cells);
        }
        private void CopyGrid(Cells[,] source, Cells[,] destination)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    destination[i, j].SetState(source[i, j].GetState());
                }
            }
        }
        private void TimerTick(object sender, EventArgs e)
        {
            int index = radioButtonList.IndexOf(radioButtonList.Find(r => r.Checked));
            switch(index)
            {
                case 0:
                    UpdateCellsGameOfLife();
                    break;
                case 1:
                    UpdateCellsBriansBrain();
                    break;
                case 2:
                    UpdateCellsSeeds();
                    break;
            }
            if(activeCells.Count == 0)
            {
                timer.Stop();
                gameRunning = false;
                GameStateTextUpdate(runningText);
                StartStopButtonTextUpdate();
                RadioEnableDisable();
            }
        }
        private void StartStopButtonTextUpdate()
        {
            Button button = buttonList[0];
            if (gameRunning)
            {
                button.Text = "Stop";
            }
            else
            {
                button.Text = "Start";
            }
        }
        private void RadioEnableDisable()
        {
            if (gameRunning)
            {
                foreach (RadioButton r in radioButtonList)
                {
                    r.Enabled = false;
                }
            }
            else if(!gameRunning)
            {
                foreach (RadioButton r in radioButtonList)
                {
                    r.Enabled = true;
                }
            }
        }

        private void ChangingType(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            List<Cells> cellsToRemove = new List<Cells>();
            if (radioButton != null && radioButton.Checked)
            {
                int index = radioButtonList.IndexOf(radioButton);
                
                switch(index)
                {
                    case 0:
                        foreach (Cells c in activeCells)
                        {
                            Cells.CellState state = c.GetState();
                            if (state == Cells.CellState.Suspended)
                            {
                                c.SetDead();
                                cellsToRemove.Add(c);
                            }
                        }
                        foreach (Cells c in cellsToRemove)
                        {
                            activeCells.Remove(c);
                        }
                        break;
                    case 2:
                        foreach (Cells c in activeCells)
                        {
                            Cells.CellState state = c.GetState();
                            if (state == Cells.CellState.Suspended)
                            {
                                c.SetDead();
                                cellsToRemove.Add(c);
                            }
                        }
                            foreach(Cells c in cellsToRemove)
                            {
                                activeCells.Remove(c);
                            }
                        break;
                }
            }
        }
    }
}