using Proyecto_Catedra_PED.DB;
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
    public partial class Burritos : Form
    {
        //Hacer aqui el TAD
        Carito1 mandar;
        int i = 0;
        public Burritos()
        {
            InitializeComponent();

            c1.Visible = c2.Visible = c3.Visible
                  = false;
           
        }
        
        private void Burritos_Load(object sender, EventArgs e)
        {
            Cargado();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
           bool a = FormPrincipal.lista.InsertarF(label3.Text, 0, 0);
            EstaEn(label3.Text, c1);
            if (a== false)
            {
                MessageBox.Show("El producto ya se encuentra en el carrito", 
                    "Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            //El indice 0, eso estara determinado por el hashing
            //FormPrincipal.vegeta++;
            //FormPrincipal.pop[FormPrincipal.vegeta] = label3.Text;


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
        private void EstaEn(string k, PictureBox c)
        {
            NodoCarrito aux = FormPrincipal.lista.Buscar(k);
            if (aux != null)
                c.Visible = true;
            else
                c.Visible = false;
        }
        private void Cargado()
        {
            EstaEn(label3.Text, c1);
            EstaEn(label5.Text, c2);
            EstaEn(label2.Text, c3);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
