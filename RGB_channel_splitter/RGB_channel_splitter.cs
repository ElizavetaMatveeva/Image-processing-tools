using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB
{
    public partial class Form1 : Form
    {
        Bitmap pic, res;
        Color px1, px2;
        int resR, resB, resG;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pic = new Bitmap("autumn.jpg");
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
                    resR = px1.R;
                    resB = px1.R;
                    resG = px1.R;
                    px2 = Color.FromArgb(resR, resB, resG);
                    res.SetPixel(j, i, px2);
                }
            }
            pictureBox2.Image = res;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 400; j++)
                {
                    px1 = pic.GetPixel(j, i);
                    resR = px1.G;
                    resB = px1.G;
                    resG = px1.G;
                    px2 = Color.FromArgb(resR, resB, resG);
                    res.SetPixel(j, i, px2);
                }
            }
            pictureBox2.Image = res;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 400; j++)
                {
                    px1 = pic.GetPixel(j, i);
                    resR = px1.B;
                    resB = px1.B;
                    resG = px1.B;
                    px2 = Color.FromArgb(resR, resB, resG);
                    res.SetPixel(j, i, px2);
                }
            }
            pictureBox2.Image = res;
        }
    }
}
