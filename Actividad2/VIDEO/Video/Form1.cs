using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Threading;

namespace Video
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cam = new VideoCaptureDevice(webcam[0].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        }

        private void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
            }
            catch (Exception ex)
            { return; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cam.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = pictureBox1.Image;
            timer1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                FileStream fstream = new FileStream(@"C:\Users\hello\OneDrive\Documents\UTH\QUINTO CUATRIMESTRE\AppIoT\RAV\rav\bin\Debug\fotos\" + textBox4.Text + ".png", FileMode.Create);
                pictureBox2.Image.Save(fstream, System.Drawing.Imaging.ImageFormat.Png);
                fstream.Close();
            }
            else 
            {
                MessageBox.Show("No haz especificado el ID del Usuario");
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Presionaste\n" + e.X.ToString() + "\n" + e.Y.ToString());
            int pr, pg, pb;
            pr = ((pictureBox1.Image as Bitmap).GetPixel(e.X, e.Y)).R;
            pg = ((pictureBox1.Image as Bitmap).GetPixel(e.X, e.Y)).G;
            pb = ((pictureBox1.Image as Bitmap).GetPixel(e.X, e.Y)).B;
            textBox1.Text = pr.ToString();
            textBox2.Text = pg.ToString();
            textBox3.Text = pb.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int pr=0, pg = 0, pb = 0, desp = 10, 
                rangoR = 57, rangoG = 131, rangoB = 175;
            Graphics g = pictureBox1.CreateGraphics();
            Pen p = new Pen(Color.Red, 1);
            for (int r = 0; r < 100; r++)
            {
                for (int c = 0; c < 100; c++)
                {
                    try {
                        pr = ((pictureBox1.Image as Bitmap).GetPixel(c, r)).R;
                        pg = ((pictureBox1.Image as Bitmap).GetPixel(c, r)).G;
                        pb = ((pictureBox1.Image as Bitmap).GetPixel(c, r)).B;
                    }
                    catch (Exception ex)
                    { return; }
                    if (pr > rangoR - desp && pr < rangoR + desp &&
                        pg > rangoG - desp && pg < rangoG + desp &&
                        pb > rangoB - desp && pb < rangoB + desp)
                    {
                        //MessageBox.Show("Encontrado:\n" + 
                        //    c.ToString() + ", " + r.ToString() + "\n" +
                        //    pr.ToString() + ", " +
                        //    pg.ToString() + ", " +
                        //    pb.ToString());
                        //g.Clear(Color.Transparent);
                        g.DrawRectangle(p, c, r, 10, 10);
                        
                        Thread.Sleep(100);
                        return;
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            button2_Click(sender, e);
        }
    }
}
