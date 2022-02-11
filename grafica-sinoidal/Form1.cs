using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace grafica_sinoidal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //produccion de los datos
            for (int i = 0; i < pictureBox1.Width; i++)
            {
                //Se añade rows al dataGrid1 con valores de I convertidos en Seno
                //multiplicado por PI * (i * 3) / 180 todos convertidos a string con 4 decimales
                dataGridView1.Rows.Add(i.ToString(), 
                    Math.Sin(Math.PI * (double)(i * 5) / 180).ToString("0.0000"),
                    Math.Sin(Math.PI * (double)(i * 4) / 180).ToString("0.0000"),
                    Math.Sin(Math.PI * (double)(i * 2) / 180).ToString("0.0000"));
            }
            //creación de la gráfica
            //se instancia tela en pictureBox
            Graphics tela = pictureBox1.CreateGraphics();
            //se instancia linea con color azul como objeto NEW PEN
            Pen p;
            //Se instancia parametro n inicializado en 0
            double n = 0;
            //se instancia parametro radio incicializado en 100
            //teimpo para graficar cada punto
            int milliseconds = 1;

            //primer for para iterar sobre columna
            for (int c = 1; c < 4; c++)
            {
                //For para dibura en pictureBox1
                //i es número de fila, limite todas las columnas menos uno
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    //de extrae el valor de cada celda y fila, se convierte en doub y se guarda en "n"
                    n = Convert.ToDouble(dataGridView1.Rows[i].Cells[c].Value.ToString());
                    n = (n * ((c == 1) ? 50 : (c == 2) ? 80 : 100));
                    p = new Pen((c == 1) ? Color.Red : (c == 2) ? Color.DarkGreen : Color.Blue, 2);
                    tela.DrawLine(p, i, (int)(n + (pictureBox1.Height / 2.0)),
                                     i, (int)(n + 2 + (pictureBox1.Height / 2.0)));
                    //tiempo para hacer refresh en 0 milisegundos
                    Thread.Sleep(0);
                }
            }
        }
        //se añaden columnas en dataGridView
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("N", "N");
            dataGridView1.Columns.Add("Seno1", "Seno1"); 
            dataGridView1.Columns.Add("Seno2", "Seno2");
            dataGridView1.Columns.Add("Seno3", "Seno3");
        }
    }
}
