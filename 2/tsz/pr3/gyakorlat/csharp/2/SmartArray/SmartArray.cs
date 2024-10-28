using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartArray
{
    internal class SmartArray
    {
        private static Random rnd = new Random(); // static, tehát az osztály objektumainak egy közöse lesz
        private int[] numbers;
        public SmartArray(int size) 
        {
            numbers = new int[size];
        }
        public int[] GetSmartArray()
        {
            return numbers;
        }
        public void WriteOut(TextBox tbox)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                tbox.AppendText(numbers[i] + ", ");
            }
            tbox.AppendText("\r\n");
        }
        public void Generate() 
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(0, 101);
            }
        }
        public void Generate(int min, int max)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(min, max);
            }
        }
        public int Min()
        {
            return numbers.Min();
        }
        public int Max()
        {
            return numbers.Max();
        }
        public int Sum()
        {
            return numbers.Sum();
        }
        public double Average()
        {
            return numbers.Average();
        }

    }
}
