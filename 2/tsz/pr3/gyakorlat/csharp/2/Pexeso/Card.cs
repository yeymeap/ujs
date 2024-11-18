using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pexeso
{
    internal class Card: Button
    {
        public const int SIZE = 128;
        private bool show = false;
        private Bitmap image;

        public Card(Bitmap image)
        {
            this.image = image;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Size  = new Size(SIZE, SIZE);
            this.BackgroundImage = Properties.Resources.hatter;
        }

        public void Change(Card c)
        {
            Bitmap bmp = this.image;
            this.image = c.image;
            c.image = bmp;
        }

        public bool Check(Card c)
        {
            return this.image == c.image;
        }

        public void ShowCard()
        {
            show = !show;
            if (show)
            {
                // kep megjelenitese
                this.BackgroundImage = this.image;
            }
            else
            {
                // hatter megjelenitese
                this.BackgroundImage = Properties.Resources.hatter;
            }
        }
    }
}
