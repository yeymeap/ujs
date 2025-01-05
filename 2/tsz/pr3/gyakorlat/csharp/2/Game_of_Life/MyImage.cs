using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_Life
{
    internal class MyImage
    {
        private const int SIZE = 100;
        private PictureBox pictureBox;

        public MyImage(Bitmap image)
        {
            pictureBox = new PictureBox()
            {
                Size = new Size(SIZE, SIZE),
                BorderStyle = BorderStyle.Fixed3D,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = image
            };
        }

        public void ShowImage(Form FormToAdd,Point location)
        {
            pictureBox.Location = location;
            FormToAdd.Controls.Add(pictureBox);
        }

        public void ChangeImage(Bitmap newImage)
        {
            pictureBox.Image = newImage;
        }
    }
}
