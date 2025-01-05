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
        private List<RadioButton> radioButtonGameTypeList = new List<RadioButton>();
        private List<RadioButton> radioButtonGridTypeList = new List<RadioButton>();
        private int selectedRadioButtonGridTypeIndex = 0;
        private Bitmap[] images = { Properties.Resources.Checkmark, Properties.Resources.Ex };
        private Bitmap bmp1;
        private Bitmap bmp2;
        private MyImage imageDisplay;
        private HScrollBar speedScrollBar;
        private Label speedLabel;
        private int simulationSpeed = 500;
        private int generation = 0;
        private Label generationLabel;

        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = simulationSpeed;
            timer.Tick += new EventHandler(TimerTick);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.icon;
            this.Text = "Cellular Automaton";
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
            GroupBox radioGroupGameType = new GroupBox()
            {
                Text = "Game Type",
                Location = new Point(gridWidth + 10, 10),
                Size = new Size(100, 80)
            };
            string[] optionsGameType = { "Game of Life", "Brian's Brain", "Seeds" };
            int radioHeight = 20;
            for (int i = 0; i < optionsGameType.Length; i++)
            {
                RadioButton radio = new RadioButton()
                {
                    Text = optionsGameType[i],
                    Location = new Point(10, 20 + i * radioHeight),
                    AutoSize = true,
                    Checked = i == 0
                };
                radioGroupGameType.Controls.Add(radio);
                radioButtonGameTypeList.Add(radio);
                radio.CheckedChanged += new EventHandler(ChangingGameType);
            }
            this.Controls.Add(radioGroupGameType);
            GroupBox radioGroupGridType = new GroupBox()
            {
                Text = "Grid Type",
                Location = new Point(gridWidth + 10, 100),
                Size = new Size(100, 60),
            };
            string[] options = { "Basic", "Toroid" };
            for (int i = 0; i < options.Length; i++)
            {
                RadioButton radio = new RadioButton()
                {
                    Text = options[i],
                    Location = new Point(10, 20 + i * radioHeight),
                    AutoSize = true,
                    Checked = i == 0
                };
                radioGroupGridType.Controls.Add(radio);
                radioButtonGridTypeList.Add(radio);
                radio.CheckedChanged += new EventHandler(ChangingGridType);
            }
            this.Controls.Add(radioGroupGridType);
            generationLabel = new Label()
            {
                Text = "Generation: " + generation,
                Location = new Point(gridWidth + 10, 430),
                AutoSize = true
            };
            this.Controls.Add(generationLabel);
            speedLabel = new Label()
            {
                Text = "Simulation speed: " + simulationSpeed,
                Location = new Point(gridWidth + 10, 240),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(speedLabel);
            speedScrollBar = new HScrollBar()
            {
                Location = new Point(gridWidth + 10, 260),
                Size = new Size(100, 20),
                Minimum = 100,
                Maximum = 2000,
                Value = 500,
                SmallChange = 1,
                LargeChange = 10
            };
            speedScrollBar.Scroll += new ScrollEventHandler(SpeedChangeScroll);
            Controls.Add(speedScrollBar);
            string[] buttonTexts = { "Start", "Clear"};
            int buttonWidth = 100;
            int buttonHeight = 30;
            EventHandler[] eventHandlers = { StartStopClicked, ClearResetClicked };
            for (int i = 0; i < buttonTexts.Length; i++)
            {
                Button button = new Button()
                {
                    Text = buttonTexts[i],
                    Location = new Point(gridWidth + 10, 170 + i * buttonHeight),
                    Size = new Size(buttonWidth, buttonHeight)
                };
                button.Click += eventHandlers[i];
                buttonList.Add(button);
                this.Controls.Add(button);
            }
            runningText = new Label()
            {
                Text = "Game is not running!",
                Location = new Point(gridWidth + 10, 410),
                AutoSize = true,
                ForeColor = Color.Red,
                TextAlign = ContentAlignment.MiddleCenter
            };
            bmp1 = new Bitmap(Properties.Resources.Ex);
            bmp2 = new Bitmap(Properties.Resources.Checkmark);
            imageDisplay = new MyImage(bmp1);
            imageDisplay.ShowImage(this, new Point(gridWidth + 10, 300));
            this.Controls.Add(runningText);
            this.ClientSize = new Size(gridWidth + radioGroupGameType.Width + 20, Math.Max(gridHeight, radioGroupGameType.Height + 10));
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = true;
            this.MaximizeBox = false;
            this.BackColor = Color.White;
        }
        private void Clicked(object sender, EventArgs e)
        {
            if (gameRunning == false)
            {
                generationLabelReset();
                if (radioButtonGameTypeList[0].Checked || radioButtonGameTypeList[2].Checked)
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
                else if(radioButtonGameTypeList[1].Checked)
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
                GameStateHelper();
            }
            else if (gameRunning)
            {
                gameRunning = false;
                timer.Stop();
                GameStateHelper();
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
                generationLabelReset();
            }
        }
        private void GameStateTextUpdate(Label label)
        {
            if (gameRunning)
            {
                label.Text = "Game is running!";
                label.ForeColor = Color.Green;
            }
            else if(!gameRunning)
            {
                label.Text = "Game is not running!";
                label.ForeColor = Color.Red;
            }
        }
        private int CountAliveNeighbours(int row, int col)
        {
            int index = ReturnSelectedRadioButtonGridTypeIndex();
            switch (index)
            {
                case 0:
                    return CountAliveNeighboursBasic(row, col);
                case 1:
                    return CountAliveNeighboursToroid(row, col);
                default:
                    return 0;
            }
            
        }
        private int CountAliveNeighboursBasic(int row, int col)
        {
            int aliveCount = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
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
        private int CountAliveNeighboursToroid(int row, int col)
        {
            int aliveCount = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    int neighbourRow = (row + i + rows) % rows;
                    int neighbourCol = (col + j + cols) % cols;
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
            generation++;
            generationLabelUpdate();
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
            generation++;
            generationLabelUpdate();
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
            generation++;
            generationLabelUpdate();
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
            int index = radioButtonGameTypeList.IndexOf(radioButtonGameTypeList.Find(r => r.Checked));
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
                gameRunning = false;
                timer.Stop();
                GameStateHelper();
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
                foreach (RadioButton r in radioButtonGameTypeList)
                {
                    r.Enabled = false;
                }
                foreach (RadioButton r in radioButtonGridTypeList)
                {
                    r.Enabled = false;
                }
            }
            else if(!gameRunning)
            {
                foreach (RadioButton r in radioButtonGameTypeList)
                {
                    r.Enabled = true;
                }
                foreach (RadioButton r in radioButtonGridTypeList)
                {
                    r.Enabled = true;
                }
            }
        }
        private void ChangingGameType(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            List<Cells> cellsToRemove = new List<Cells>();
            if (radioButton != null && radioButton.Checked)
            {
                generationLabelReset();
                int index = radioButtonGameTypeList.IndexOf(radioButton);
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
        private void ChangingGridType(object sender, EventArgs e)
        {
            generationLabelReset();
            RadioButton radioButton = (RadioButton)sender;
            selectedRadioButtonGridTypeIndex = radioButtonGridTypeList.IndexOf(radioButton);
        }
        private int ReturnSelectedRadioButtonGridTypeIndex()
        {
            return selectedRadioButtonGridTypeIndex;
        }
        private void ClearButtonEnableDisable()
        {
            if (gameRunning)
            {
                buttonList[1].Enabled = false;
            }
            else if (!gameRunning)
            {
                buttonList[1].Enabled = true;
            }
        }
        private void ImageCheckmarkEx()
        {
            if (gameRunning)
            {
                imageDisplay.ChangeImage(bmp2);
            }
            else if (!gameRunning)
            {
                imageDisplay.ChangeImage(bmp1);
            }
        }
        private void GameStateHelper()
        {
            GameStateTextUpdate(runningText);
            StartStopButtonTextUpdate();
            RadioEnableDisable();
            ClearButtonEnableDisable();
            ImageCheckmarkEx();
        }
        private void SpeedChangeScroll(object sender, EventArgs e)
        {
            simulationSpeed = speedScrollBar.Value;
            speedLabel.Text = "Simulation speed: " + simulationSpeed;
            timer.Interval = simulationSpeed;
        }
        private void generationLabelUpdate()
        {
            generationLabel.Text = "Generation: " + generation;
        }
        private void generationLabelReset()
        {
            generation = 0;
            generationLabelUpdate();
        }
    }
}