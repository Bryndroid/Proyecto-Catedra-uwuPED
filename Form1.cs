using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Catedra_PED.DB;

namespace Proyecto_Catedra_PED
{
    public partial class Form1 : Form
    {
     
        //Para el cambio en el color del texto "Inicio sesion"
        private bool cambio = true;
       
        public Form1()
        {
            
            InitializeComponent();
           
            
            CambioColor.Start();
        }
  
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }


        private void Form1_Leave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CambioColor_Tick(object sender, EventArgs e)
        {
           //Codigo para cambiar el color deL inicio sesion, con un ciclo continuo
                if (cambio)
                {
                    lbsesion.ForeColor = Color.Yellow;
                    lbinicia.ForeColor = Color.Red;
                }
                else
                {
                    lbsesion.ForeColor = Color.Red;
                   lbinicia.ForeColor = Color.Yellow;
                }
                //Gracias a esto, que da el valor opuesto al que tiene el cambio
               cambio = !cambio; 


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            //Aqui se llamara a la base de datos para guardar toda la informacion del cliente
            using(lanacaDB111 db = new lanacaDB111())
            {
                
                try
                {
                    //Condiciones para no tener datos vacios en el cliente
                   if(txtName.Text.Trim() != "" && txtApelli.Text.Trim() != "" && txtCorreo.Text.Trim() != "")
                    {
                        Cliente clin = new Cliente();
                        clin.Nombre = txtName.Text;
                        clin.Apellido = txtApelli.Text;
                        clin.Correo = txtCorreo.Text;
                        clin.Dirreccion = cbMunicipio.Text;
                        try
                        {
                            db.Cliente.Add(clin);
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error en la base de datos:  " + ex);
                        }
                        //Se crea el objeto agua para crear el form principal
                        FormPrincipal agua = new FormPrincipal();
                        agua.label1.Text = txtName.Text;
                        //Y se esconde este formulario
                        agua.Show();
                        this.Hide();
                        //Se detiene el timer
                        CambioColor.Stop();
                    }
                    else
                    {
                        MessageBox.Show("Complete todo los campos.", "Error", MessageBoxButtons.OK);
                    }
                  
                }
                catch (Exception)
                {
                    MessageBox.Show("Error en la toma de datos");
                }
                //Comente todo por que pensaba que eso era el overflow
            }
          
          
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Escribe_Tick(object sender, EventArgs e)
        {
           
            
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
