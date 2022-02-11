using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace rav
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome",
                "\"" + archivo + "\"");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Program Files\Microsoft Office\root\Office16\excel",
                "\"" + archivo + "\"");
        }

        string archivo = Directory.GetCurrentDirectory() + "\\ReporteResultados.htm";
        private void button1_Click(object sender, EventArgs e)
        {//Generar
            int total = 0;
            StreamWriter arch = new StreamWriter(archivo);
            arch.WriteLine("<html style=\"color:#ffff00\"><meta charset=\"UTF-8\">REPORTE DE RESULTADOS<br>Fecha: " + System.DateTime.Now.ToString() + "<br><br>");
            arch.WriteLine("<table border=1 cellspacing=0>");
            arch.WriteLine("<tr style=\"color:#ffff00; background:#9c9c9c\"><td>ID_RESULTADO</td><td>RESULTADO</td><td>ID_APLICACION</td><td>DATO</td>" +
                "<td>ESPERANDO</td><td>ENTREGADA</td><td>RECIBIDO</td><td>ESTADO</td></tr>");
            string connectionString = "datasource=localhost;port=3306;username=root;password=123456;database=repositorio;";
            string query = "Select * from resultados";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        arch.WriteLine("<tr style=\"color:#0000ff\"><td>" + reader.GetString(0) + "</td><td " + ((reader.GetString(2).CompareTo("2")>0) ? " style=\"color:#FF0000;\"" : " style=\"color:#000000;\"")+">" + reader.GetString(1)
                                    + "</td ><td style=\"color:#0000ff; background:#99ccff\" style=\"color:#ff0000\">" + reader.GetString(2) + "</td><td>" + reader.GetString(3)
                                    + "</td><td style=\"color:#0000ff; background:#1c1c2c\">" + reader.GetString(4) + "</td><td>" + reader.GetString(5) 
                                    + "</td><td style=\"color:#0000ff; background:#9c9c9c\">" + reader.GetString(6) + "</td><td style=\"color:#0000ff; background:#9c9c9c\">" + reader.GetString(7) 
                                    + "</td ></tr>");
                        total++;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron datos.");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            arch.WriteLine("</table></html>");
            arch.WriteLine("Total de registros: " + total.ToString());
            arch.Close();
            Uri dir = new Uri(archivo);
            webBrowser1.Url = dir;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        WebBrowser webBrowser1 = new WebBrowser();
        private void Form8_Load(object sender, EventArgs e)
        {
            webBrowser1.Left = 12;
            webBrowser1.Top = 53;
            webBrowser1.Width = 754;
            webBrowser1.Height = 480;
            webBrowser1.ScrollBarsEnabled = true;
            webBrowser1.Visible = true;
            webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.Controls.Add(this.webBrowser1);
            button1_Click(sender, e);
        }
    }
}
