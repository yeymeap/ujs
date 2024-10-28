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
            x = rnd.NextDouble() * (xMax - Xmin) + Xmin;
            y = rnd.NextDouble() * (yMax - yMin) + yMin;
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
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

    }
}
