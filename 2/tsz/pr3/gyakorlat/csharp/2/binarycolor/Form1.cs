using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace binarycolor
{
    public partial class Form1 : Form
    {
        private RadioButton radio1;
        private RadioButton radio2;
        private const int rows = 10;
        private const int cols = 15;
        private int rowHeight = 30;
        private Button[,] buttons = new Button[rows, cols];
        private int buttonSize = 30;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++)
                {
                    Button b = buttons[i, j];
                    b = new Button();
                    b.Size = new Size(buttonSize, buttonSize);
                    b.Location = new Point(j * buttonSize, i * buttonSize + rowHeight);
                    b.BackColor = Color.White;
                    b.Text = "0";
                    b.Click += new EventHandler(buttonClick);
                    this.Controls.Add(b);
                }
            }
            radio1 = new RadioButton()
            {
                Text = "0/1",
                Location = new Point(10, 10),
                Checked = true,
                AutoSize = true
            };
            radio1.CheckedChanged += new EventHandler(radio1Checked);
            this.Controls.Add(radio1);
            radio2 = new RadioButton()
            {
                Text = "Color",
                Location = new Point(60, 10),
                AutoSize = true
            };
            radio2.CheckedChanged += new EventHandler(radio2Checked);
            this.Controls.Add(radio2);
            this.Text = "Binary Color";
            this.ClientSize = new Size(cols * buttonSize, rows * buttonSize + rowHeight);
        }
        private void buttonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (radio1.Checked)
            {
                if (b.Text == "0")
                {
                    b.Text = "1";
                }
                else if(b.Text == "1") 
                {
                    b.Text = "0";
                }
            }
            else if(radio2.Checked) 
            {
                if (b.BackColor == Color.White)
                {
                    b.BackColor = Color.Black;
                }
                else if(b.BackColor == Color.Black)
                {
                    b.BackColor = Color.White;
                }

            }
        }
        private void radio1Checked(object sender, EventArgs e)
        {
            if (radio1.Checked)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Button b = buttons[i, j];
                        if (b.BackColor == Color.White)
                        {
                            b.Text = "0";
                            //b.BackColor = Color.White;
                        }
                        else if (b.BackColor == Color.Black)
                        {
                            b.Text = "1";
                            b.BackColor = Color.White;
                        }
                    }
                }
            }
        }
        private void radio2Checked(object sender, EventArgs e)
        {
            if (radio2.Checked)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Button b = buttons[i, j];
                        if (b.Text == "0")
                        {
                            b.BackColor = Color.White;
                        }
                        else if (b.Text == "1")
                        {
                            b.BackColor = Color.Black;
                        }
                        b.Text = "";
                    }
                }
            }
        }
    }
}
