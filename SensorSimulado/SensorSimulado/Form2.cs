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

namespace SensorSimulado
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        double promedio = 0.0;
        double minimo;
        double maximo;
        private void Form2_Load(object sender, EventArgs e)
        {
            string line;
            StreamReader arch = new StreamReader("datos.txt");
            line = arch.ReadLine();
            string[] arr = line.Split('#');
            dataGridView1.Columns.Add(arr[0], arr[0]);
            dataGridView1.Columns.Add(arr[1], arr[1]);
            dataGridView1.Columns.Add(arr[2], arr[2]);
            dataGridView1.Columns.Add(arr[3], arr[3]);
            double suma = 0;
            minimo = 9999.0;
            maximo = 0.0;
            while ((line = arch.ReadLine()) != null)
            {
                arr = line.Split('#');
                dataGridView1.Rows.Add(arr[0], arr[1], arr[2], arr[3]);
                suma += Convert.ToDouble(arr[3]);
                if (Convert.ToDouble(arr[3]) < minimo) minimo = Convert.ToDouble(arr[3]);
                if (Convert.ToDouble(arr[3]) > maximo) maximo = Convert.ToDouble(arr[3]);
            }
            arch.Close();
            promedio = suma / dataGridView1.Rows.Count;
        }

        private double desviacionEstandar()
        {
            double distancias = 00.0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                distancias += Math.Abs(promedio - Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()));
            }
            return (distancias / dataGridView1.Rows.Count);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter arch = new StreamWriter("reporte.htm");
            arch.WriteLine("<HTML>");
            arch.WriteLine("REPORTE DE DATOS ESTADÍSTICOS<br><br>");
            arch.WriteLine("<Table border=1 cellspacing=0>");
            arch.WriteLine("<tr><td>CANTIDAD DE DATOS OBTENIDOS: </td><td align=right>" 
                + dataGridView1.Rows.Count.ToString() + "</td></tr>");
            arch.WriteLine("<tr><td>PROMEDIO DE LOS DATOS: </td><td align=right>"
                + promedio.ToString("0.00") + "</td></tr>");
            arch.WriteLine("<tr><td>DESVIACION ESTANDAR: </td><td align=right>"
                + desviacionEstandar().ToString("0.00") + "</td></tr>");
            arch.WriteLine("<tr><td>VALOR MAXIMO: </td><td align=right>"
                + maximo.ToString("0.00") + "</td></tr>");
            arch.WriteLine("<tr><td>VALOR MINIMO: </td><td align=right>"
                + minimo.ToString("0.00") + "</td></tr>");
            arch.WriteLine("</Table></HTML>");

            arch.Close();
            Uri dir = new Uri(Directory.GetCurrentDirectory() + "\\reporte.htm");
            webBrowser1.Url = dir;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome", "\"" + Directory.GetCurrentDirectory() + "\\reporte.htm\"");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Excel", "\"" + Directory.GetCurrentDirectory() + "\\reporte.htm\"");
        }
    }
}
