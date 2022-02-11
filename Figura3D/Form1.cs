using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figura3D
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int vista = 1; 
        double escala = 1.0;
        double [,] figura = 
        {//   x1  y1  z1  x2  y2  z2
            { 10, 10, 10,100, 10, 10},
            {100, 10, 10,100, 80, 20},
            {100, 80, 20, 10, 80, 20},
            { 10, 80, 20, 10, 10, 10},

            { 10, 10, 10, 30, 30, 100 },
            { 100, 10, 10, 80, 30, 100},
            { 100, 80, 20, 80, 70, 90},
            { 10, 80, 20, 30, 70, 90},

            { 30, 30, 100, 80, 30, 100},
            { 80, 30, 100, 80, 70,  90},
            { 80, 70,  90, 30, 70,  90},
            { 30, 70,  90, 30, 30 ,100}
        };
        private void button1_Click(object sender, EventArgs e)
        {//vista frontal xy
            Graphics tela = pictureBox1.CreateGraphics();
            Pen pluma = new Pen(Color.Red, 2);
            tela.Clear(Color.White);
            escala = Convert.ToDouble(textBox1.Text);
            for (int i = 0; i < figura.GetLength(0); i++)
            {
                tela.DrawLine(pluma, (int)(figura[i, 0]*escala), (int)(figura[i, 1] * escala), (int)(figura[i, 3] * escala), (int)(figura[i, 4] * escala));
            }
            vista = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {//vista frontal xz
            Graphics tela = pictureBox1.CreateGraphics();
            Pen pluma = new Pen(Color.Blue, 2);
            tela.Clear(Color.White);
            escala = Convert.ToDouble(textBox1.Text);
            for (int i = 0; i < figura.GetLength(0); i++)
            {
                tela.DrawLine(pluma, (int)(figura[i, 0] * escala), (int)(figura[i, 2] * escala), (int)(figura[i, 3] * escala), (int)(figura[i, 5] * escala));
            }
            vista = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {//vista frontal zy
            Graphics tela = pictureBox1.CreateGraphics();
            Pen pluma = new Pen(Color.Purple, 2);
            tela.Clear(Color.White);
            escala = Convert.ToDouble(textBox1.Text);
            for (int i = 0; i < figura.GetLength(0); i++)
            {
                tela.DrawLine(pluma, (int)(figura[i, 2] * escala), (int)(figura[i, 1] * escala), (int)(figura[i, 5] * escala), (int)(figura[i, 4] * escala));
            }
            vista = 3;
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = escala.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            double n = Convert.ToDouble(textBox1.Text);
            n = n - 0.1;
            escala = n;
            textBox1.Text = escala.ToString();
            if (vista == 1) button1_Click(sender, e);
            else if(vista == 2) button2_Click(sender, e);
            else button3_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
             
            double n = Convert.ToDouble(textBox1.Text);
            n = n + 0.1;
            escala = n;
            textBox1.Text = escala.ToString();
            if (vista == 1) button1_Click(sender, e);
            else if (vista == 2) button2_Click(sender, e);
            else button3_Click(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (vista == 1) button1_Click(sender, e);
            else if (vista == 2) button2_Click(sender, e);
            else button3_Click(sender, e);
        }
    }
}
