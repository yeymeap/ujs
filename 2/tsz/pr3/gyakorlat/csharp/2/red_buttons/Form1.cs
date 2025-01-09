using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace red_buttons
{
    public partial class Form1 : Form
    {
        private const int rows = 10;
        private const int cols = 13;
        private int buttonSize = 30;
        private int rowHeight = 30;
        private int customButtonSize = 80;
        private Button[,] buttons = new Button[rows, cols];
        private Button clearButton;
        private Button redButton;
        private List<Button> customButtons = new List<Button>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(buttonSize, buttonSize);
                    buttons[i, j].Location = new Point(i * buttonSize, rowHeight + j * buttonSize);
                    buttons[i, j].BackColor = Color.White;
                    buttons[i, j].Click += new EventHandler(buttonClick);
                    this.Controls.Add(buttons[i, j]);
                }
            }
            clearButton = new Button()
            {
                Size = new Size(customButtonSize, rowHeight),
                Location = new Point(0, 0),
                Text = "Clear",
            };
            redButton = new Button()
            {
                Size = new Size(customButtonSize, rowHeight),
                Location = new Point(customButtonSize + 5, 0),
                Text = "Red"
            };
            clearButton.Click += new EventHandler(clearClick);
            redButton.Click += new EventHandler(redClick);
            this.Controls.Add(clearButton);
            this.Controls.Add(redButton);
            this.ClientSize = new Size(rows * buttonSize, cols * buttonSize + rowHeight);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.BackColor == Color.White)
            {
                button.BackColor = Color.Black;
            }
            else if(button.BackColor == Color.Red)
            {
                button.BackColor = Color.Black;
            }
            else
            {
                button.BackColor = Color.White;
            }
        }
        private void clearClick(object sender, EventArgs e)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    buttons[i, j].BackColor = Color.White;
                }
            }
        }
        private void redClick(object sender, EventArgs e)
        {
            List<Button> redButtons = new List<Button>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (buttons[i, j].BackColor == Color.Black)
                    {
                        AddValidNeighbour(i - 1, j, redButtons);
                        AddValidNeighbour(i + 1, j, redButtons);
                        AddValidNeighbour(i, j - 1, redButtons);
                        AddValidNeighbour(i, j + 1, redButtons);
                    }
                }
            }
            foreach(Button button in redButtons)
            {
                button.BackColor = Color.Red;
            }
        }
        private void AddValidNeighbour(int row, int col, List<Button> neighbours)
        {
            if(row >= 0 && row < rows && col >= 0 && col < cols && buttons[row, col].BackColor != Color.Black)
            {
                neighbours.Add(buttons[row, col]);
            }
        }
    }
}
