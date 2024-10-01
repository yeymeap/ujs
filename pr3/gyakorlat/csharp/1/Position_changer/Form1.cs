using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int szamlalo = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (szamlalo == 0)
            {
                szamlalo++;
                button1.Location = new Point(this.ClientSize.Width - button1.Width, 0);
            }
            else if (szamlalo == 1)
            {
                szamlalo++;
                button1.Location = new Point(this.ClientSize.Width - button1.Width, this.ClientSize.Height - button1.Height);
            }
            else if (szamlalo == 2)
            {
                szamlalo++;
                button1.Location = new Point(0, this.ClientSize.Height - button1.Height);
            }
            else if (szamlalo == 3)
            {
                szamlalo = 0;
                button1.Location = new Point(0, 0);
            }
        }
    }
}
