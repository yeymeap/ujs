using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
            if (pictureBox1.Image != null)
            {
                labelWidth.Text = $"Width: {pictureBox1.Image.Width} px";
                labelHeight.Text = $"Height: {pictureBox1.Image.Height} px";
            }
        }
        private void checkR_CheckedChanged(object sender, EventArgs e) => UpdateRGBFilter();
        private void checkG_CheckedChanged(object sender, EventArgs e) => UpdateRGBFilter();
        private void checkB_CheckedChanged(object sender, EventArgs e) => UpdateRGBFilter();

        private void buttonGray_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pictureBox2.Image = ColorFilterGray((Bitmap)pictureBox1.Image, button.Text.ToLower());
        }
        private void buttonNegative_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pictureBox2.Image = ColorFilterNegative((Bitmap)pictureBox1.Image);
        }
        private void buttonBrightness_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int brightness = 0;
            if (button.Text == "+")
            {
                brightness = 20;
            }
            else if (button.Text == "-")
            {
                brightness = -20;
            }
            pictureBox2.Image = AdjustBrightness((Bitmap)pictureBox1.Image, brightness);
        }
        private void buttonContrast_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            float contrast = 1.0f;
            if (button.Text == "*")
            {
                contrast = 1.2f;
            }
            else if (button.Text == "/")
            {
                contrast = 0.8f;
            }
            pictureBox2.Image = AdjustContrast((Bitmap)pictureBox1.Image, contrast);
        }
        private void buttonSobel_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pictureBox2.Image = ApplySobel((Bitmap)pictureBox1.Image);
        }
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if(pictureBox2.Image == null)
            {
                return;
            }
            Bitmap bmp = (Bitmap)pictureBox2.Image;
            pictureBox1.Image = bmp;
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (pictureBox2.Image != null)
            {
                pictureBox2.Image.Dispose();
                pictureBox2.Image = null;
            }
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select an image";
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(dialog.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            labelWidth.Text = $"Width: {pictureBox1.Image.Width} px";
            labelHeight.Text = $"Height: {pictureBox1.Image.Height} px";
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("No image to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Save image as...";
                dialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp|GIF Image|*.gif";
                dialog.DefaultExt = "png";
                dialog.AddExtension = true;
                dialog.OverwritePrompt = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                    string ext = System.IO.Path.GetExtension(dialog.FileName).ToLower();
                    switch (ext)
                    {
                        case ".jpg":
                        case ".jpeg":
                            format = System.Drawing.Imaging.ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = System.Drawing.Imaging.ImageFormat.Bmp;
                            break;
                        case ".gif":
                            format = System.Drawing.Imaging.ImageFormat.Gif;
                            break;
                    }

                    pictureBox2.Image.Save(dialog.FileName, format);
                }
            }
        }
        private void buttonBlackWhite_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pictureBox2.Image = ColorFilterBlackWhite((Bitmap)pictureBox1.Image);
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Color color = GetPixelAtClick((PictureBox)sender, e);
            if (color != Color.Empty)
            {
                labelR.Text = $"R = {color.R}"; 
                labelG.Text = $"G = {color.G}";
                labelB.Text = $"B = {color.B}";
            }
            panelSelected.BackColor = color;
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
        private void UpdateRGBFilter()
        {
            if (pictureBox1.Image == null)
            {
                return;
            }
            if (pictureBox2.Image != null)
            {
                var old = pictureBox2.Image;
                pictureBox2.Image = null;
                //old.Dispose();
            }
            pictureBox2.Image = ColorFilterRGB((Bitmap)pictureBox1.Image, checkR.Checked, checkG.Checked, checkB.Checked);
        }
        private Bitmap ColorFilterRGB(Bitmap original, bool useR, bool useG, bool useB)
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
                    int r = useR ? pixel.R : 0;
                    int g = useG ? pixel.G : 0;
                    int b = useB ? pixel.B : 0;
                    filtered.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return filtered;
        }
        private Bitmap ColorFilterGray(Bitmap original, string channel)
        {
            if (original == null)
            {
                return null;
            }

            Bitmap filtered = new Bitmap(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color pixel = original.GetPixel(x, y);
                    int value = 0;
                    switch (channel)
                    {
                        case "r gray":
                            value = pixel.R;
                            break;
                        case "g gray":
                            value = pixel.G;
                            break;
                        case "b gray":
                            value = pixel.B;
                            break;
                    }
                    filtered.SetPixel(x, y, Color.FromArgb(value, value, value));
                }
            }
            return filtered;
        }
        private Bitmap ColorFilterNegative(Bitmap original)
        {
            if (original == null)
            {
                return null;
            }

            Bitmap negative = new Bitmap(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color pixel = original.GetPixel(x, y);
                    Color inv = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
                    negative.SetPixel(x, y, inv);
                }
            }
            return negative;
        }
        private Bitmap ColorFilterBlackWhite(Bitmap grayImage)
        {
            if (grayImage == null)
            {
                return null;
            }
            Bitmap bw = new Bitmap(grayImage.Width, grayImage.Height);
            for (int x = 0; x < grayImage.Width; x++)
            {
                for (int y = 0; y < grayImage.Height; y++)
                {
                    Color pixel = grayImage.GetPixel(x, y);
                    Color bwColor = (pixel.R < 128) ? Color.Black : Color.White;
                    bw.SetPixel(x, y, bwColor);
                }
            }
            return bw;
        }
        private Bitmap AdjustBrightness(Bitmap original, int brightness)
        {
            if (original == null) return null;

            Bitmap adjusted = new Bitmap(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color pixel = original.GetPixel(x, y);

                    int r = Math.Min(255, Math.Max(0, pixel.R + brightness));
                    int g = Math.Min(255, Math.Max(0, pixel.G + brightness));
                    int b = Math.Min(255, Math.Max(0, pixel.B + brightness));

                    adjusted.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return adjusted;
        }
        private Bitmap AdjustContrast(Bitmap original, float contrast)
        {
            if (original == null) return null;

            Bitmap adjusted = new Bitmap(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    Color pixel = original.GetPixel(x, y);

                    int r = (int)(((pixel.R - 128) * contrast) + 128);
                    int g = (int)(((pixel.G - 128) * contrast) + 128);
                    int b = (int)(((pixel.B - 128) * contrast) + 128);

                    r = Math.Min(255, Math.Max(0, r));
                    g = Math.Min(255, Math.Max(0, g));
                    b = Math.Min(255, Math.Max(0, b));

                    adjusted.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return adjusted;
        }
        private Bitmap ApplyConvolution(Bitmap original, int[,]kernel)
        {
            Bitmap result = new Bitmap(original.Width, original.Height);

            int kCenter = kernel.GetLength(0) / 2;
            for (int y = kCenter; y < original.Height - kCenter; y++)
            {
                for (int x = kCenter; x < original.Width - kCenter; x++)
                {
                    int sum = 0;

                    for (int ky = -kCenter; ky <= kCenter; ky++)
                    {
                        for (int kx = -kCenter; kx <= kCenter; kx++)
                        {
                            Color c = original.GetPixel(x + kx, y + ky);
                            int gray = (c.R + c.G + c.B) / 3;
                            sum += gray * kernel[ky + kCenter, kx + kCenter];
                        }
                    }

                    sum = Math.Min(Math.Max(sum, 0), 255);
                    result.SetPixel(x, y, Color.FromArgb(sum, sum, sum));
                }
            }
            return result;
        }
        private Bitmap ApplySobel(Bitmap original)
        {
            int[,] sobelX = new int[,]
            {
                { -1, 0, 1 },
                { -2, 0, 2 },
                { -1, 0, 1 }
            };
            int[,] sobelY = new int[,]
            {
                { -1, -2, -1 },
                { 0, 0, 0 },
                { 1, 2, 1 }
            };
            Bitmap gx = ApplyConvolution(original, sobelX);
            Bitmap gy = ApplyConvolution(original, sobelY);

            Bitmap result = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    int px = gx.GetPixel(x, y).R;
                    int py = gy.GetPixel(x, y).R;
                    int magnitude = (int)Math.Min(Math.Sqrt(px * px + py * py), 255);
                    result.SetPixel(x, y, Color.FromArgb(magnitude, magnitude, magnitude));
                }
            }
            return result;
        }
    }
}
