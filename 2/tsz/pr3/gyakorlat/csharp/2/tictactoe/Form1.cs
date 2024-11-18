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

namespace tictactoe
{
    public partial class Form1 : Form
    {
        private Button[,] buttons = new Button[3, 3];
        private string sign = "X";
        private int counter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(150, 150);
                    buttons[i, j].Location = new Point(j * 150, i * 150);
                    buttons[i, j].Font = new Font("Arial", 60, FontStyle.Bold);
                    buttons[i, j].Click += new EventHandler(Clicking);
                    this.Controls.Add(buttons[i, j]);
                }
            }
            this.Text = "TicTacToe";
            this.ClientSize = new Size(450, 450);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        private void Clicking(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == "")
            {
                b.Text = sign;
                counter++;
                if (sign == "X")
                {
                    sign = "O";
                }
                else
                {
                    sign = "X";
                }
                Check();
            }
        }
        private void Check()
        {
            string winner = "";
            for (int i = 0; i < 3; i++)
            {
                if (buttons[i,0].Text != "" && buttons[i,0].Text == buttons[i, 1].Text && buttons[i, 1].Text == buttons[i, 2].Text)
                {
                    winner = buttons[i,0].Text;
                }
                else if(buttons[0, i].Text != "" && buttons[0, i].Text == buttons[1, i].Text && buttons[1, i].Text == buttons[2, i].Text)
                {
                    winner = buttons[0, i].Text;
                }
            }
            if (buttons[0, 0].Text != "" && buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text)
            {
                winner = buttons[0, 0].Text;
            }
            else if (buttons[2, 0].Text != "" && buttons[2, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[0, 2].Text)
            {
                winner = buttons[2, 0].Text;
            }
            if(winner != "")
            {
                MessageBox.Show(winner + " wins!");
                Restart();
            }
            else if (counter == 9)
            {
                MessageBox.Show("Draw!");
                Restart();
            }
        }
        private  void Restart()
        {
            foreach (Button b in buttons)
            {
                b.Text = "";
            }
            counter = 0;
        }
    }
}
