using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slider_calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            hScrollBar1.Maximum = 100;
            hScrollBar1.Minimum = 0;
            hScrollBar2.Maximum = 100;
            hScrollBar2.Minimum = 0;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label1.Text = "Első szám: " + hScrollBar1.Value;
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            label2.Text = "Második szám: " + hScrollBar2.Value;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int sum = hScrollBar1.Value + hScrollBar2.Value;
            label4.Text = "Eredmény: " + sum;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sum = hScrollBar1.Value - hScrollBar2.Value;
            label4.Text = "Eredmény: " + sum;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sum = hScrollBar1.Value * hScrollBar2.Value;
            label4.Text = "Eredmény: " + sum;

        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (hScrollBar2.Value == 0)
            {
                label4.Text = "Nullával nem lehet osztani!";
            }
            else
            {
                double sum = (double)hScrollBar1.Value / hScrollBar2.Value;
                label4.Text = "Eredmény: " + Math.Round(sum, 2);
            }

        }
    }
}
