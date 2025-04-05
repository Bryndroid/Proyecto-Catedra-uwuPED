using Proyecto_Catedra_PED.DB;
using Proyecto_Catedra_PED.Heap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Catedra_PED.EMPLEADOS
{
    public partial class Almacenamiento : Form
    {
        private Inventario inventario = new Inventario();
        public Almacenamiento()
        {
            InitializeComponent();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void Almacenamiento_Load(object sender, EventArgs e)
        {
            using(lanacaDB111 db= new lanacaDB111())
            {
                var p = from datosS in db.existencias
                        select datosS;
            
                foreach (var wea in p)
                {
                    //Adentro del foreach para que se peuda ingreasar todos los datos
                    Productos nuevoProducto = new Productos();
                    nuevoProducto.Nombre = wea.nombre;
                    nuevoProducto.Tipo = ConvertirColor(wea.tipo);
                    nuevoProducto.Cantidad = (int)wea.cantidad;
                    nuevoProducto.FechaVencimiento = (DateTime)wea.fecha;
                    nuevoProducto.Precio = (double)(decimal)wea.precio;
                    inventario.Insertar(nuevoProducto);
                }
               
                
            }
            inventario.MostrarInventario(dataGridView);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
                Productos nuevoProducto = new Productos
                {
                    Tipo = ConvertirColor(""),
                    Nombre = txtnombre.Text,
                    Cantidad = Convert.ToInt32(txtCantidad.Text),
                    FechaVencimiento = dateTimePickerFechaVencimiento.Value,
                    Precio = Convert.ToDouble(txtPrecio.Text)
                };

                // Agregar el nuevo producto al inventario
                inventario.Insertar(nuevoProducto);

                // Limpiar los TextBox después de agregar el producto
                inventario.MostrarInventario(dataGridView);
                comboBox1.SelectedIndex = -1;
                txtCantidad.Clear();
                txtPrecio.Clear();
          
            
        }
        private Color ConvertirColor(string t)
        {
            //Se convierte el color dependiendo del texto
            if(t == "")
            {
                if (comboBox1.Text == "Fácil")
                {
                    return Color.Blue;
                }
                else if (comboBox1.Text == "Mediano")
                {
                    return Color.Orange;
                }
                else if (comboBox1.Text == "Alto")
                {
                    return Color.Red;
                }
                else
                {
                    return Color.Black;
                }
            }
            else
            {
                if (t == "Fácil")
                {
                    return Color.Blue;
                }
                else if (t== "Mediano")
                {
                    return Color.Orange;
                }
                else if (t == "Alto")
                {
                    return Color.Red;
                }
                else
                {
                    return Color.Black;
                }
            }
          
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0) // Verifica si hay una fila seleccionada
            {
                int indiceFila = dataGridView.SelectedRows[0].Index; // Obtén el índice de la fila seleccionada
                dataGridView.Rows.RemoveAt(indiceFila); // Elimina la fila del DataGridView
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
