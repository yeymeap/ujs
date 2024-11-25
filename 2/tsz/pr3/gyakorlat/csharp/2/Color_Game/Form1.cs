using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_Game
{
    public partial class Form1 : Form
    {
        private Button[] SmallButtons = new Button[12];
        private Button[] BigButtons = new Button[4];
        private Random  rnd = new Random();
        private Color[] colors = { Color.Red, Color.Yellow, Color.Green, Color.Blue };
        private int ActualSmallButton = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // kisgombok
            for (int i = 0; i < SmallButtons.Length; i++)
            {
                SmallButtons[i] = new Button();
                SmallButtons[i].Size = new Size(40, 40);
                SmallButtons[i].Location = new Point(10 + i * 40, 10);
                this.Controls.Add(SmallButtons[i]);
            }
            GenerateColors();
            // nagygombok
            for (int i = 0; i < BigButtons.Length; i++)
            {
                BigButtons[i] = new Button();
                BigButtons[i].Size = new Size(120, 80);
                BigButtons[i].Location = new Point(10 + i * 120, 60);
                BigButtons[i].BackColor = colors[i];
                BigButtons[i].Click += new EventHandler(BigButtons_Click);
                this.Controls.Add(BigButtons[i]);
            }
        }

        private void BigButtons_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if(b.BackColor == SmallButtons[ActualSmallButton].BackColor)
            {
                SmallButtons[ActualSmallButton].Visible = false;
                ActualSmallButton++;
                if(ActualSmallButton > 11)
                {
                    MessageBox.Show("Siker!", "Játék vége", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    for(int i = 0; i < SmallButtons.Length; i++)
                    {
                        SmallButtons[i].Visible = true;
                    }
                    GenerateColors();
                    ActualSmallButton = 0;
                }
            }
            else
            {
                for (int i = 0; i < SmallButtons.Length; i++)
                {
                    SmallButtons[i].Visible = true;
                }
                ActualSmallButton = 0;
            }
        }
        private void GenerateColors()
        {
            for(int i = 0; i < SmallButtons.Length; i++)
            {
                int r = rnd.Next(4);
                SmallButtons[i].BackColor = colors[r];
            }
        }
    }
}