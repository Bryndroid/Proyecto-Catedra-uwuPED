using Proyecto_Catedra_PED.TAD.Listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Catedra_PED.Hash
{
    public class ListaM
    {
        int totnodos;
        NodoM inicio;

        public ListaM()
        {
            totnodos= 0;
            inicio = null;
        }

        public void InsertarI(NodoM a)
        {
           
            NodoM aux = new NodoM(a.nombreProducto,a.descripcion,a.id_Produ,a.precio);
       
            //inserta nodo al inicio del contenido de lista
            if (totnodos == 0)
                inicio = aux;
            else
            {
                aux.sig = inicio;
               inicio = aux;
            }
            totnodos++; //incrementa conteo de nodos
            
        }
        //Vector por si hay colisiones
        public NodoM[] Imprimir()
        {
            if (inicio== null)
            {

                return null;
            }
            else
            {
                int i = 0;
                NodoM[] aux = new NodoM[totnodos];
                NodoM nodoActual = inicio;
                while (nodoActual != null)
                {
                    aux[i] = nodoActual;
                    i++;
                    nodoActual = nodoActual.sig;
                }
                return aux;
            }

        }

        public NodoM RetornarAuto(string Clave)
        {
            //ubica a nodo que coincide con Clave/Key (Num. Placa de automovil)
            //si lo encuentra, retorna una copia del mismo.
            NodoM aux;
            NodoM encontrado;
            if (totnodos > 0)
            {
                aux = inicio;
                //inicia busqueda de nodo cuyo num. placa del automovil
                //coincida con la Clave usada por la tabla de dispersion
                //--Mientras no sea aux == null o se cumpla el if, seguira haciendo wea
                while (aux != null)
                {
                    if (aux.nombreProducto == Clave)
                    {
                        encontrado = aux;
                        //--Cuando lo encuentre, lo copiara en encontrado y  ese valor retornara.
                       
                        return encontrado;
                    }
                    aux = aux.sig;
                }
            }

            return null; //nodo solicitado no existe en lista
        }
        //Borrado-------------------------------------------
        public bool Remover(int indicenodo)
        {
           NodoM aux = inicio, aux2;
            if (totnodos > 0 && indicenodo <= totnodos)
            {
                if (indicenodo == 1) //primero
                    inicio= inicio.sig;
                else
                {
                    //Aqui la borrasion como comunmente se conoce
                    for (int c = 1; c < indicenodo - 1; c++) aux = aux.sig;
                    aux2 = aux.sig;
                    aux.sig = aux2.sig;
                    aux2.sig = null;
                }

                totnodos--;
                return true; //fue eliminado de la lista
            }
            return false; // nodo en posicion no existe en lista
        }

        //--Como dice referencia, solo se ocupa para eliminar 
        public int Buscar(string n)
        {
            //El indice es una propiedad, como en lista claves
            int c = 1;
           NodoM aux;
            if (totnodos > 0)
            {
                aux = inicio;

                //recorre todo el contenido de la lista
                while (aux != null)
                {
                    if (aux.nombreProducto == n)
                        return c; // retorna indice de posicion de nodo coincidente
                    c++; //actualiza conteo de indice de posicion
                    aux = aux.sig;
                }
            }
            return 0; //no encontro nodo coincidente con parametro recibido
        }
        //-----------------------------------------------------------
    
    }
}
