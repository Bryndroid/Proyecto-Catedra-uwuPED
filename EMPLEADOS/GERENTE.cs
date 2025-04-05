using Proyecto_Catedra_PED.DB;
using Proyecto_Catedra_PED.Hash;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_Catedra_PED.EMPLEADOS
{
    public partial class GERENTE : Form
    {
        //LA CONTRASEÑA PARA VISUALIZAR EL CONTENIDO ES ESTA IMPORTANTE!!!!!
        string contra = "elpepe";
        int x, y;
        THash tabla;
    
        public GERENTE()
        {
            InitializeComponent();
           //Se crea la tabla hash
            tabla = new THash();
       
            //Para simular un textbox pa contraseña
            txtContra.UseSystemPasswordChar= true;
            //Definiendo propiedades
            dtView.Visible = false;
            txtprecio.Visible =txtnombre.Visible =false;
            chk1.Enabled = chk2.Enabled = false;
            btnconfiC.Enabled = btnregreC.Enabled = false;
            btncerrar.Visible = false;



        }

    
        private void GERENTE_Load(object sender, EventArgs e)
        {
            //Cuando se cargue este form, se cargaran todos los productos y se calculara su Hashing
            using(lanacaDB111 db = new lanacaDB111())
            {
                var imprimir = from datoss in db.Producto
                               select datoss;

                foreach(var wea in imprimir)
                {
                    //Con tru por que se trata de ingreso de la bd
                    tabla.InsertarDefault(impresion(wea.Nombre, wea.id_Produc, wea.precio, wea.descripcion), true);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
       
        public void Movimiento(bool t)
        {
            //Movimiento para cuando se ingrese bien la contra
            x= dtView.Location.X;
            y= dtView.Location.Y;
            if (t == true)
            {
                dtView.Location = new Point(x, y - 50);
                btncerrar.Visible = true;

            }
            else
            {
                dtView.Location = new Point(x, y + 50);
                
                btncerrar.Visible = false;
            }
              
        }
        //Boton donde ingresa contraseña
        private void button3_Click(object sender, EventArgs e)
        {
            if (txtContra.Text == contra)
            {
                dtView.Visible = true;
                dtView.BringToFront();
                Movimiento(true);

                ActualizarDt();
            }
        }
        public void ActualizarDt()
        {
            NodoC[] p = tabla.VerLlaves();
            dtView.Rows.Clear();
            foreach (var clave in p)
            {

                // Agregar elemento al Dtgd
                dtView.Rows.Add(clave.nombreP, clave.cadena);
            }
        }
        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            txtprecio.Visible = true;
            chk1.Visible = false;
        }

        private void chk2_CheckedChanged(object sender, EventArgs e)
        {
            
            txtnombre.Visible = true;
            chk2.Visible = false;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Dialogos para evitar errores humanos
            DialogResult r = MessageBox.Show("¿No modificar el valor?","",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if(r == DialogResult.Cancel)
            {
                Textos(true);
            }
            else if(r == DialogResult.No)
            {
                Textos(false);
            }
           
        }
        void Reset()
        {
            //Reseteando valores predeterminados para los labels
            lbnombre.Text = "NOMBREPRODUCTO";
            lbprecio.Text = "PRECIO";
            lbdescripcion.Text = "DESCRIPCION";
            lbid.Text = "IDPRODUCTO";
            txtclave.Text = "";
            txtclave.Focus();
        }
        private void Textos(bool quiere)
        {
            if(quiere == true)
            {
                chk1.Checked = chk2.Checked = false;
                chk1.Visible = chk2.Visible = true;
                chk1.Enabled = chk2.Enabled = true;
                txtnombre.Visible = txtprecio.Visible=false;
                btnconfiC.Enabled = btnregreC.Enabled = true;


            }
            else
            {
                chk1.Enabled = chk2.Enabled = false;
                chk1.Visible = chk2.Visible = true;
                chk1.Checked = chk2.Checked = false;
                txtnombre.Visible = txtprecio.Visible = false;
                btnconfiC.Enabled = btnregreC.Enabled = false;

            }
        }
        private void button5_Click(object sender, EventArgs e)
        { 
            if(txtnombre.Text != "" && txtprecio.Text != "")
            {
               NodoM a= impresion(txtnombre.Text, int.Parse(lbid.Text), decimal.Parse(txtprecio.Text), "Cambiado");
                tabla.ModificarNodo(txtclave.Text, a, false);
                ActualizarDt();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string clave = txtclave.Text;
            NodoM a = tabla.BuscarC(clave);
            DialogResult r = MessageBox.Show("Se eliminara el producto: " + a.nombreProducto + " de la base de datos", "Advertencia"
                , MessageBoxButtons.YesNo);
            if(r == DialogResult.Yes)
            {
                tabla.Borrar(clave, true);
                Reset();
                ActualizarDt();
            }
            else
            {
                
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(txtclave.Text.Trim() == "")
            {
                MessageBox.Show("Digite una clave");
                txtclave.Focus();
            }
            else
            {
                Textos(true);
            }
           
        }
        public NodoM impresion(string n, int? i, decimal? p, string d)
        {
            NodoM a = new NodoM();
            a.nombreProducto = n;
            a.id_Produ = i;
            a.precio = p;
            a.descripcion = d;
            return a;
        }
      
    

        private void button2_Click(object sender, EventArgs e)
        {
            dtView.Visible = false;
            txtContra.Text = "";
            gp1.Visible = true;
            Movimiento(false);
        }

       

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void dtView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Proceso de ingresion de nueva vaina pa producto
           
            tabla.InsertarDefault(impresion(txtNom.Text, int.Parse(txtId.Text), 
                decimal.Parse(txtpr.Text), txtdescrip.Text), false);
            ActualizarDt();
            Vaciar();
        }
        void Vaciar()
        {
            txtNom.Text = txtId.Text = txtpr.Text = txtdescrip.Text= "";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Vaciar();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NodoM c = tabla.BuscarC(txtclave.Text);
            if(c != null)
            {
                lbnombre.Text = c.nombreProducto;
                lbid.Text = c.id_Produ.ToString();
                lbprecio.Text = c.precio.ToString();
                lbdescripcion.Text = c.descripcion;
            }
            else
            {
                MessageBox.Show("No se encuentra la clave","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
