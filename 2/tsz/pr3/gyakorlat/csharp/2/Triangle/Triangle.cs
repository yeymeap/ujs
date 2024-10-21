using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    internal class Triangle
    {
        private int a, b, c;

        public Triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        
        public int GetA(){
            return a;
        }

        public int GetB(){
            return b; 
        }

        public int getC()
        {
            return c;
        }

        public bool Isosceles()
        {
            return (a == b || a == c || b == c);
        }

        public bool Equilateral()
        {
            return (a == b && b == c);
        }

        public int Perimeter()
        {
            return a + b + c;
        }

        public double Area()
        {
            double s = Perimeter() / 2.0;
            double t = Math.Sqrt((s * (s - a) * (s - b) * (s - c)));
            return t;
        }
    }
}
