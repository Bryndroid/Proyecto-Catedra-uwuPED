using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Proyecto_Catedra_PED.DB;
using Proyecto_Catedra_PED.TAD.Listas;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Runtime.CompilerServices;
using System.Drawing.Drawing2D;

namespace Proyecto_Catedra_PED.Categorias
{
    public partial class Carrito : Form
    {
        
        Carito1 lista2;
     
      
        //-----------------------------------
        public Carrito()
        {
            InitializeComponent();
            
        }
        public Carrito(Carito1 t)
        {
            InitializeComponent();

            lista2 = new Carito1();
            lista2 = t;
            area.BringToFront();


        }
        //Coordenadas iniciales de cada nodo
        int x = 10;
        int y = 20;
                            //Pido como argumento un groupbox, por que antes teniamos un panel, y estabamos probando
                            //que control era mejor, decidimos mejor el groupbox. Por eso quedo como argumento un control
                            // de windowsforms
        private void Imprimir(System.Windows.Forms.GroupBox groupBox, Carito1 lista)
        {
           //Limpia el area
            groupBox.Controls.Clear();

            //Si la lista tiene nodos, va a dibujar imprimir, de lo contrario no
            if(lista.Imprimir() != null)
             {
                //Guardo los nodos retornados (que son en modo de vector) y los guardo en un campo auxiliar del mismo tipo
                //de dato que retorna el metodo Imprimir...
                NodoCarrito[] aux = lista.Imprimir();
                //...para guardarlos en un string (vector) para luego clasificar esos datos en otro ciclo for
                string[] t = new string[lista.Imprimir().Length];
                for (int i = 0; i < lista.Imprimir().Length; i++)
                {
                    t[i] = aux[i].nombre;
                }
                // Recorrer la lista e imprimir los valores
                for (int i = 0; i < lista.Total(); i++)
                {

                    //Cambio de color dependiendo del contenido del texto
                    if (t[i].Contains("Tacos"))
                    {
                        
                        Imprimir(Color.Orange, t[i], groupBox);
                    }
                    else if (t[i].Contains("Burritos"))
                    {

                        Imprimir(Color.Red, t[i], groupBox);
                    }
                    else if (t[i].Contains("Torta"))
                    {
                        Imprimir(Color.Gold, t[i], groupBox);
                    }
                    else
                    {
                        //Si no se especifica que producto es, se considera una bebida
                        Imprimir(Color.Aqua, t[i], groupBox);
                    }



                }
            }
         
        }
        public void Imprimir(Color color, string i, System.Windows.Forms.GroupBox groupBox)
        {
            if (lista2.Buscar(i) != null)
            {
                System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                label.Text = i;
                label.BackColor = color;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Font = new Font("Arial", 9);
                label.Height = 30;
                label.Location = new System.Drawing.Point(x, y);
                label.Cursor = Cursors.Hand;
                //Se redacta la funcion en tipo formato Lambda, y se agrega los valores correspondientes de los nodos
                label.Click += (sender, e) =>
                {
                    lbnombre.Text = i;
                    lbtotal.Text = lista2.Buscar(i).valor.ToString();
                    cantidad.Value = lista2.Buscar(i).cantidad;
                    

                };

                groupBox.Controls.Add(label);
                // Actualizar la posición para el próximo valor
                if (x + label.Width < groupBox.Width-50)
                    x += label.Width + 10; // Añadir un espacio entre los valores
                else
                {
                    x = 10;
                    y += 40;

                }
            }
            

        }
        public void Reset()
        {
            x = 10;
           y = 20;
        }
        private void Carrito_Load(object sender, EventArgs e)
        {
            btnAceptar.Enabled = false;
            if(lista2.Imprimir()!=null)
            Imprimir(area, lista2);

            //Se verifica si hay descuentos:
            Descuentos();

        }
        //Funcion que calcula todos los descuentos...
        public void Descuentos()
        {
            //...Mediante condiciones
            if (lista2.Descuento() == 5 )
            {
                chk10.Checked = true;
                chk20.Checked = chk25.Checked = false;
                //Se cacalcula en el label pago el nuevo valor dependiendo del tipo de descuento
                lbpago.Text = (Math.Round(lista2.TotalValor() - lista2.TotalValor() * 0.10m, 2)).ToString();
            }
            else if (lista2.Descuento() == 4)
            {

                chk20.Checked = true;
                chk10.Checked = chk25.Checked = false;
                lbpago.Text = (Math.Round(lista2.TotalValor() - lista2.TotalValor() * 0.20m, 2)).ToString();
            }
            else if (lista2.Descuento() > 5)
            {

                chk25.Checked = true;
                chk20.Checked = chk10.Checked = false;
                lbpago.Text = (Math.Round(lista2.TotalValor() - lista2.TotalValor() * 0.25m, 2)).ToString();
            }
            else
            {
                chk10.Checked = chk20.Checked = chk25.Checked = false;
                lbpago.Text = lista2.TotalValor().ToString();
            }
           //Aclarar que solo 1 tipo de descuento puede estar activo, o sease, solo un checkbox puede estar
           //con su propiedad .checked en true
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
          
            using(lanacaDB111 db = new lanacaDB111())
            {
                //Para tabla Ventas
                Venta venta = new Venta();
                DateTime fechaActual = DateTime.Now;
                //No llamo al metodo TotalValor de la lista por que no considera el descuento
                decimal totalPago = decimal.Parse(lbpago.Text);
                int Id_Cliente = 0;
                int Id_Venta = 0;
                //---------------------------------
                //Imprimir ventas
                var imprimir = from datosS in db.Cliente
                               select datosS;
                foreach (Cliente a in imprimir)
                {
                    Id_Cliente = a.id_Cli;

                }
                //Imprimir para obtener el Id anterior de la Venta y sumarle 1
                var imprimir2 = from datosS in db.Venta
                               select datosS;
                foreach (Venta a in imprimir2)
                {
                    Id_Venta =a.id_Venta;

                }
                //Sumarle 1, porque no agregue identity xdd
                Id_Venta += 1;
               
                //----------------------------------------------------------------
                // Insercion en ventas
                //Funciona wey:D
                try
                {
                    venta.id_Venta = Id_Venta;
                    venta.id_Cli = Id_Cliente;
                    venta.total = totalPago;
                    venta.fecha = fechaActual;
                    venta.descripcion = "En espera";
                    db.Venta.Add(venta);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("a VER: " + ex);
                }

                //Ahora para productos xd

                NodoCarrito[] aux = lista2.Imprimir();

                for (int i = 0; i < aux.Length; i++)
                {
                    string nombreProducto = aux[i].nombre;
                    //Se encuentra el producto que coincida con este nombre
                    var producto = db.Producto.FirstOrDefault(p => p.Nombre == nombreProducto);

                    //Y si es distinto de nullo, se agrega
                    if (producto != null)
                    {
                        try
                        {
                            Venta_Productos venta_Productos = new Venta_Productos(); // Crear una nueva instancia en cada iteración
                            venta_Productos.id_Venta = Id_Venta;
                            venta_Productos.id_Produc = producto.id_Produc;
                            venta_Productos.cantidad = aux[i].cantidad.ToString();
                            db.Venta_Productos.Add(venta_Productos);
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                //Se vacia la lista, y se imprime
                lista2.Vaciar();
                Imprimir(area, lista2);


            }
            
          


        }

   

        private void gp1_Enter(object sender, EventArgs e)
        {

        }

        private void gp2_Enter(object sender, EventArgs e)
        {

        }
 
        private void AgrNodo_Tick(object sender, EventArgs e)
        {


         
           

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            lista2.Eliminar(lbnombre.Text);
            // Recorre todos los controles dentro del GroupBox
            foreach (Control control in area.Controls)
            {
                // Verifica si el control es un Label y si su texto coincide con el texto proporcionado
                if (control is System.Windows.Forms.Label && ((System.Windows.Forms.Label)control).Text == lbnombre.Text)
                {
                    // Elimina el Label encontrado
                    area.Controls.Remove(control);
                    // Luego, rompe el bucle si solo deseas eliminar el primer control con el texto especificado
                    break;
                }
            }
            //Hago elreseteo (coordenadas)
            Reset();
            //Y vuelvo a dibujar todo y evaluar todo
            Imprimir(area, lista2);
            Descuentos();
            if (lista2.ComprobarCan() != true)
                btnAceptar.Enabled = false;



        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void area_MouseHover(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //Btn nuevo
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            decimal a = decimal.Parse(lbtotal.Text);
            int aa = int.Parse(cantidad.Text);

            lista2.ModificarNodo(lbnombre.Text, a, aa);
            //Aplicando descuento
            Descuentos();
            //Comprobar si puede hacer la compra o aun no
            if (lista2.ComprobarCan() == true)
                btnAceptar.Enabled = true;
            else 
                btnAceptar.Enabled =false;
           


        }
       
        private async void cantidad_ValueChanged(object sender, EventArgs e)
        {
            //Mientras se cambia la cantidad del valor, se va imprimiendo en el label
            //Obviamente llamando a la bd para encontrar su valor
            using (lanacaDB111 db = new lanacaDB111())
            {
                var producto = await db.Producto.ToListAsync();
                foreach (var wea in producto)
                {
                    if (lbnombre.Text == wea.Nombre)
                    {
                        decimal a =(decimal)(decimal.Parse(cantidad.Text) * wea.precio);
                        if (lbtotal.Text == "1")
                            lbtotal.Text = wea.precio.ToString();
                        lbtotal.Text = a.ToString();

                       
                    }
                }

            }
        }

        private void lbtotal_Click(object sender, EventArgs e)
        {

        }
        public void ReseteoTotal()
        {
            lbtotal.Text = 0.ToString();
            lbnombre.Text = "Nombre del Producto";
            lbpago.Text = 0.ToString();
            cantidad.Value = 0;
            btnAceptar.Enabled = false;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            lista2.Vaciar();
            ReseteoTotal();
            Reset();
            Descuentos();
            Imprimir(area, lista2);
               
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void Carrito_Paint(object sender, PaintEventArgs e)
        {
            // Define los colores del degradado
            Color color1 = Color.Red;
            Color color2 = Color.Yellow;

            // Define la región del degradado
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            // Crea un LinearGradientBrush para el degradado
            LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, LinearGradientMode.Vertical);

            // Dibuja el degradado en el fondo del formulario
            e.Graphics.FillRectangle(brush, rect);
        }
    }
}
