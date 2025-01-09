using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buttoncolorer
{
    public partial class Form1 : Form
    {
        private const int rows = 10;
        private const int cols = 15;
        private int rowHeight = 30;
        private Button[,] buttons = new Button[rows, cols];
        private Button clearButton;
        private int buttonSize = 30;
        private int customButtonSize = 100;
        private List<RadioButton> radioButtons = new List<RadioButton>();
        private Color selectedColor = Color.Red;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddRadioButtons();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(buttonSize, buttonSize);
                    buttons[i, j].Location = new Point(j * buttonSize, i * buttonSize + rowHeight);
                    buttons[i, j].BackColor = Color.White;
                    buttons[i, j].Click += new EventHandler(buttonClick);
                    this.Controls.Add(buttons[i, j]);
                }
            }
            clearButton = new Button()
            {
                Size = new Size(customButtonSize, rowHeight),
                Location = new Point(cols * buttonSize - customButtonSize, 0),
                Text = "Clear",
            };
            clearButton.Click += new EventHandler(clearClick);
            this.Controls.Add(clearButton);
            this.ClientSize = new Size(cols * buttonSize, rows * buttonSize + rowHeight);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(button.BackColor == selectedColor)
            {
                button.BackColor = Color.White;
            }
            else
            {
                button.BackColor = selectedColor;
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
        private void radioChecked(object sender, EventArgs e)
        {
            if (radioButtons[0].Checked)
            {
                selectedColor = Color.Red;
            }
            else if (radioButtons[1].Checked)
            {
                selectedColor = Color.Green;
            }
            else if (radioButtons[2].Checked)
            {
                selectedColor = Color.Blue;
            }
            else if (radioButtons[3].Checked)
            {
                selectedColor = Color.Yellow;
            }
        }
        private void AddRadioButtons()
        {
            int radioLength = 60;
            int radioHeight = 30;
            int xStart = 10;
            RadioButton radio1 = new RadioButton()
            {
                Text = "Red",
                Size = new Size(radioLength, radioHeight),
                Location = new Point(xStart, 0),
                TextAlign = ContentAlignment.MiddleCenter,
                Checked = true,
            };
            RadioButton radio2 = new RadioButton()
            {
                Text = "Green",
                Size = new Size(radioLength, radioHeight),
                Location = new Point(xStart += radioLength, 0),
                TextAlign = ContentAlignment.MiddleCenter,
            };
            RadioButton radio3 = new RadioButton()
            {
                Text = "Blue",
                Size = new Size(radioLength, radioHeight),
                Location = new Point(xStart += radioLength, 0),
                TextAlign = ContentAlignment.MiddleCenter,
            };
            RadioButton radio4 = new RadioButton()
            {
                Text = "Yellow",
                Size = new Size(radioLength, radioHeight),
                Location = new Point(xStart += radioLength, 0),
                TextAlign = ContentAlignment.MiddleCenter,
            };
            radioButtons.Add(radio1);
            radioButtons.Add(radio2);
            radioButtons.Add(radio3);
            radioButtons.Add(radio4);
            foreach (RadioButton radio in radioButtons)
            {
                radio.CheckedChanged += new EventHandler(radioChecked);
                this.Controls.Add(radio);
            }
        }
    }
}
