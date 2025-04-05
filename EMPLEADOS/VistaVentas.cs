using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_Catedra_PED.DB;
using Proyecto_Catedra_PED.TAD.Listas;
using Proyecto_Catedra_PED.TAD;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.CompilerServices;

namespace Proyecto_Catedra_PED.EMPLEADOS
{
    public partial class VistaVentas : Form
    {
        //DIBUJO LABELS
        int x = 10;
        int y = 20;
        ColaVentas ven;
        Filtro agua;
        public VistaVentas()
        {
            InitializeComponent();
            ven= new ColaVentas();
            agua= new Filtro(ven);
           

        }
        //Misma logica empleada en el carrito
        public void Imprimir(Color color, int i, System.Windows.Forms.GroupBox groupBox)
        {

            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.Text = "Id_Venta: " + i.ToString();
            label.BackColor = color;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Height = 30;
            label.Location = new System.Drawing.Point(x, y);
            //Se redacta la funcion en tipo formato Lambda, y se agrega los valores correspondientes de los nodos
            label.Click += (a, d) =>
            {

                Desactivar();
                //Obteniendo cantidad xdd
                pList.Items.Clear();
                //BUSCAR POR ID COLA VENTAS 
                Nodo[]aux =ven.Buscar(i);
                NodoFiltro aux2 = agua.Buscar(i);

                foreach (var aa in aux)
                {
                    if (aa != null)
                    {
                        //Se imprime
                        pList.Items.Insert(0, aa.productos);
                        cliente.Text = aa.id_cliente.ToString();
                        
                        label11.Text = aux2.precio.ToString();
                       

                    }
                        
                }
             
                cant.Text = ven.cant(i).ToString();
                Desactivar();
               //Esta es la condicion que hace que se cumpla el LIFO
               //Si el valor es el primer dato, se activa el boton confi (que acepta compras) de lo contrario no
                if (agua.PrimerDato() != i)
                    btnConfi.Enabled = false;
                else 
                    btnConfi.Enabled=   true;

            };

            groupBox.Controls.Add(label);
            // Actualizar la posición para el próximo valor
            if (x + label.Width < groupBox.Width - 180)
                x += label.Width + 10; // Añadir un espacio entre los valores
            else
            {
                x = 10;
                y += 40;

            }

        }

            //}
        private void Impresion(System.Windows.Forms.GroupBox groupBox, Filtro cola)
        {
            // Limpiar el GroupBox
            groupBox.Controls.Clear();

            // Definir la posición inicial para dibujar
            if (cola.Imprimir() != null)
            {
                
                NodoFiltro[] c = cola.Imprimir();
                int[] t = new int[cola.Imprimir().Length];
                for (int i = 0; i < cola.Imprimir().Length; i++)
                {
                    t[i] = (int)c[i].id_ven;
                }
                // El parametro t[i] posiblemente lo quite por que...
                for (int i = 0; i < cola.Imprimir().Length; i++)
                {
                   
                    //Aqui van a ir con los diferentes colores de las ventas
                    if (ven.Prioridad(t[i])==1)
                    {

                        Imprimir(Color.Green, t[i], groupBox);
                    }
                    else if (ven.Prioridad(t[i]) == 2)
                    {

                        Imprimir(Color.Yellow, t[i], groupBox);
                    }
                    else if (ven.Prioridad(t[i]) == 3)
                    {
                        Imprimir(Color.Red, t[i], groupBox);
                    }
                    else
                    {
                        
                    }



                }
            }

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Primero insertando en ven para la prioridad
            using(lanacaDB111 db = new lanacaDB111())
            {
                // Realizamos una consulta para obtener los datos de las tablas Venta, Producto y Venta_Productos
                var ventaProductos = from vp in db.Venta_Productos

                                     join v in db.Venta on vp.id_Venta equals v.id_Venta
                                     //Tambien agregarle donde solo sean la descripcion en espera, por que si no
                                     // me agarra todas las ventas xdddd
                                     where v.descripcion == "En espera"
                                     join p in db.Producto on vp.id_Produc equals p.id_Produc

                                     select new
                                     {
                                         v.id_Venta,
                                         v.id_Cli,
                                         v.total,
                                         v.fecha,
                                         v.descripcion,
                                         p.id_Produc,
                                         p.Nombre,
                                         p.precio,
                                         vp.cantidad


                                     };

                foreach (var ventaProducto in ventaProductos)
                {
                    //En ventas se inserta valores donde su Id venta (en venta productos) se igual a la id venta
                    //Y donde el producto sea igual a id producto
                    //Todo esto con el fin no perder la relacion entre ventas. Que no una venta de id 1 tenga productos que 
                    //pertenezcan en otra id de venta
                    ven.Insertar(ventaProducto.id_Cli, ventaProducto.id_Venta, ventaProducto.Nombre,
                        int.Parse(ventaProducto.cantidad), ventaProducto.precio, (DateTime)ventaProducto.fecha);


                }
                //Obteniendo las primeras inserciones de ventas 
                var imprimir = from datosS in db.Venta
                               where datosS.descripcion == "En espera"
                               orderby datosS.id_Venta descending
                               select datosS;
               
              //Obteniendo las primeras vetnas de Id_Venta primero
              
                foreach (var wea in imprimir)
                {
                    
                    agua.Insertar(wea.id_Venta, wea.id_Cli, wea.total);
                }
           
               

            }
            //Funciona

            Impresion(area, agua);
            
        }

