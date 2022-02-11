using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace animacion2d
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,] trazo = {
            { 188, 153, 188, 041 },
            { 188, 153, 267, 074 },
            { 188, 153, 300, 153 },
            { 188, 153, 268, 233 },
            { 188, 153, 188, 266 },
            { 188, 153, 109, 232 },
            { 188, 153, 077, 153 },
            { 188, 153, 110, 076 } };
        int i = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Bitmap b = new Bitmap("reloj.jpg");
            pictureBox1.Image = b;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            Pen p = new Pen(Color.Blue, 1);
            Pen f = new Pen(this.BackColor, 1);
            g.DrawLine(f, trazo[i, 0], trazo[i, 1], trazo[i, 2], trazo[i, 3]);
            i++;
            if (i> 7) i = 0;            
            g.DrawLine(p, trazo[i, 0],trazo[i, 1], trazo[i, 2], trazo[i, 3]);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > trazo[i , 0])
            {
                pictureBox1.Left += 10;
            }
            else
            {
                pictureBox1.Left -= 10;
            }
        }
    }
}
