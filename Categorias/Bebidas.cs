using Proyecto_Catedra_PED.TAD.Listas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Catedra_PED.Categorias
{
    public partial class Bebidas : Form
    {
        public Bebidas()
        {
            InitializeComponent();
            c1.Visible = c2.Visible = c3.Visible = c4.Visible
                = false;
        }

        private void Bebidas_Load(object sender, EventArgs e)
        {
            Cargado();
        }
        public void Cargado()
        {
            EstaEn(label4.Text, c1);
            EstaEn(label2.Text, c2);
            EstaEn(label1.Text, c3);
            EstaEn(label3.Text, c4);
        }

        private void EstaEn(string k, PictureBox c)
        {
            NodoCarrito aux = FormPrincipal.lista.Buscar(k);
            if (aux != null)
                c.Visible = true;
            else
                c.Visible = false;
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            bool a = FormPrincipal.lista.InsertarF(label4.Text, 0, 0);
            EstaEn(label4.Text, c1);
            if (a == false)
            {
                MessageBox.Show("El producto ya se encuentra en el carrito",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            bool a = FormPrincipal.lista.InsertarF(label2.Text, 0, 0);
            EstaEn(label2.Text, c2);
            if (a == false)
            {
                MessageBox.Show("El producto ya se encuentra en el carrito",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            bool a = FormPrincipal.lista.InsertarF(label1.Text, 0, 0);
            EstaEn(label1.Text, c3);
            if (a == false)
            {
                MessageBox.Show("El producto ya se encuentra en el carrito",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            bool a = FormPrincipal.lista.InsertarF(label3.Text, 0, 0);
            EstaEn(label3.Text, c4);
            if (a == false)
            {
                MessageBox.Show("El producto ya se encuentra en el carrito",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
