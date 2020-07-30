using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        Bitmap pic, res, file;
        Color p, p2;
        int rs;
        int[] clr = new int[300 * 300]; // Color array
        int[] sum = new int[300 * 300]; // Semi-sum array
        int[] dif = new int[300 * 300]; // Semi-difference array

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pic = new Bitmap("mountains.jpg");
            res = new Bitmap(300, 300);
            pictureBox1.Image = pic;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            res = new Bitmap(300, 300);
            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 300; j++) // Write every pixel color to the color array
                {
                    p = pic.GetPixel(i, j);
                    rs = p.R;
                    clr[i * 300 + j] = rs;
                }
            }
            for (int i = 0; i < 300; i++) // Filling out the semi-sum and semi-defference arrays
            {
                for (int j = 0; j < 300; j += 2)
                {
                    sum[i * 300 + j] = (clr[i * 300 + j] + clr[i * 300 + j + 1]) / 2;
                    int d = (clr[i * 300 + j] - clr[i * 300 + j + 1]) / 2;
                    if (d < 0) // If the semi-difference result is negative, set the value to 0, otherwise write as is
                        dif[i * 300 + j] = 0;
                    else
                        dif[i * 300 + j] = d;
                }
            }
            int k = 0;
            for (int i = 0; i < 300; i++) // Recreate image using the semi-sum and semi-difference arrays
            {
                for (int j = 0; j < 300 / 2; j++)
                {
                    rs = sum[i * 300 + k];
                    p2 = Color.FromArgb(rs, rs, rs);
                    res.SetPixel(i, j, p2);
                    k = k + 2;
                }
                k = 0;
            }
            for (int i = 0; i < 300; i++)
            {
                for (int j = 300 / 2; j < 300; j++)
                {
                    rs = dif[i * 300 + k];
                    p2 = Color.FromArgb(rs, rs, rs);
                    res.SetPixel(i, j, p2);
                    k = k + 2;
                }
                k = 0;
            }
            pictureBox2.Image = res;

        }

        private void button3_Click(object sender, EventArgs e) // Load image in the window and save it to a file
        {
            file = new Bitmap(300, 300);
            for (int i = 0; i < 300; i++)
            {
                for (int j = 0; j < 300; j += 2)
                {
                    rs = sum[i * 300 + j] + dif[i * 300 + j];
                    p2 = Color.FromArgb(rs, rs, rs);
                    file.SetPixel(i, j, p2);
                    rs = sum[i * 300 + j] - dif[i * 300 + j];
                    p2 = Color.FromArgb(rs, rs, rs);
                    file.SetPixel(i, j + 1, p2);
                }
            }
            pictureBox3.Image = file;
            file.Save("result.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}