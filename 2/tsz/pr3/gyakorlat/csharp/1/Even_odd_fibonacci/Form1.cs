using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            for (int i = 0; i < 10; i += 2)
            {
                string pair = Convert.ToString(i);
                label1.Text += pair + ", ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            for (int i = 1; i < 10; i += 2)
            {
                string odd = Convert.ToString(i);
                label1.Text += odd + ", ";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            for (int i = 0; i < 10; i++)
            {
                string fibonacci = Convert.ToString(i);
                label1.Text += fibonacci + ", ";
            }
        }
    }
}
