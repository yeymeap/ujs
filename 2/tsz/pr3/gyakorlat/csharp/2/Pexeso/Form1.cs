using Pexeso.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pexeso
{
    public partial class Form1 : Form
    {
        private Card[,] cards = new Card[4, 4];
        private Card card1, card2;
        private Random rnd = new Random();
        private int cardsFound = 0;
        private Bitmap[] images = { Properties.Resources.kep0, Properties.Resources.kep1,
                                    Properties.Resources.kep2, Properties.Resources.kep3,
                                    Properties.Resources.kep4, Properties.Resources.kep5,
                                    Properties.Resources.kep6, Properties.Resources.kep7}; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int k = 0;
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    cards[i, j] = new Card(images[k / 2]);
                    k++;
                    cards[i, j].Location = new Point(Card.SIZE * j, Card.SIZE * i);
                    cards[i,j].Click += new EventHandler(Clicked);
                    this.Controls.Add(cards[i, j]);
                }
            }
            this.ClientSize = new Size(4 * Card.SIZE, 4 * Card.SIZE);
            Shuffle();
        }

        private void Shuffle()
        {
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    int m = rnd.Next(0, 4);
                    int n = rnd.Next(0, 4);
                    cards[i, j].Change(cards[m, n]);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (card1.Check(card2))
            {
                card1.Visible = false;
                card2.Visible = false;
                cardsFound++;
            }
            card1.ShowCard();
            card2.ShowCard();
            card1 = null;
            card2 = null;
            if(cardsFound == 8)
            {
                Restart();
            }
        }
       
        private void Restart()
        {
            cardsFound = 0;
            for(int i = 0;i < 4; i++)
            {
                for(int j = 0;j < 4; j++)
                {
                    cards[i, j].Visible = true;
                }
            }
            Shuffle();
        }

        private void Clicked(object sender, EventArgs e)
        {
            Card c = (Card)sender;
            if (card1 == null)
            {
                card1 = c;
                card1.ShowCard();
            }
            else if (card2 == null && card1 != c)
            {
                card2 = c;
                card2.ShowCard();
                timer1.Start();
            }
        }
    }
}
