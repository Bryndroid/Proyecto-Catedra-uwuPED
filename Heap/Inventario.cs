using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Catedra_PED.Heap
{
    public  class Inventario
    {


        private Nodo raiz;

        public Inventario()
        {
            raiz = null;
        }

        //Nodo tiene derecha e izquierda
        public void Insertar(Productos item)
        {
            Nodo nuevoNodo = new Nodo(item);
            //Si la raiz esta nulla
            if (raiz == null)
            {
                //Ese valor se agrega directo al arbol
                raiz = nuevoNodo;
            }
            else
            {
                //Si ya hay raiz, se aplica recursion
                AgregarNodo(raiz, nuevoNodo);
            }
        }

        private void AgregarNodo(Nodo padre, Nodo nuevo)
        {
            //Evalua primero los datos de fecha de vencimiento, para comprobar si la fecha del nuevo nodo
            //es mayor a la de su padre
            if (nuevo.Item.FechaVencimiento > padre.Item.FechaVencimiento)
            {
                //Si se cumple, tendrá que determinar si ya existe un nodo en su derecha,
                // si no existe, se ingresara en su lugar
                if (padre.Derecha == null)
                {

                    padre.Derecha = nuevo;
                }
                else
                {
                    //En cambio, se aplica de nuevo la recursividad
                    AgregarNodo(padre.Derecha, nuevo);
                }
            }
            else
            {//Misma lógica para el sub arbol izquierdo

                if (padre.Izquierda == null)
                {
                    padre.Izquierda = nuevo;
                }
                else
                {
                    AgregarNodo(padre.Izquierda, nuevo);
                }
            }
        }

        public void MostrarInventario(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear(); //Limpia el data
            MostrarNodos(raiz, dataGridView); //logiva para mostrar los productos en el data
        }

        private void MostrarNodos(Nodo nodo, DataGridView dataGridView)
        {
            //Recorrido inOrden del arbol
            if (nodo != null)
            {
                MostrarNodos(nodo.Izquierda, dataGridView);

                // Agregar los datos a las columnas específicas del DataGridView
                int rowIndex = dataGridView.Rows.Add();
                dataGridView.Rows[rowIndex].Cells["TipoProductoColumna"].Style.BackColor = nodo.Item.Tipo;
                dataGridView.Rows[rowIndex].Cells["Nombre222"].Value = nodo.Item.Nombre;
                dataGridView.Rows[rowIndex].Cells["CantidadColumna"].Value = nodo.Item.Cantidad;
                dataGridView.Rows[rowIndex].Cells["FechaVencimientoColumna"].Value = nodo.Item.FechaVencimiento;
                dataGridView.Rows[rowIndex].Cells["PrecioColumna"].Value = nodo.Item.Precio;

                MostrarNodos(nodo.Derecha, dataGridView);
            }
        }
    }
}

