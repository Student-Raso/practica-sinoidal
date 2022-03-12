using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace SensorSimulado
{
    public partial class Form1 : Form
    {
        int posMy = 500;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //int elem = dataGridView1.Rows.Count - 1;
            //int posx = Convert.ToInt16(dataGridView1.Rows[elem].Cells[2].Value.ToString());
            //int magx = Convert.ToInt16(dataGridView1.Rows[elem].Cells[3].Value.ToString());
            //int posy = posx + 1;
            //int magy = 120 + (posMy - e.Location.Y) * -1;
            //posMy = e.Location.Y;
            //dataGridView1.Rows.Add(posx, magx, posy, magy);
            //g.DrawLine(pluma, 0, 120, pictureBox1.Width, 120);
            //g.DrawLine(pluma, posx, magx, posy, magy);
            //if (posy > pictureBox1.Width)
            //{
            //    g.Clear(Color.White);
            //    dataGridView1.Rows.Clear();
            //    dataGridView1.Rows.Add("0", "120", "0", "120");
            //}
            //dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
        }

        Pen pluma;
        Graphics g;
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Px1", "Px1");
            dataGridView1.Columns.Add("Py1", "Py1");
            dataGridView1.Columns.Add("Px2", "Px2");
            dataGridView1.Columns.Add("Py2", "Py2"); 
            dataGridView1.Columns.Add("Px3", "Px3");
            dataGridView1.Columns.Add("Py3", "Py3");
            dataGridView1.Rows.Add("0", "500", "0", "500", "0", "500");
            pluma = new Pen(Color.Blue, 1);
            g = pictureBox1.CreateGraphics(); //se crea dibujo
            g.DrawLine(pluma, 0, 500, pictureBox1.Width, 500);  //linea del medio
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Cursor.Position = new Point(500, 400);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int elem = dataGridView1.Rows.Count - 1;
            int posx = Convert.ToInt16(dataGridView1.Rows[elem].Cells[4].Value.ToString());
            int magy = Convert.ToInt16(dataGridView1.Rows[elem].Cells[5].Value.ToString());
            pictureBox2.Visible = false;
            double delta = Convert.ToDouble(DateTime.Now.ToString().Substring(17,2))*5;
            dataGridView1.Rows.Add(posx, magy, posx + 20, magy, posx + 20, posMy + (float)delta);
            pluma = new Pen(Color.Blue, 1);
            
            if (posMy > 495 && posMy < 505)
            {
                pluma = new Pen(Color.Green, 2);
                Console.Beep(1000, 200);
                pictureBox2.Visible = true;
            }
            g.DrawLine(pluma, posx, magy, posx + 20, magy);
            g.DrawLine(pluma, posx + 20, magy, posx + 20, posMy+(float)delta);
            if (posx > pictureBox1.Width)
            {
                g.Clear(Color.White);
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add("0", "500", "0", "500", "0", "500");
                //dataGridView1.Rows.RemoveAt(0);
                //posx--;
                g.DrawLine(pluma, 0, 500, pictureBox1.Width, 500);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter arch = new StreamWriter("datos.txt");
            arch.WriteLine("px#mx#py#my");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                arch.WriteLine(dataGridView1.Rows[i].Cells[0].Value.ToString() + "#" +
                    dataGridView1.Rows[i].Cells[1].Value.ToString() + "#" + 
                    dataGridView1.Rows[i].Cells[2].Value.ToString() + "#" +
                    dataGridView1.Rows[i].Cells[3].Value.ToString() + "#");
            }
            arch.Close();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            posMy = e.Location.Y; //pocision del mouse
        }
    }
}