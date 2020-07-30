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
        Bitmap pic, res;
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
                    px1 = pic.GetPixel (j, i);
                    int x = (px1.R + px1.B + px1.G) / 3;
                    px2 = Color.FromArgb(x, x, x);
                    res.SetPixel(j, i, px2);
                }
            }
            pictureBox2.Image = res;
        }
    }
}
