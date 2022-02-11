using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rav
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void aplicacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void pruebasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void reportesPorUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
        }

        private void aplicacionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
        }

        private void pruebasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();
        }

        private void resultadosPorAplicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.Show();
        }

        private void resultadosPorPruebasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.Show();
        }

        private void resultadoPorUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14();
            f14.Show();
        }

        private void aplicacionesPorPruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form15 f15 = new Form15();
            f15.Show();
        }

        private void aplicacionesPorUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.Show();
        }

        private void pruebasPorPeriodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17();
            f17.Show();
        }

        private void aplicacionesPorPeriodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form18 f18 = new Form18();
            f18.Show();
        }

        private void resultadosPorPeriodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form19 f19 = new Form19();
            f19.Show();
        }

        private void sumarioDeResultadosPorAplicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form20 f20 = new Form20();
            f20.Show();
        }

        private void sumarioDeResultadosPorPruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form21 f21 = new Form21();
            f21.Show();
        }

        private void sumarioDeResultadosPorUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form22 f22 = new Form22();
            f22.Show();
        }

        private void sumarioDeAplicacionesPorPruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form23 f23 = new Form23();
            f23.Show();
        }

        private void sumarioDeAplicacionesPorTrazabilidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form24 f24 = new Form24();
            f24.Show();
        }
    }
}
