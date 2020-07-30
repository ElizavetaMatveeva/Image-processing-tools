using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BWhistogram
{
    public partial class Form1 : Form
    {
        Bitmap pic, res;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Drawing.Pen myP;
            myP = new System.Drawing.Pen(System.Drawing.Color.Black);
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            int i, j, n, c, max= 0;
            Color x;
            for (c = 0; c < 255; c++)
            { // Looking for a color with a maximum amount of pixels in the picture
                n = 0;
                for (i = 0; i < 300; i++)
                {
                    for (j = 0; j < 400; j++)
                    {
                        x = pic.GetPixel(j, i);
                        if (x.R == c) n++;
                    }
                }
                if (n > max) max = n;
            }

            for (c = 0; c < 255; c++)
            { // Draw a line representing the amount of pixels of each color in the picture 
                n = 0;
                for (i = 0; i < 300; i++)
                {
                    for (j = 0; j < 400; j++)
                    {
                        x = pic.GetPixel(j, i);
                        if (x.R == c) n++;
                    }
                }
                n = n * 100 / max;
                formGraphics.DrawLine(myP, 200 + c, 400, 200 + c, 400 - n);
            }
            myP.Dispose();
            formGraphics.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pic = new Bitmap("city_grayscale.jpg");
            res = new Bitmap(400, 300);
            pictureBox1.Image = pic;
        }
    }
}
