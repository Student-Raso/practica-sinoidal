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
        double escala = 1.0;
        int posX = 200, posY = 200;
        double centrox = 300, centroy = 300, centroz = 10, 
            tx, ty, tz, 
            rx=0, ry=0, rz=0, 
            cx = 300, cy = 300, cz = 10;
        

        double[,] original = {
{500.00,300.00,0.00},
{437.50,167.50,0.00},
{300.00,100.00,0.00},
{162.50,167.50,0.00},
{100.00,300.00,0.00},
{162.50,437.50,0.00},
{300.00,500.00,0.00},
{437.50,437.50,0.00},
{500.00,300.00,0.00},
{500.00,300.00,20.00},
{437.50,167.50,20.00},
{300.00,100.00,20.00},
{162.50,167.50,20.00},
{100.00,300.00,20.00},
{162.50,437.50,20.00},
{300.00,500.00,20.00},
{437.50,437.50,20.00},
{500.00,300.00,20.00}};


        public static int T = 18, M = 9;
    double[,] figura = new double[T,3];

        private void button7_Click(object sender, EventArgs e)
        {
            if(escala > 0.11)
            {
                escala = escala - 0.1;
                textBox4.Text = (escala * 100).ToString();
                this.Refresh();
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            posX = posX - 10;
            this.Refresh();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            posY = posY + 10;
            this.Refresh();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            posY = posY - 10;
            this.Refresh();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            posX = posX + 10;
            this.Refresh();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            escala = escala + 0.1;

            textBox4.Text = (escala * 100).ToString();
            this.Refresh();

        }

        private void RotarFigura() 
        {

            for (int p = 0; p < figura.GetLength(0); p++)
            {
                ty = original[p, 1] * 0.5 - cy;
                tz = original[p, 2] * 0.5 - cz;
                figura[p, 0] = original[p, 0] * 0.5;
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
            Centros();
            RotarFigura();
            for (int p = 0; p < figura.GetLength(0)-1; p++)
            {
                g.DrawLine(pluma, (int)figura[p, 0]+posX, (int)figura[p, 1] + posY, 
                    (int)figura[p + 1, 0] + posX, (int)figura[p + 1, 1] + posY);
                if (p < figura.GetLength(0) / 2)
                    g.DrawLine(pluma, (int)figura[p, 0] + posX, (int)figura[p, 1] + posY, 
                        (int)figura[p + M, 0] + posX, (int)figura[p + M, 1] + posY);
            }
            textBox1.Text = rx.ToString();
            textBox2.Text = ry.ToString();
            textBox3.Text = rz.ToString();
        }
        private void Centros()
        {
            cx = (centrox + posX - 150) * escala;
            cy = (centroy + posY - 150) * escala;            
            cz = (centroz - 10) * escala;
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
            this.BackColor = Color.White;
            Centros();
        }
    }
}

//{ 200, 200, 100},
//{ 280, 150, 100},
//{ 300, 100, 100},
//{ 290, 070, 100},
//{ 250, 050, 100},
//{ 230, 060, 100},
//{ 200, 100, 100},
//{ 170, 060, 100},
//{ 150, 050, 100},
//{ 110, 070, 100},
//{ 100, 100, 100},
//{ 120, 150, 100},
//{ 200, 200, 100},

//{ 200, 200, 120},
//{ 280, 150, 120},
//{ 300, 100, 120},
//{ 290, 070, 120},
//{ 250, 050, 120},
//{ 230, 060, 120},
//{ 200, 100, 120},
//{ 170, 060, 120},
//{ 150, 050, 120},
//{ 110, 070, 120},
//{ 100, 100, 120},
//{ 120, 150, 120},
//{ 200, 200, 120}
//};


      //          {115,115,0},
      //      {200,150,0},
      //      {290,150,0},
      //      {290,180,0},
      //      {285,185,0},
		    //{285,220,0},
      //      {275,250,0},
      //      {280,280,0},
      //      {248,285,0},
      //      {240,270,0},
		    //{195,220,0},
      //      {180,190,0}, 
      //      {170,175,0}, 
      //      {115,140,0}, 
      //      {115,115,0},

      //      {115,115,10},
      //      {200,150,10},
      //      {290,150,10},
      //      {290,180,10},
      //      {285,185,10},
		    //{285,220,10},
      //      {275,250,10},
      //      {280,280,10},
      //      {248,285,10},
      //      {240,270,10},
		    //{195,220,10},
      //      {180,190,10}, 
      //      {170,175,10}, 
      //      {115,140,10}, 
      //      {115,115,10} };
