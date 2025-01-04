using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
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
        public void SetState(CellState state)
        {
            this.State = state;
            switch (state)
            {
                case CellState.Alive:
                    this.BackColor = Color.Black;
                    break;
                case CellState.Dead:
                    this.BackColor = Color.White;
                    break;
                case CellState.Suspended:
                    this.BackColor = Color.Gray;
                    break;
            }
        }
    }
}