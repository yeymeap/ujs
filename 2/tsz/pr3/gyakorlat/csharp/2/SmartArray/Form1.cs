using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartArray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SmartArray sa1 = new SmartArray(10);
            SmartArray sa2 = new SmartArray(15);
            int[] t = sa1.GetSmartArray();
            textBox1.Clear();
            // okostömb elemeinek lekérdezése és kiírása textboxba
            sa1.WriteOut(textBox1);
            // okostömb feltöltése
            sa1.Generate();
            sa1.WriteOut(textBox1);
            sa1.Generate(200,900);
            sa1.WriteOut(textBox1);
            textBox1.AppendText("Min: " + sa1.Min() + "\r\n");
            textBox1.AppendText("Max: " + sa1.Max() + "\r\n");
            textBox1.AppendText("Sum: " + sa1.Sum() + "\r\n");
            textBox1.AppendText("Average: " + sa1.Average() + "\r\n");
        }
    }
}
