using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Rotar3D
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double cx=245, cy=200, cz=20, tx, ty, tz, rx=0, ry=0, rz=0;

        double[,] original = { 
            {115,115,0},
            {200,150,0},
            {290,150,0},
            {290,180,0},
            {285,185,0},
		    {285,220,0},
            {275,250,0},
            {280,280,0},
            {248,285,0},
            {240,270,0},
		    {195,220,0},
            {180,190,0}, 
            {170,175,0}, 
            {115,140,0}, 
            {115,115,0},
            {115,115,90},
            {200,150,90},
            {290,150,90},
            {290,180,90},
            {285,185,90},
		    {285,220,90},
            {275,250,90},
            {280,280,90},
            {248,285,90},
            {240,270,90},
		    {195,220,90},
            {180,190,90}, 
            {170,175,90}, 
            {115,140,90}, 
            {115,115,90} };

        double[,] figura = new double[30,3];

        private void RotarFigura() 
        {
            for (int p = 0; p < figura.GetLength(0); p++)
            {
                ty = original[p, 1] - cy;
                tz = original[p, 2] - cz;
                figura[p, 0] = original[p, 0];
                figura[p, 1] = Convert.ToInt16(ty * Math.Cos(-0.01745 * rx) - tz * Math.Sin(-0.01745 * rx) + cy);
                figura[p, 2] = Convert.ToInt16(ty * Math.Sin(-0.01745 * rx) + tz * Math.Cos(-0.01745 * rx) + cz);
                tx = figura[p, 0] - cx;
                tz = figura[p, 2] - cz;
                figura[p, 0] = Convert.ToInt16(tx * Math.Cos(-0.01745 * ry) - tz * Math.Sin(-0.01745 * ry) + cx);
                figura[p, 2] = Convert.ToInt16(tx * Math.Sin(-0.01745 * ry) + tz * Math.Cos(-0.01745 * ry) + cz);
                tx = figura[p, 0] - cx;
                ty = figura[p, 1] - cy;
                figura[p, 0] = Convert.ToInt16(ty * Math.Sin(-0.01745 * rz) + tx * Math.Cos(-0.01745 * rz) + cx);
                figura[p, 1] = Convert.ToInt16(ty * Math.Cos(-0.01745 * rz) - tx * Math.Sin(-0.01745 * rz) + cy);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pluma = new Pen(Color.Blue, 1);
            RotarFigura();
            for (int p = 0; p < figura.GetLength(0)-1; p++)
            {
                g.DrawLine(pluma, (int)figura[p, 0], (int)figura[p, 1],(int)figura[p + 1, 0], (int)figura[p + 1, 1]);
                if (p < figura.GetLength(0) / 2)
                    g.DrawLine(pluma, (int)figura[p, 0], (int)figura[p, 1],(int)figura[p + 15, 0], (int)figura[p + 15, 1]);
            }
            textBox1.Text = rx.ToString();
            textBox2.Text = ry.ToString();
            textBox3.Text = rz.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rx += 15;
            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rx -= 15;
            this.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
             ry -= 15;
             this.Refresh();
         }

        private void button3_Click(object sender, EventArgs e)
        {
             ry += 15;
             this.Refresh();
         }

        private void button6_Click(object sender, EventArgs e)
        {
            rz -= 15;
            this.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rz += 15;
            this.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}