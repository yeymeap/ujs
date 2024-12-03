using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_Life
{
    public partial class Form1 : Form
    {
        private Cells[,] cell = new Cells[30,30];
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Game of Life";
            int rows = 30;
            int cols = 30;
            int gridWidth = cols * Cells.SIZE;
            int gridHeight = rows * Cells.SIZE;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    cell[i, j] = new Cells();
                    cell[i, j].Location = new Point(Cells.SIZE * j, Cells.SIZE * i);
                    cell[i, j].Click += new EventHandler(Clicked);
                    this.Controls.Add(cell[i, j]);
                }
            }
            GroupBox radioGroup = new GroupBox()
            {
                Text = "Játék fajtája",
                Location = new Point(gridWidth + 10, 10),
                Size = new Size(100, 100)
            };
            string[] options = { "Game of Life", "Brian's Brain", "Seeds" };
            int radioHeight = 20;
            for (int i = 0; i < options.Length; i++)
            {
                RadioButton radio = new RadioButton()
                {
                    Text = options[i],
                    Location = new Point(10, 20 + i * radioHeight),
                    AutoSize = true
                };
                radioGroup.Controls.Add(radio);
            }
            string[] buttons = { "Start", "Stop", "Törlés" };
            int buttonHeight = 30;
            for(int i = 0; i < buttons.Length; i++)
            {
                Button button = new Button()
                {
                    Text = buttons[i],
                    Location = new Point(gridWidth + 10, 120 + i * buttonHeight),
                    Size = new Size(100, 30)
                };
                this.Controls.Add(button);
            }
            this.Controls.Add(radioGroup);  
            this.ClientSize = new Size(gridWidth + radioGroup.Width + 20, Math.Max(gridHeight, radioGroup.Height) + 10);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = true;
            this.MaximizeBox = false;
        }
        private void Clicked(object sender,EventArgs e)
        {
            Cells c = (Cells)sender;
            if (c.BackColor == Color.White)
            {
                c.Alive();
            }
            else
            {
                c.Dead();
            }
        }
    }
}
