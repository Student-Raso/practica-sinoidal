using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace rav
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(textBox2.Text);
            f4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {//Buscar
            string connectionString = "datasource=localhost;port=3306;username=root;password=123456;database=repositorio;";
            string query = "Select * from aplicaciones where ID_APLICACION like '%" + textBox1.Text.Trim() + "%' limit 50";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[4].Width = 40; //columna folio
            dataGridView1.Columns[5].Width = 200; //columna fecha
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Agregar
            string connectionString = "datasource=localhost;port=3306;username=root;password=123456;database=repositorio;";
            string query = "insert into aplicaciones values(NULL,'" + textBox3.Text + "','" + textBox4.Text + "','"
                + textBox5.Text + "','" + textBox6.Text + "','"
                + textBox7.Text.Substring(6, 4) + textBox7.Text.Substring(3, 2) + textBox7.Text.Substring(0, 2)
                + textBox7.Text.Substring(11, 2) + textBox7.Text.Substring(14, 2) + textBox7.Text.Substring(17, 2)
                + "','" + textBox8.Text + "','" + textBox9.Text + "')";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            button1_Click(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1_CellClick
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {//Eliminar
            string connectionString = "datasource=localhost;port=3306;username=root;password=123456;database=repositorio;";
            string query = "delete from aplicaciones where ID_APLICACION=" + textBox2.Text;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            button1_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {//Modificar
            string connectionString = "datasource=localhost;port=3306;username=root;password=123456;database=repositorio;";
            string query = "update aplicaciones set RESPONSABLE='" + textBox3.Text.Trim() 
                + "', ID_PRUEBA='"+ textBox4.Text.Trim() 
                + "', APLICADOR='"+ textBox5.Text.Trim() 
                + "', FOLIO='" + textBox6.Text.Trim() 
                + "', APLICADA='" + textBox7.Text.Substring(6, 4) + textBox7.Text.Substring(3, 2) + textBox7.Text.Substring(0, 2)
                + textBox7.Text.Substring(11, 2) + textBox7.Text.Substring(14, 2) + textBox7.Text.Substring(17, 2)
                + "', FIRMA='" + textBox8.Text.Trim() 
                + "', VERSION='" + textBox9.Text.Trim() 
                + "' where ID_APLICACION=" + textBox2.Text;
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            button1_Click(sender, e); //Buscar
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                int n = Convert.ToInt32(textBox3.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Solo se aceptan digitos.\nBusca en Usuarios.\n" + ex.Message, "Error de Formato");
                textBox3.Focus();
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            DateTime f;
            try
            {
                f = DateTime.ParseExact(textBox7.Text, "dd/MM/yyyy HH:mm:ss tt", null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("El formato de la fecha no es correcto.\ndd/MM/yyyy HH:mm:ss tt\n" + ex.Message, "Error de Formato");
                textBox7.Focus();
            }
        }
    }
}
