using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blue_Buttons
{
    public partial class Form1 : Form
    {
        private Button[] buttons = new Button[16];
        private int rows = 4;
        private int cols = 4;
        private int buttonSize = 100;
        Random random = new Random();
        private Timer timer = new Timer();
        private int counter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += new EventHandler(TimerTick);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    buttons[i * cols + j] = new Button();
                    buttons[i * cols + j].Size = new Size(buttonSize, buttonSize);
                    buttons[i * cols + j].Location = new Point(j * buttonSize, i * buttonSize);
                    buttons[i * cols + j].Click += button_Click;
                    buttons[i * cols + j].BackColor = Color.Blue;
                    buttons[i * cols + j].Visible = false;
                    this.Controls.Add(buttons[i * cols + j]);
                }
            }
            this.ClientSize = new Size(cols * buttonSize, rows * buttonSize);
            this.Text = "Click on all of the buttons!";
            int randomButton = random.Next(0, 16);
            buttons[randomButton].Visible = true;
            counter++;
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Visible = false;
            counter--;
            if (counter == 0)
            {
                timer.Stop();
                MessageBox.Show("You won!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                foreach (Button b in buttons)
                {
                    b.Visible = false;
                }
                counter = 0;
                timer.Start();
            }
        }
        private void TimerTick(object sender, EventArgs e)
        {
            int randomButton;
            do
            {
                randomButton = random.Next(0, 16);
            } while(buttons[randomButton].Visible == true);
            buttons[randomButton].Visible = true;
            counter++;
            if (counter == 16)
            {
                timer.Stop();
                MessageBox.Show("You lost!", "Try again!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                foreach (Button button in buttons)
                {
                    button.Visible = false;
                }
                counter = 0;
                timer.Start();
            }
        }
    }
}
