using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            double price = 2.5;
            if (checkBox1.Checked) { price += 0.8; }
            if (checkBox2.Checked) { price += 0.7; }
            if (checkBox3.Checked) { price += 0.75; }
            if (checkBox4.Checked) { price += 0.6; }
            if (checkBox5.Checked) { price += 0.45; }
            label2.Text = "Pizza ára: " + price.ToString("0.00") + "EUR";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
