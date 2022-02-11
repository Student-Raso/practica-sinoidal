using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace rav
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        WebBrowser webBrowser1 = new WebBrowser();
        private void Form7_Load(object sender, EventArgs e)
        {
            webBrowser1.Left = 12;
            webBrowser1.Top = 270;
            webBrowser1.Width = 770;
            webBrowser1.Height = 160;
            webBrowser1.ScrollBarsEnabled = true;
            webBrowser1.Visible = true;
            webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.Controls.Add(this.webBrowser1);

            dataGridView1.Columns.Add("ID_RESULTADO", "ID_RESULTADO");
            dataGridView1.Columns.Add("RESULTADO", "RESULTADO");
            dataGridView1.Columns.Add("ID_APLICACION", "ID_APLICACION");
            dataGridView1.Columns.Add("DATO", "DATO");
            dataGridView1.Columns.Add("ESPERADO", "ESPERADO");
            dataGridView1.Columns.Add("ENTREGADA", "ENTREGADA");
            dataGridView1.Columns.Add("RECIBIDO", "RECIBIDO");
            dataGridView1.Columns.Add("ESTADO", "ESTADO");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Program Files\Microsoft Office\root\Office16\winword", 
                @"C:\Users\hello\source\repos\rav\rev\code\rav\bin\Debug\Funcionalidad.docx");
        }

        private void button1_Click(object sender, EventArgs e)
        {//Buscar
            string connectionString = "datasource=localhost;port=3306;username=root;password=123456;database=repositorio;";
            string query = "Select * from resultados where ID_RESULTADO like '%" + textBox1.Text.Trim() + "%' limit 50";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            dataGridView1.Rows.Clear();
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                            reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6),
                            reader.GetString(7));
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
            if (dataGridView1.Rows.Count >= 50)
                MessageBox.Show("Se encontraron demasiados registros.\nNo se muestran todos los registros encontados.",
                    "Debes depurar la búsqueda");
        }

        string responsable, aplicador;
        string idres, idapl, prueba, nombrePrueba, folio, aplicada, firma, version;
        string archivo = @"C:\Users\hello\source\repos\rav\rev\code\rav\bin\Debug\Traza.htm";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            obtAplicacion(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            obtUsuario(idres, idapl);
            obtPrueba(prueba);
            StreamWriter arch = new StreamWriter(archivo);
            arch.WriteLine("<html><meta content=\"text/html;charset=UTF-8\">Trazabilidad del resultado"
                      + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + ":<br>");
            arch.WriteLine(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "<br>");
            arch.WriteLine("<br> ID_APLICACION: " + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "<br>");
            arch.WriteLine("RESPONSABLE::: " + idres + " - " + responsable + "<br>");
            arch.WriteLine(@"ID_PRUEBA::::: " + prueba + " - " + nombrePrueba + "<br>");
            arch.WriteLine("APLICADOR::::: " + idapl + " - " + aplicador + "<br>");
            arch.WriteLine("FOLIO::::::::: "+ folio + "<br>");
            arch.WriteLine("APLICADA:::::: "+ aplicada + " <br>");
            arch.WriteLine("FIRMA::::::::: " + firma + "<br>");
            arch.WriteLine("VERSION::::::: " + version + " <br></html>");

            arch.Close();
            Uri dir = new Uri(archivo);
            webBrowser1.Url = dir;
        }

        private void obtAplicacion(string a)
        { //Buscar
            string connectionString = "datasource=localhost;port=3306;username=root;password=123456;database=repositorio;";
            string query = "Select * from aplicaciones where ID_APLICACION="+a;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    idres = reader.GetString(1);
                    prueba = reader.GetString(2);
                    idapl = reader.GetString(3);
                    folio = reader.GetString(4);
                    aplicada = reader.GetString(5);
                    firma = reader.GetString(6);
                    version = reader.GetString(7);
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
        }
        private void obtPrueba(string p)
        { //Buscar
            string connectionString = "datasource=localhost;port=3306;username=root;password=123456;database=repositorio;";
            string query = "Select * from pruebas where ID_PRUEBA=" + p;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    nombrePrueba = reader.GetString(1);
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
        }
        private void obtUsuario(string r, string a)
        { //Buscar
            string connectionString = "datasource=localhost;port=3306;username=root;password=123456;database=repositorio;";
            string query = "SELECT * FROM usuarios WHERE ID_USUARIO IN(" + r + "," + a + ")";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    responsable = reader.GetString(1);
                    reader.Read();
                    aplicador = reader.GetString(1);
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
        }
    }
}
