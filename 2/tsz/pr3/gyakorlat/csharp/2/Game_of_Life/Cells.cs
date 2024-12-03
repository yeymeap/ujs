using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_Life
{
    internal class Cells : Button
    {
        public const int SIZE = 20;
        private bool alive = false;
        private bool isMouseDown = false;
        
        public Cells()
        {
            this.Size = new Size(SIZE, SIZE);
            this.BackColor = Color.White;
        }

        public void Alive()
        {
            this.alive = true;
            this.BackColor = Color.Black;
        }

        public void Dead()
        {
            this.alive = false;
            this.BackColor = Color.White;
        }
    }
}
