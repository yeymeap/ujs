using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointCircle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Point[] points = new Point[20];
            double TotalDistance = 0;
            double MaxDistance = 0;
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(-100, 100, -50, 50);
                double distance = points[i].DistanceFromOrigin();
                textBox1.AppendText(points[i] + "Distance from origin:" + distance + "\r\n");
                TotalDistance += distance;
            }
            double AverageDistance = Math.Round(TotalDistance / points.Length, 2) ;
            textBox1.AppendText("Átlagos távolság: " + AverageDistance + "\r\n");

        }
    }
}
