using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_games
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
            for(int i = 0; i < smallButtons.Length; i++)
            {
                smallButtons[i] = new Button();
                smallButtons[i].Size = new Size(40, 40);
                smallButtons[i].Location = new Point(10 + i * 40, 10);
                this.Controls.Add(smallButtons[i]);
            }
            GenerateColors();
        }

        private void GenerateColors()
        {
            for(int i = 0; i < smallButtons.Length ; i++)
            {
                int r = rnd.Next(4);
                smallButtons[i].BackColor = colors[r];
            }
        }
    }
}
