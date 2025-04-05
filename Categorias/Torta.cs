using Proyecto_Catedra_PED.Categorias;
using Proyecto_Catedra_PED.DB;
using Proyecto_Catedra_PED.TAD.Listas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proyecto_Catedra_PED.Categorias
{
    public partial class Torta : Form
    {
        public Torta()
        {
            InitializeComponent();
            c1.Visible = c2.Visible = c3.Visible = c4.Visible
                 = false;
        }
        private void EstaEn(string k, PictureBox c)
        {
            NodoCarrito aux = FormPrincipal.lista.Buscar(k);
            if (aux != null)
                c.Visible = true;
            else
               c.Visible = false;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            bool a = FormPrincipal.lista.InsertarF(label3.Text, 0, 0);
            EstaEn(label3.Text, c1);
            if (a == false)
            {
                MessageBox.Show("El producto ya se encuentra en el carrito",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bool a = FormPrincipal.lista.InsertarF(label2.Text, 0, 0);
            EstaEn(label2.Text, c3);
            if (a == false)
            {
                MessageBox.Show("El producto ya se encuentra en el carrito",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            bool a = FormPrincipal.lista.InsertarF(label5.Text, 0, 0);
            EstaEn(label5.Text, c2);
            if (a == false)
            {
                MessageBox.Show("El producto ya se encuentra en el carrito",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            bool a = FormPrincipal.lista.InsertarF(label7.Text, 0, 0);
           EstaEn(label7.Text, c4);
            if (a == false)
            {
                MessageBox.Show("El producto ya se encuentra en el carrito",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Cargado()
        {
            EstaEn(label7.Text, c4);
            EstaEn(label5.Text, c2);
            EstaEn(label3.Text, c1);
            EstaEn(label2.Text, c3);

        }
        private void Torta_Load(object sender, EventArgs e)
        {
            Cargado();
        }

        private void c1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
