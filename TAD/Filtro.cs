using Proyecto_Catedra_PED.DB;
using Proyecto_Catedra_PED.TAD;
using Proyecto_Catedra_PED.TAD.Listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Catedra_PED
{
    class Filtro
    {
       //Esta cola traera los datos que estan  que estan en la tabla ventas.
       //Sin necesidad de tener la fecha o de la descripcion, ya que solo se trabajara los campos necesarios
        private NodoFiltro inicio;
        private NodoFiltro final;
        private int totnodos;
        //A este tengo que llamar
        public ColaVentas ventas;

        public Filtro(ColaVentas agua)
        {
            inicio = null;
            ventas = agua;
            totnodos = 0;
        }
        //Tacos: 1-3 u. Facil
        //Tortas: 1-3 u. Medio
        //Burritos: 1- 4 u. Medio
        //Bebidas: Todas faciles:
        //Vamos a hacer llamado a la tabla producto
        public void Insertar(int? id_Venta, int? cliente, decimal? total)
        {
            //Se inserta las cosas acorde a su prioridad (metodo prioridad declarado en ventas)
          
         
                if (ventas.Prioridad((int)id_Venta) == 1)
                {
                    NodoFiltro aux = new NodoFiltro(cliente, id_Venta, total);
                    if (inicio == null)
                    {
                        inicio = final = aux;
                    }
                    else
                    {
                        // Si la lista no está vacía, el nuevo nodo apunta al nodo actualmente en la cabeza de la lista
                        aux.sig = inicio;
                        // Actualizamos el inicio para que apunte al nuevo nodo
                        inicio = aux;
                    }
                    totnodos++;
                }
                else if (ventas.Prioridad((int)id_Venta) == 2)
                {
                    NodoFiltro aux = new NodoFiltro(cliente, id_Venta, total);
                    if (inicio == null)
                    {
                        inicio = final = aux;
                    }
                    else
                    {
                        NodoFiltro temp = inicio;
                        NodoFiltro prev = null;

                        //Buscamos la posición donde insertar la venta con prioridad 2
                        while (temp != null && ventas.Prioridad((int)temp.id_ven) == 1)
                        {
                            prev = temp;
                            temp = temp.sig;
                        }

                        //Si llegamos al final de la lista o encontramos una venta con prioridad 2 o 3, insertamos después de la última venta con prioridad 1
                        if (temp == null)
                        {
                            final.sig = aux;
                            final = aux;
                        }
                        else
                        {
                            prev.sig = aux;
                            aux.sig = temp;
                        }
                    }
                    totnodos++;
                }
                //Si no se cumple y la prioridad es igual a 3 siempre irá de ultimo
                else if (ventas.Prioridad((int)id_Venta) == 3)
                {
                    NodoFiltro aux = new NodoFiltro(cliente, id_Venta, total);
                    if (inicio == null)
                    {
                        inicio = final = aux;
                    }
                    else
                    {
                        final.sig = aux;
                        final = aux;
                    }
                    totnodos++;
                }
            


        }
        public int totalNodos()
        {
            return totnodos;
        }
        public NodoFiltro[] Imprimir()
        {
            if (inicio == null)
            {

                return null;
            }
            else
            {
                int i = 0;
                NodoFiltro [] aux = new NodoFiltro[totnodos];
                NodoFiltro nodoActual = inicio;
                while (nodoActual != null)
                {
                    aux[i] = nodoActual;
                    i++;
                    nodoActual = nodoActual.sig;
                }
                return aux;
            }

        }
        //Método necesario para que se cumpla el LIFO
        public int PrimerDato()
        {
            if (inicio != null)
            {
                return (int)inicio.id_ven;
            }
            return 0;
        }
        public NodoFiltro BorrarPrimero()
        {
            NodoFiltro guardado;
            if(inicio!= null)
            {
                guardado = inicio;
                
                inicio = inicio.sig;
                totnodos--;
                return guardado;

            }
            else
            {
                final = null;
                totnodos = 0;
                return null;
            }
        }
        public NodoFiltro Buscar(int id)
        {
            if (IdExiste(id) == true)
            {
                NodoFiltro aux = inicio;
                NodoFiltro vec = new NodoFiltro();
            
                while (aux != null)
                {
                    if (aux.id_ven == id)
                    {

                        vec = aux;
                    }

                    aux = aux.sig;
                }
                return vec;
            }

            return null;
        }
        //ocupado para evitar duplicacion de datos
        public bool IdExiste(int id)
        {
            NodoFiltro aux = inicio;
            while (aux != null)
            {
                if (aux.id_ven == id)
                    return true;
                aux = aux.sig;
            }
            return false;
        }
      
    }
  
}




