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

namespace Guess_random_number
{

    public partial class Form1 : Form
    {
        private Random randgen = new Random();
        private int gondoltSzam;

        public Form1()
        {
            InitializeComponent();
            gondoltSzam = randgen.Next(1,51);
            Console.WriteLine(gondoltSzam);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) > gondoltSzam)
            {
                label1.Text = ("Kisebb számra gondoltam");
            }
            else if (Convert.ToInt32(textBox1.Text) < gondoltSzam)
            {
                label1.Text = ("Nagyobb számra gondoltam");
            }
            else if (Convert.ToInt32(textBox1.Text) == gondoltSzam)
            {
                label1.Text = ("Eltaláltad, új számra gondoltam");
                gondoltSzam = randgen.Next(1, 51);
                Console.WriteLine(gondoltSzam);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
