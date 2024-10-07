using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_machine { 


    public partial class Form1 : Form
    
    {
    public Form1()
    {
        InitializeComponent();
    }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            double price = 0;
            if (radioButton1.Checked)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox1.Checked = false;
                price += 0.35;
                if (checkBox2.Checked == true)
                {
                    price += 0.10;
                }
                if(checkBox3.Checked == true)
                {
                    price += 0.05;
                }
                if(checkBox4.Checked == true)
                {
                    price += 0.10;
                }
            }
            if (radioButton2.Checked)
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = false;
                checkBox4.Checked = false;
                price += 0.25;
                if (checkBox1.Checked == true)
                {
                    price += 0.05;
                }
                if (checkBox2.Checked == true)
                {
                    price += 0.10;
                }
                if (checkBox3.Checked == true)
                {
                    price += 0.05;
                }
                
            }
            if (radioButton3.Checked)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = false;
                checkBox1.Checked = false;
                checkBox4.Checked = false;
                price += 0.45;
                if (checkBox2.Checked == true)
                {
                    price += 0.10;
                }
                if (checkBox3.Checked == true)
                {
                    price += 0.05;
                }
            }
            label1.Text = "Fizetendő: " + price.ToString("0.00") + "EUR";
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }
}
}
