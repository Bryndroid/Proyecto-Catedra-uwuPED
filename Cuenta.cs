using Proyecto_Catedra_PED.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Xml.Linq;

namespace Proyecto_Catedra_PED
{
    public partial class Cuenta : Form
    {
       
        public Cuenta()
        {
            InitializeComponent();

            //Se carga la ultima insercion del usuario para imprimir su información
            using (lanacaDB111 db = new lanacaDB111())
            {
                var imprimir = from datosS in db.Cliente
                               select datosS;
                foreach (Cliente a in imprimir)
                {
                    lbNom.Text = a.Nombre;
                    lbApell.Text = a.Apellido;
                    lbCorreo.Text = a.Correo;
                    lbMunicipio.Text = a.Dirreccion;
                    
                }



            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)  
        {

        }

        private void Cuenta_Load(object sender, EventArgs e)
        {
           
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbNom_Click(object sender, EventArgs e)
        {

        }
    }
}
