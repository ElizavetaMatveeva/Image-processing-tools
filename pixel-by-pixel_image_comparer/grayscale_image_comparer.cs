using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace black_and_white

{
    public partial class Form1 : Form
    {
        Bitmap pic, res, histogram;
        Color px1, px2;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pic = new Bitmap("city.jpg");
            res = new Bitmap(400, 300);
            pictureBox1.Image = pic;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 400; j++)
                {
                    px1 = pic.GetPixel(j, i);
                    int x = (px1.R + px1.B + px1.G) / 3;
                    px2 = Color.FromArgb(x, x, x);
                    res.SetPixel(j, i, px2);
                }
            }
            pictureBox2.Image = res;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pic = new Bitmap("city_grayscale.jpg");
            res = new Bitmap(400, 300);
            pictureBox3.Image = pic;
        }

        private void label2_Click(object sender, EventArgs e)
        {}

        private void button4_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 400; j++)
                {
                    px1 = pic.GetPixel(j, i);
                    px2 = res.GetPixel(j, i);
                    if (px1 == px2)
                        count++;
                }
            }
            count = count * 100 / (400 * 300);
            label2.Text = "Comparison: " + count.ToString() + "%";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Color c1, c2, x;
            int i, j, avg = 0, c;
            histogram = new Bitmap(400, 300);
            for (i = 0; i < 300; i++)
            {
                for (j = 0; j < 400; j++)
                {
                    c2 = pic.GetPixel(j, i);
                    c1 = res.GetPixel(j, i);
                    avg = avg + Math.Abs(c2.R - c1.R);
                }
            }
            avg = avg / (400 * 300);
            for (i = 0; i < 300; i++)
            {
                for (j = 0; j < 400; j++)
                {
                    c2 = pic.GetPixel(j, i);
                    c1 = res.GetPixel(j, i);
                    c = Math.Abs(c2.R - c1.R);
                    if (c <= avg)
                        x = Color.FromArgb(0, 0, 255);
                    else
                        x = Color.FromArgb(255, 0, 0);
                    histogram.SetPixel(j, i, x);
                }
            }
            pictureBox4.Image = histogram;
        }
    }
}
