using Proyecto_Catedra_PED.Categorias;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Catedra_PED.TAD.Listas
{
    public  class Carito1
    {
        //OCUPAR VAINA STATICA. POR QUE NO NECESITA DE INSTANCIARSE PARA LLAMARSE BRO MIRA ESO JAJAJAAJJA SEXOOO
        private  NodoCarrito primerNodo;
        int totnodos;

        public Carito1()
        {
            primerNodo = null;
        }
        public int Total()
        {
            return totnodos;
        }
        public bool Insertar(string nombre, decimal valor, int cantidad)
        {
            if(nombre.Trim() != "" && cantidad < 99 && Comprobar(nombre)== false)
            {
                if (primerNodo == null)
                {
                    primerNodo = new NodoCarrito(nombre, valor, cantidad, null);
                    totnodos = 1;
                    
                }

                else
                {
                      
                        primerNodo = new NodoCarrito(nombre, valor, cantidad, primerNodo);
                    totnodos++;
                }
                return true;
            }
            return false;
        }
        public bool ComprobarCan()
        {
            NodoCarrito aux = primerNodo;
            if (aux == null)
                return false;
            while (aux != null)
            {
                if (aux.cantidad == 0)
                    return false;
                aux = aux.sig;
            }
            return true;
        }
        public bool InsertarF(string nombre, decimal valor, int cantidad)
        {
            if (nombre.Trim() != "" && cantidad < 99 && Comprobar(nombre) == false)
            {
                
                if (primerNodo == null)
                {
                    primerNodo = new NodoCarrito(nombre, valor, cantidad, null);
                    totnodos = 1;

                }

                else
                {
                    NodoCarrito aux = new NodoCarrito(nombre,valor,cantidad,null);
                    NodoCarrito aux1 = primerNodo;
                    while(aux1.sig != null)
                    {
                        aux1 = aux1.sig;
                    }
                    aux1.sig = aux;
                    totnodos++;
                }
                return true;
            }
            return false;
        }
        //Imprimir para el carrito
        public NodoCarrito[] Imprimir()
        {
            if (primerNodo == null)
            {
               
                return null;
            }
            else
            {
                int i = 0;
                NodoCarrito[] aux = new NodoCarrito[totnodos];
                NodoCarrito nodoActual = primerNodo;
                while (nodoActual != null)
                {
                    aux[i] = nodoActual;
                    i++;
                    nodoActual = nodoActual.sig;
                }
                return aux;
            }

        }

        public bool Comprobar(string t)
        {
            NodoCarrito aux = primerNodo;
            while(aux != null)
            {
                if (aux.nombre == t)
                    //El dato existe
                    return true;
                aux = aux.sig;
            }
            return false;
        }

        public void ModificarNodo(string nombre, decimal nuevoValor, int nuevaCantidad)
        {
            NodoCarrito actual = primerNodo;
            while (actual != null)
            {
                if (actual.nombre == nombre)
                {
                    actual.valor= nuevoValor;
                    actual.cantidad = nuevaCantidad;
                    return;
                }
                actual = actual.sig;
            }
            
        }

        public NodoCarrito Buscar(string nombre)
        {
            NodoCarrito aux = primerNodo;
            while(aux != null)
            {
                if (aux.nombre == nombre)
                    return aux;
                aux = aux.sig;
            }
            return null;
        }
        public void Eliminar(string valor)
        {
            NodoCarrito  actual = primerNodo;
            NodoCarrito anterior = null;

            while (actual != null && actual.nombre != valor)
            {
                anterior = actual;
                actual = actual.sig;
            }

            if (actual != null)
            {
                if (anterior == null)
                {
                    primerNodo = actual.sig;
                }
                else
                {
                    anterior.sig = actual.sig;
                }
                totnodos--;
            }
        }
        public void Vaciar()
        {
            primerNodo = null;
            totnodos = 0;
        }

        public decimal TotalValor()
        {
            NodoCarrito aux = primerNodo;
            decimal t = 0;
            while(aux!= null)
            {
                t += aux.valor;
                aux = aux.sig;
            }
            return t;
        }

        //Funcion para calcular el descuento
        public int Descuento()
        {
            NodoCarrito aux = primerNodo;
            //Lógica: hago un recorrido desde el primer nodo para ver cuantos valores contienen tacos y tortas en su nombre
            int  tacos = 0;
            int tortas = 0;
           
            while(aux!= null ) 
            {
                if (aux.nombre.Contains("Tacos"))
                    tacos++;
                if (aux.nombre.Contains("Torta"))
                    tortas++;
                aux = aux.sig;
            }
            //Luego evaluo esos contadores 
            if (tacos == 5 && tortas != 4)
            {
                //y retorno el que cumpla la igualdad ==
                return tacos;
            }
            else if(tortas == 4 && tacos != 5 )
            {
                return tortas;
            }
            else if (tortas == 4 && tacos == 5)
            {
                //Si no cumple, entonces hago una sumatoria, esto con el fin para diferenciar de los valores anteriores
                //que siempre son 5 o 4 el tope
                int aux2 = tacos + tortas;
                return aux2;
            }
            //son 5 y 4 el tope por la cantidad de productos almacenados en el programa, si se agrega más
            //Solamente se tiene que modificar el numero 4 o 5 dependiendo de la cantidad que se ha agregado
           
            return -1;
        
        }


    }
}
