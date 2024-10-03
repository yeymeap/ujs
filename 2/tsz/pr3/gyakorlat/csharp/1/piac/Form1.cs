using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace piac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            double total = 0;
            double bprice = 1.2;
            double rprice = 0.99;
            double kprice = 0.75;
            double bamount = Convert.ToDouble(textBox1.Text);
            double ramount = Convert.ToDouble(textBox2.Text);
            double kamount = Convert.ToDouble(textBox3.Text);
            total = bprice * bamount + rprice * ramount + kprice * kamount;
            total = Math.Round(total, 2);
            label5.Text = Convert.ToString(total);
        }
    }
}
