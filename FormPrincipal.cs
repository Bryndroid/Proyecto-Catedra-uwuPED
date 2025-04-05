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

namespace Proyecto_Catedra_PED
{ 
    public partial class FormPrincipal : Form
    {
        bool cambio = false;
     
        //La lista
        public static Carito1 lista;
        public FormPrincipal()
        {
            InitializeComponent();
        //Se crea la lista estatica
            lista = new Carito1();
            //Se guarda el form inicio de un solo en el constructor
            AbrFrmPnl(new Inicio());
            //Se ajusta el ancho de la barra lateral izquierda
            pnlOpciones.Width = 70;
            Cambio.Start();
        }

        private void btnbarras_Click(object sender, EventArgs e)
        {
            //Para ajustar el ancho de las categorias (botones)
            if(pnlOpciones.Width==70)
            {
                pnlOpciones.Width = 250;
            }
            else
                pnlOpciones.Width = 70;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            //Importante apagar el tick
            Cambio.Stop();
            Application.Exit();
        }
        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Método para abrir formularios en el panel
        private void AbrFrmPnl(object FormHijo)
        {
            if (this.pnlContenedor.Controls.Count > 0)
                this.pnlContenedor.Controls.RemoveAt(0);
            Form formhijo = FormHijo as Form;
            formhijo.TopLevel = false;
       
            formhijo.Dock = DockStyle.Fill;
            this.pnlContenedor.Controls.Add(formhijo);
            this.pnlContenedor.Tag= formhijo;
            formhijo.Show();
        }
        private void btnInicio_Click(object sender, EventArgs e)
        {
            //Se abren los forms en forma de panel. (lógica para todos lo mismo)
            AbrFrmPnl(new Inicio());
        }

        private void btnTacos_Click(object sender, EventArgs e)
        {
            AbrFrmPnl(new Tacos());
        }

        private void btnBurritos_Click(object sender, EventArgs e)
        {
            AbrFrmPnl(new Burritos());
        }

        private void btnTortas_Click(object sender, EventArgs e)
        {
            AbrFrmPnl(new Torta());
        }

        private void btnBebidas_Click(object sender, EventArgs e)
        {
            AbrFrmPnl(new Bebidas());
        }
  
        private void btnCarrito_Click(object sender, EventArgs e)
        {

                //Se carga el formulario del carrito con parametro de la lista estatica
            AbrFrmPnl(new Carrito(lista));


        }

        private void btnExtras_Click(object sender, EventArgs e)
        {
            AbrFrmPnl(new Extras());
        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
     
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Cambio_Tick(object sender, EventArgs e)
        {
            //Cambio de colores para la categoria Especial
            if (cambio)
            {
                btnEspe.ForeColor= Color.Red;
            }
            else
            {
                btnEspe.ForeColor= Color.Blue;
            }

            cambio = !cambio;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Se visualiza la cuenta. sin necesidad de plasmarlo en el formulario
            Cuenta a = new Cuenta();
            a.ShowDialog();
        }

  
    }
}
