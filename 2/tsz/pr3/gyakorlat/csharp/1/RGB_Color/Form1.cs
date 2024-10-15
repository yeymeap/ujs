using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RGB_Color
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            hScrollBar1.Minimum = 0;
            hScrollBar1.Maximum = 255;
            hScrollBar2.Minimum = 0;
            hScrollBar2.Maximum = 255;
            hScrollBar3.Minimum = 0;
            hScrollBar3.Maximum = 255;

        }

    private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int r = hScrollBar1.Value;
            label2.Text = "Red: " + r;
            label1.BackColor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            int g = hScrollBar2.Value;
            label3.Text = "Green: " + g;
            label1.BackColor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);

        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            int b = hScrollBar3.Value;
            label4.Text = "Blue: " + b;
            label1.BackColor = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
