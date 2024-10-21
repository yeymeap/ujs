using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Triangle t1 = new Triangle((int)numericUpDown1.Value, (int)numericUpDown2.Value, (int)numericUpDown3.Value);
            textBox1.Clear();
            textBox1.AppendText("a = " + t1.GetA() + "\r\nb = " + t1.GetB() + "\r\nc = " + t1.getC() + "\r\n");

            if (t1.Isosceles())
            {
                textBox1.AppendText("Isosceles triangle\r\n");
            }
            else
            {
                textBox1.AppendText("Not an Isosceles triangle\r\n");
            }

            if (t1.Equilateral())
            {
                textBox1.AppendText("Equilateral triangle\r\n");
            }
            else
            {
                textBox1.AppendText("Not an Equilateral triangle\r\n");
            }
            textBox1.AppendText("Perimeter = " + t1.Perimeter() + "\r\n");
            textBox1.AppendText("Area = " + t1.Area() + "\r\n");

        }
    }
}
