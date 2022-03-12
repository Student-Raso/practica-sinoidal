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
        int posX = 0, posY = 0;
        double centrox = 0, centroy = 0, centroz = 0,
            tx, ty, tz,
            rx = 0, ry = 0, rz = 0,
            cx = 0, cy = 0, cz = 10;

        double[,] original = {                                             // en sentido del reloj
            {100.00,100.00,100.00, 200.00,100.00,100.00, 0xff, 0x00, 0x00}, //frente - superior
            {200.00,100.00,100.00, 200.00,200.00,100.00, 0xff, 0x00, 0x00}, //frente - 
            {200.00,200.00,100.00, 100.00,200.00,100.00, 0xff, 0x00, 0x00}, //frente
            {100.00,200.00,100.00, 100.00,100.00,100.00, 0xff, 0x00, 0x00}, //frente
            {100.00,100.00,100.00, 100.00,100.00,200.00, 0xff, 0x00, 0xff}, //medio
            {200.00,100.00,100.00, 200.00,100.00,200.00, 0xff, 0x00, 0xff}, //medio
            {200.00,200.00,100.00, 200.00,200.00,200.00, 0xff, 0x00, 0xff}, //medio
            {100.00,200.00,100.00, 100.00,200.00,200.00, 0xff, 0x00, 0xff}, //medio
            {100.00,100.00,200.00, 200.00,100.00,200.00, 0x00, 0x00, 0xff}, //detras
            {200.00,100.00,200.00, 200.00,200.00,200.00, 0x00, 0x00, 0xff}, //detras
            {200.00,200.00,200.00, 100.00,200.00,200.00, 0x00, 0x00, 0xff}, //detras
            {100.00,200.00,200.00, 100.00,100.00,200.00, 0x00, 0x00, 0xff} //detras

            //{1300.00,1300.00,1300.00, 1400.00,1300.00,1300.00, 0x00, 0xff, 0xff}, //frente - superior
            //{1400.00,300.00,300.00, 1400.00,1400.00,1300.00, 0x00, 0xff, 0xff}, //frente - 
            //{400.00,400.00,300.00, 300.00,400.00,300.00, 0x00, 0xff, 0xff}, //frente
            //{300.00,400.00,300.00, 300.00,400.00,300.00, 0x00, 0xff, 0xff}, //frente
            //{300.00,300.00,300.00, 300.00,300.00,400.00, 0x00, 0xff, 0xff}, //medio
            //{400.00,300.00,300.00, 400.00,300.00,400.00, 0xff, 0x00, 0xff}, //medio
            //{400.00,400.00,300.00, 400.00,400.00,400.00, 0xff, 0x00, 0xff}, //medio
            //{300.00,400.00,300.00, 300.00,400.00,400.00, 0xff, 0x00, 0xff}, //medio
            //{300.00,300.00,400.00, 400.00,300.00,400.00, 0x00, 0x00, 0xff}, //detras
            //{400.00,300.00,400.00, 400.00,400.00,400.00, 0x00, 0x00, 0xff}, //detras
            //{400.00,400.00,400.00, 300.00,400.00,400.00, 0x00, 0x00, 0xff}, //detras
            //{300.00,400.00,400.00, 300.00,300.00,400.00, 0x00, 0x00, 0xff} //detras
        };


        double[,] figura = new double[12,9];

        private void button7_Click(object sender, EventArgs e)
        {
            if (escala > 0.11)
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

        private void button12_Click(object sender, EventArgs e)
        {
            posX = posX + 10;
            this.Refresh();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            posY = posY - 10;
            this.Refresh();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            posY = posY + 10;
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
                //inicial
                ty = original[p, 1] * escala - cy;
                tz = original[p, 2] * escala - cz;
                figura[p, 0] = original[p, 0] * escala;
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
                
                //final
                ty = original[p, 4] * escala - cy;
                tz = original[p, 5] * escala - cz;
                figura[p, 3] = original[p, 3] * escala;
                figura[p, 4] = Convert.ToInt16(ty * Math.Cos(-0.01745 * rx) - tz * Math.Sin(-0.01745 * rx) + cy);
                figura[p, 5] = Convert.ToInt16(ty * Math.Sin(-0.01745 * rx) + tz * Math.Cos(-0.01745 * rx) + cz);
                tx = figura[p, 3] - cx;
                tz = figura[p, 5] - cz;
                figura[p, 3] = Convert.ToInt16(tx * Math.Cos(-0.01745 * ry) - tz * Math.Sin(-0.01745 * ry) + cx);
                figura[p, 5] = Convert.ToInt16(tx * Math.Sin(-0.01745 * ry) + tz * Math.Cos(-0.01745 * ry) + cz);
                tx = figura[p, 3] - cx;
                ty = figura[p, 4] - cy;
                figura[p, 3] = Convert.ToInt16(ty * Math.Sin(-0.01745 * rz) + tx * Math.Cos(-0.01745 * rz) + cx);
                figura[p, 4] = Convert.ToInt16(ty * Math.Cos(-0.01745 * rz) - tx * Math.Sin(-0.01745 * rz) + cy);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pluma;
            Graphics g = e.Graphics;
            Centros();
            RotarFigura();
            for (int p = 0; p < figura.GetLength(0); p++)
            {
                pluma = new Pen(Color.FromArgb((int)original[p, 6], (int)original[p, 7], (int)original[p, 8]), 3);
                g.DrawLine(pluma, (int)figura[p, 0]+posX, (int)figura[p, 1] + posY, 
                    (int)figura[p, 3] + posX, (int)figura[p, 4] + posY);

            }
            textBox1.Text = rx.ToString();
            textBox2.Text = ry.ToString();
            textBox3.Text = rz.ToString();
        }
        private void Centros() {
            cx = (centrox + posX) * escala;
            cy = (centroy + posY) * escala;
            cz = (centroz) * escala ;
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
        private void calcularLosCentros()
        {
            double minx = 999999, miny = 999999, minz = 999999;
            double maxx = -999999, maxy = -999999, maxz = -999999;
            for (int i = 0; i < original.GetLength(0); i++)
            {
                //min
                if (original[i, 0] < minx) minx = original[i, 0];
                if (original[i, 3] < minx) minx = original[i, 3];
                if (original[i, 1] < miny) miny = original[i, 1];
                if (original[i, 4] < miny) miny = original[i, 4];
                if (original[i, 2] < minz) minz = original[i, 2];
                if (original[i, 5] < minz) minz = original[i, 5];
                //max
                if (original[i, 0] > maxx) maxx = original[i, 0];
                if (original[i, 3] > maxx) maxx = original[i, 3];
                if (original[i, 1] > maxy) maxy = original[i, 1];
                if (original[i, 4] > maxy) maxy = original[i, 4];
                if (original[i, 2] > maxz) maxz = original[i, 2];
                if (original[i, 5] > maxz) maxz = original[i, 5];

                centrox = (minx + maxx) / 2;
                centrox = (miny + maxy) / 2;
                centrox = (minz + maxz) / 2;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            calcularLosCentros();
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
