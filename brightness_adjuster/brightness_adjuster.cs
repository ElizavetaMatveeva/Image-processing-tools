using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brightness
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
            pic = new Bitmap("flower.jpg");
            res = new Bitmap(400, 300);
            pictureBox1.Image = pic;
        }

        private static byte ToByte(int val)
        {
            if (val > 255) val = 255;
            else
                if (val < 0) val = 0;
            return (byte)val;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 400; j++)
                {
                    px1 = pic.GetPixel(j, i);
                    resR = ToByte(px1.R + hScrollBar1.Value);
                    resG = ToByte(px1.G + hScrollBar1.Value);
                    resB = ToByte(px1.B + hScrollBar1.Value);
                    px2 = Color.FromArgb(resR, resG, resB);
                    res.SetPixel(j, i, px2);
                }
            }
            pictureBox1.Image = res;
        }
    }
}