        private void area_Enter(object sender, EventArgs e)
        {

        }

  
        private void AgrNodo_Tick(object sender, EventArgs e)
        {

           
            

        }

      

       

        private void VistaVentas_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {

          
        }

      

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
            using (lanacaDB111 db = new lanacaDB111()) 
            {
                //Imprimiendo la informacion del cliente mediante un string builder
                var imprimir = from datosS in db.Cliente
                               select datosS;
                StringBuilder sb = new StringBuilder();
                foreach (var agua in imprimir)
                {
                    if(int.Parse(cliente.Text) == agua.id_Cli)
                    {
                        sb.Append("Info:");
                        sb.Append("\nNombre: " + agua.Nombre);
                        sb.Append("\nApellido: " + agua.Apellido);
                        sb.Append("\nCorreo: " + agua.Correo);
                        sb.Append("\nDireccion: " + agua.Dirreccion);
                    }
                 
                }
                MessageBox.Show(sb.ToString());
            }
            
        }

      

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dt1.Enabled = true;
            descripcion.Enabled = true;
            btnConfi.Enabled = true;
        }
        public void Desactivar()
        {
            //Desactivar todo por si no es el primer dato 
            dt1.Enabled = false;
            descripcion.Enabled = false;
           
            aceptado.Checked = false; denegado.Checked = false;
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void Reset()
        {
            x = 10;
            y = 20;
        }

        private void btnConfi_Click(object sender, EventArgs e)
        {
            NodoFiltro borrado = agua.BorrarPrimero();
            if (aceptado.Checked == true)
            {
            
                // Recorre todos los controles dentro del GroupBox
                foreach (Control control in area.Controls)
                {
                    // Verifica si el control es un Label y si su texto coincide con el texto proporcionado
                    if (control is System.Windows.Forms.Label && ((System.Windows.Forms.Label)control).Text == "Id_Venta: " + borrado.id_ven.ToString())
                    {
                        
                        // Elimina el Label encontrado
                        area.Controls.Remove(control);
                        // Luego, rompe el bucle si solo deseas eliminar el primer control con el texto especificado
                        break;
                    }
                }
                //Hago elreseteo
                Reset();
                //Y vuelvo a dibujar todo
                Impresion(area, agua);
               
                ven.AceptarVenta(dt1.Value, descripcion.Text, (int)borrado.id_ven, true);


            }
            else if(denegado .Checked == true) 
            {
                
                // Recorre todos los controles dentro del GroupBox
                foreach (Control control in area.Controls)
                {
                    // Verifica si el control es un Label y si su texto coincide con el texto proporcionado
                    if (control is System.Windows.Forms.Label && ((System.Windows.Forms.Label)control).Text == "Id_Venta: " + borrado.id_ven.ToString())
                    {
                        // Elimina el Label encontrado
                        area.Controls.Remove(control);
                        // Luego, rompe el bucle si solo deseas eliminar el primer control con el texto especificado
                        break;
                    }
                }
                //Hago elreseteo
                Reset();
                //Y vuelvo a dibujar todo
                Impresion(area, agua);
                ven.AceptarVenta(dt1.Value, descripcion.Text, (int)borrado.id_ven, false);
            }
          
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
