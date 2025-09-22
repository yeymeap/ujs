using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;

namespace PGG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void buttonRGB_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;

            if(pictureBox2.Image != null)
            {
                pictureBox2.Image.Dispose();
            }

            pictureBox2.Image = ColorFilter((Bitmap)pictureBox1.Image, button.Text.ToLower());
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Color color = GetPixelAtClick((PictureBox)sender, e);
            if (color != Color.Empty)
            {
                label1.Text = $"RGB = ({color.R}, {color.G}, {color.B})";
            }

        }
        private Color GetPixelAtClick(PictureBox pictureBox, MouseEventArgs e)
        {
            if (pictureBox == null || pictureBox1.Image == null)
            {
                return Color.Empty;
            }

            Bitmap bmp = (Bitmap)pictureBox1.Image;

            int x = e.X * bmp.Width / pictureBox1.Width;
            int y = e.Y * bmp.Height / pictureBox1.Height;

            if (x >= 0 && x < bmp.Width && y >= 0 && y < bmp.Height)
            {
                Color color = bmp.GetPixel(x, y);
                return color;
            }
            return Color.Empty;
        }

        private Bitmap ColorFilter(Bitmap original, string channel)
        {
            if(original == null)
            {
                return null;
            }

            Bitmap filtered = new Bitmap(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color pixel = original.GetPixel(x, y);
                    int r = 0;
                    int g = 0;
                    int b = 0;
                    int value = 0;
                    switch (channel)
                    {
                        case "red":
                            r = pixel.R;
                            value = pixel.R;
                            break;
                        case "green":
                            value = pixel.G;
                            g = pixel.G;
                            break;
                        case "blue":
                            value = pixel.B;
                            b = pixel.B;
                            break;
                    }
                    //filtered.SetPixel(x, y, Color.FromArgb(r, g, b));
                    filtered.SetPixel(x, y, Color.FromArgb(value, value, value));
                }
            }
            return filtered;
        }
    }
}
