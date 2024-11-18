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
            textBox1.Clear();
            Point[] points = new Point[20];
            double TotalDistance = 0;
            int MaxDistanceIndex = 0;
            double MaxDistanceValue;
            int MinDistanceIndex = 0;
            double MinDistanceValue;
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(-100, 100, -50, 50);
                double distance = points[i].DistanceFromOrigin();
                textBox1.AppendText(points[i] + "Distance from origin:" + distance + "\r\n");
                TotalDistance += distance;
                if (distance > points[Convert.ToInt32(MaxDistanceIndex)].DistanceFromOrigin())
                {
                    MaxDistanceIndex = i;
                }
                if(distance < points[Convert.ToInt32(MinDistanceIndex)].DistanceFromOrigin())
                {
                    MinDistanceIndex = i;
                }
            }
            double AverageDistance = Math.Round(TotalDistance / points.Length, 2) ;
            textBox1.AppendText("Average distance: " + AverageDistance + "\r\n");
            MaxDistanceValue = points[Convert.ToInt32(MaxDistanceIndex)].DistanceFromOrigin();
            textBox1.AppendText("Coordinates of furthest point: " + points[Convert.ToInt32(MaxDistanceIndex)] + " Distance from origin: " + MaxDistanceValue + "\r\n");
            MinDistanceValue = points[Convert.ToInt32(MinDistanceIndex)].DistanceFromOrigin();
            textBox1.AppendText("Coordinates of closest point: " + points[Convert.ToInt32(MinDistanceIndex)] + " Distance from origin: " + MinDistanceValue + "\r\n");
        }
    }
}
