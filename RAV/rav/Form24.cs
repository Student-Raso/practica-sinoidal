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
    public partial class Form24 : Form
    {
        public Form24()
        {
            InitializeComponent();
        }
        WebBrowser webBrowser1 = new WebBrowser();
        private void Form24_Load(object sender, EventArgs e)
        {
            webBrowser1.Left = 12;
            webBrowser1.Top = 53;
            webBrowser1.Width = 754;
            webBrowser1.Height = 480;
            webBrowser1.ScrollBarsEnabled = true;
            webBrowser1.Visible = true;
            webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.Controls.Add(this.webBrowser1);
            button1_Click(sender, e);
        }
        string archivo = Directory.GetCurrentDirectory() + "\\SumarioDeResultadosPorUsuarioTrazabilidad.htm";

        private void button1_Click(object sender, EventArgs e)
        {//Generar
            int total = 0;
            StreamWriter arch = new StreamWriter(archivo);
            arch.WriteLine("<html><meta charset=\"UTF-8\">SUMARIO DE RESULTADOS POR USUARIO TRAZABILIDAD<br>Fecha: " + System.DateTime.Now.ToString() + "<br><br>");
            arch.WriteLine("<table border=1 cellspacing=0>");
            arch.WriteLine("<tr><td>ID_PRUEBA</td><td>PRUEBA</td><td>DESCRIPCION</td><td>TIPODEPRUEBA</td><td>MODULO</td>" +
                "<td>ELABORA</td><td>AUTORIZA</td><td>AUROTIZADA</td><td>REQUISITOS</td><td>ID_APLICACION</td><td>RESPONSABLE</td>" +
                "<td>ID_PRUEBA</td><td>APLICADOR</td><td>FOLIO</td><td>APLICADA</td><td>FIRMA</td><td>VERSION</td>" +
                "<td>ID_RESULTADO</td><td>RESULTADO</td><td>ID_APLICACION</td><td>DATO</td><td>ESPERANDO</td><td>ENTREGADA</td>" +
                "<td>RECIBIDO</td><td>ESTADO</td></tr>");
            string connectionString = "datasource=localhost;port=3306;username=root;password=123456;database=repositorio;";
            string query = "select*from pruebas, aplicaciones, resultados where pruebas.id_prueba=aplicaciones.id_prueba " +
                "and aplicaciones.id_aplicacion=resultados.id_aplicacion ORDER BY pruebas.id_prueba, aplicaciones.id_aplicacion, " +
                "resultados.id_resultado";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    string anterior = "", anterior2 = "";
                    while (reader.Read())//25
                    {
                        arch.WriteLine("<tr><td>" + ((anterior == reader.GetString(0)) ? " " : reader.GetString(0))
                                    + "</td><td>" + ((anterior == reader.GetString(0)) ? " " : reader.GetString(1))
                                    + "</td><td>" + ((anterior == reader.GetString(0)) ? " " : reader.GetString(2))
                                    + "</td><td>" + ((anterior == reader.GetString(0)) ? " " : reader.GetString(3))
                                    + "</td><td>" + ((anterior == reader.GetString(0)) ? " " : reader.GetString(4))
                                    + "</td><td>" + ((anterior == reader.GetString(0)) ? " " : reader.GetString(5))
                                    + "</td><td>" + ((anterior == reader.GetString(0)) ? " " : reader.GetString(6))
                                    + "</td><td>" + ((anterior == reader.GetString(0)) ? " " : reader.GetString(7))
                                    + "</td><td>" + ((anterior == reader.GetString(0)) ? " " : reader.GetString(8))
                                    + "</td><td>" + ((anterior2 == reader.GetString(9)) ? " " : reader.GetString(9))
                                    + "</td><td>" + ((anterior2 == reader.GetString(9)) ? " " : reader.GetString(10))
                                    + "</td><td>" + ((anterior2 == reader.GetString(9)) ? " " : reader.GetString(11))
                                    + "</td><td>" + ((anterior2 == reader.GetString(9)) ? " " : reader.GetString(12))
                                    + "</td><td>" + ((anterior2 == reader.GetString(9)) ? " " : reader.GetString(13))
                                    + "</td><td>" + ((anterior2 == reader.GetString(9)) ? " " : reader.GetString(14))
                                    + "</td><td>" + ((anterior2 == reader.GetString(9)) ? " " : reader.GetString(15))
                                    + "</td><td>" + ((anterior2 == reader.GetString(9)) ? " " : reader.GetString(16))
                                    + "</td><td>" + reader.GetString(17)
                                    + "</td><td>" + reader.GetString(18)
                                    + "</td><td>" + reader.GetString(19)
                                    + "</td><td>" + reader.GetString(20)
                                    + "</td><td>" + reader.GetString(21)
                                    + "</td><td>" + reader.GetString(22)
                                    + "</td><td>" + reader.GetString(23)
                                    + "</td><td>" + reader.GetString(24)
                                    + "</td></tr>");
                        anterior = reader.GetString(0);
                        anterior2 = reader.GetString(9);
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

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Program Files\Microsoft Office\root\Office16\excel",
                "\"" + archivo + "\"");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome",
                "\"" + archivo + "\"");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
