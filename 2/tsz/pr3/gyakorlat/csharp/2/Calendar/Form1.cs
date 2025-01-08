using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class Form1 : Form
    {
        private Button[] buttons = new Button[24];
        private List<int> ints = new List<int>();
        private int rows = 6;
        private int cols = 4;
        private int size = 50;
        private bool evenodd = true;
        private Random random = new Random();
        int counter = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 24; i++)
            {
                ints.Add(i);
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int randomIndex = random.Next(ints.Count);
                    int randomInt = ints[randomIndex];
                    buttons[i * cols + j] = new Button();
                    buttons[i * cols + j].Size = new Size(size, size);
                    buttons[i * cols + j].Location = new Point(j * size, i * size);
                    buttons[i * cols + j].Click += new EventHandler(buttonClick);
                    buttons[i * cols + j].Text = randomInt.ToString();
                    buttons[i * cols + j].Font = new Font("Arial", 12, FontStyle.Bold);
                    ints.RemoveAt(randomIndex);
                    if (evenodd)
                    {
                        buttons[i * cols + j].BackColor = Color.Red;
                        evenodd = false;
                    }
                    else
                    {
                        buttons[i * cols + j].BackColor = Color.Green;
                        evenodd = true;
                    }
                    this.Controls.Add(buttons[i * cols + j]);
                }
                evenodd = !evenodd;
            }
            this.ClientSize = new Size(cols * size, rows * size);
            this.Text = "Calendar";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == counter.ToString())
            {
                if (counter == 24)
                {
                    button.Text = "\U0001F381";
                    button.BackColor = Color.White;
                    MessageBox.Show("Congratulations!", "You have completed the calendar!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    counter = 1;
                    GenerateButtons();
                }
                else
                {
                    button.Text = "\U0001F381";
                    button.BackColor = Color.White;
                    counter++;
                }
            }
            else if(button.Text == "\U0001F381")
            {
            }
            else if (button.Text != counter.ToString())
            {
                counter = 1;
                GenerateButtons();
            }
        }
        private void GenerateButtons()
        {
            counter = 1;
            ints.Clear();
            for (int i = 1; i <= 24; i++)
            {
                ints.Add(i);
            }
            for (int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    int randomIndex = random.Next(ints.Count);
                    int randomInt = ints[randomIndex];
                    buttons[i * cols + j].Text = randomInt.ToString();
                    ints.RemoveAt(randomIndex);
                    if (evenodd)
                    {
                        buttons[i * cols + j].BackColor = Color.Red;
                        evenodd = false;
                    }
                    else
                    {
                        buttons[i * cols + j].BackColor = Color.Green;
                        evenodd = true;
                    }
                }
                evenodd = !evenodd;
            }
        }
    }
}
