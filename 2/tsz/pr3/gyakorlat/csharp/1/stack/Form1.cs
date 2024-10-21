using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Error - empty input!");
            }
            else if (listBox1.Items.Count < 10)
            {
                listBox1.Items.Insert(0, textBox2.Text);
                textBox2.Clear();
            }
            else
            {
                MessageBox.Show("Error - stack is full!");
            }
            textBox2.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Error - stack is empty!");
            }
            else
            { 
            textBox2.Text = listBox1.Items[0].ToString();
            listBox1.Items.RemoveAt(0);
            textBox2.Focus();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            textBox2.Focus();
        }
    }
}
