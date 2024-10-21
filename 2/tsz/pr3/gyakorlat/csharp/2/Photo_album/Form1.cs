using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photo_album
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Album a1 = new Album();
            Album a2 = new Album(24);
            Album a3 = new BigAlbum();
            textBox1.Clear();
            textBox1.AppendText("Number of pages in album 1: " + a1.getNumOfPages() + "\r\n");
            textBox1.AppendText("Number of pages in album 2: " + a2.getNumOfPages() + "\r\n");
            textBox1.AppendText("Number of pages in big album 3: " + a3.getNumOfPages() + "\r\n");

        }
    }
}
