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
        internal enum CellState
        {
            Dead,
            Alive,
            Suspended
        }
        private CellState State = CellState.Dead;
        public const int SIZE = 20;
        private bool isMouseDown = false;
        
        public Cells()
        {
            this.Size = new Size(SIZE, SIZE);
            this.BackColor = Color.White;
        }

        public void SetAlive()
        {
            this.State = CellState.Alive;
            this.BackColor = Color.Black;
        }

        public void SetDead()
        {
            this.State = CellState.Dead;
            this.BackColor = Color.White;
        }
        public void SetSuspended()
        {
            this.State = CellState.Suspended;
            this.BackColor = Color.Gray;
        }
        public CellState GetState()
        {
            return this.State;
        }
    }
}