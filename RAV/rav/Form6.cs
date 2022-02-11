using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Media;

namespace rav
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {//Buscar
            string connectionString = "datasource=localhost;port=3306;username=root;password=123456;database=repositorio;";
            string query = "Select * from usuarios where ID_USUARIO like '%" + textBox1.Text.Trim() + "%' limit 50";
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
                            reader.GetString(3), reader.GetString(4));
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {//dataGridView1_CellClick
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            Bitmap foto = new Bitmap(@"C:\Users\hello\OneDrive\Documents\UTH\QUINTO CUATRIMESTRE\AppIoT\RAV\rav\bin\Debug\fotos\\0.png");
            pictureBox1.Image = foto;
            try 
            {
                foto = new Bitmap(@"C:\Users\hello\OneDrive\Documents\UTH\QUINTO CUATRIMESTRE\AppIoT\RAV\rav\bin\Debug\fotos\\" + textBox2.Text + ".png");
                pictureBox1.Image = foto;
            }
            catch
            {
                //MessageBox.Show("Error, El usuario no tiene foto\nPresiona la foto para abrir la camara.");
                SoundPlayer sonido = new SoundPlayer(@"C:\Users\hello\OneDrive\Documents\UTH\QUINTO CUATRIMESTRE\AppIoT\RAV\rav\bin\Debug\Grabacion.wav");
                sonido.Play();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {//Agregar
            string connectionString = "datasource=localhost;port=3306;username=root;password=123456;database=repositorio;";
            string query = "insert into usuarios values(NULL,'" + textBox3.Text + "','" + textBox4.Text + "','"
                + textBox5.Text + "','" + textBox6.Text + "')";
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

        private void button3_Click(object sender, EventArgs e)
        {//Eliminar
            string connectionString = "datasource=localhost;port=3306;username=root;password=123456;database=repositorio;";
            string query = "delete from usuarios where ID_USUARIO=" + textBox2.Text;
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
            string query = "update usuarios set USUARIO='" + textBox3.Text.Trim()
                + "', CUENTA='" + textBox4.Text.Trim()
                + "', CLAVE='" + textBox5.Text.Trim()
                + "', ROL='" + textBox6.Text.Trim()
                + "' where ID_USUARIO=" + textBox2.Text;
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

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\hello\OneDrive\Documents\UTH\QUINTO CUATRIMESTRE\AppIoT\VIDEO\Video\bin\Debug\Video.exe", "");
        }
    }
}
