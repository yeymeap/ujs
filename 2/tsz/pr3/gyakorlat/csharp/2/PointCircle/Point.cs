using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointCircle
{
    internal class Point
    {
        private double x;
        private double y;
        private static Random rnd = new Random();

        public Point(double x, double y)
        {
          this.x = x;
          this.y = y;
        }
        public Point(int Xmin, int xMax, int yMin, int yMax)
        {
            x = Math.Round(rnd.NextDouble() * (xMax - Xmin) + Xmin, 2);
            y = Math.Round(rnd.NextDouble() * (yMax - yMin) + yMin, 2);
        }
        public double GetX()
        {
            return x;
        }
        public double GetY()
        {
            return y;
        }
        public override string ToString()
        {
            return $"({x},{y})";
        }
        public double DistanceFromOrigin() 
        {
            return Math.Round(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)), 2);
        }

    }
}
