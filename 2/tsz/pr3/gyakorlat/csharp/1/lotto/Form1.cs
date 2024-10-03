using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lotto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int num = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                int numlast = num;
                num = (rnd.Next(91));
                if(num == numlast)
                {
                    num = (rnd.Next(91));
                }
                string numberString = Convert.ToString(num);
                label1.Text = label1.Text + num + ", ";
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
