using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace colorgames
{
    public partial class Form1 : Form
    {
        private Button[] smallButtons = new Button[12];
        private Button[] bigButton = new Button[4];
        private int smallButtonIndex = 0;
        private Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Yellow };
        private Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(500, 200);
            for (int i = 0; i < smallButtons.Length; i++)
            {
                smallButtons[i] = new Button();
                smallButtons[i].Size = new Size(40, 40);
                smallButtons[i].Location = new Point(10 + i * 40, 10);
                this.Controls.Add(smallButtons[i]);
            }
            GenerateColors();
            for(int i = 0; i < bigButton.Length; i++)
            {
                bigButton[i] = new Button();
                bigButton[i].Size = new Size(100, 100);
                bigButton[i].Location = new Point(i * 120, 60);
                bigButton[i].BackColor = colors[i];
                this.Controls.Add(bigButton[i]);
                bigButton[i].Click += new EventHandler(bigButton_Click);
            }
        }
        private void bigButton_Click( object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.BackColor == smallButtons[smallButtonIndex].BackColor)
            {
                smallButtons[smallButtonIndex].Visible = false;
                smallButtonIndex++;
                if (smallButtonIndex == smallButtons.Length)
                {
                    MessageBox.Show("Congratulations!", "You win!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    for (int i = 0; i < smallButtons.Length; i++)
                    {
                        smallButtons[i].Visible = true;
                    }
                    GenerateColors();
                    smallButtonIndex = 0;
                }
            }
            else
            {
                for(int i = 0; i < smallButtons.Length; i++)
                {
                    smallButtons[i].Visible = true;
                }
                smallButtonIndex = 0;
            }
        }
        private void GenerateColors()
        {
            for (int i = 0; i < smallButtons.Length; i++)
            {
                int r = rnd.Next(4);
                smallButtons[i].BackColor = colors[r];
            }
        }
    }
}
