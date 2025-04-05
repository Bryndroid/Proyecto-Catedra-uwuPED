using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Catedra_PED.Hash
{
    //Ejemplos de hashing: todo el menúxd
    public class ListaC
    {
        int totnodos;
        NodoC inicio;
       


        public ListaC()
        {
            inicio = null;

        }
        public int Totclaves { get => totnodos; }
        //Posiblemente esto funciona para ver la wea imprimida en el listado de claves
        public NodoC[] VerConjuntoLlaves()
        {
            NodoC[] llaves = new NodoC[totnodos];
            int i = 0;
            //recorre contenido de nodos de lista y los almacena en vector
            NodoC aux = inicio;
            while (aux != null)
            {
                llaves[i++] = aux;

                aux = aux.sig;
            }
            return llaves;

        }
        //Verifica si existe por su nombre del producto o por su clave
        public bool Existe(string nombreP, string clave)
        {
            NodoC aux;
            //Si la clave es nada, se busca por su nombre
            if(clave != "")
            {
                if (totnodos > 0)
                {
                    aux = inicio;
                    while (aux != null)
                    {
                        if (aux.nombreP == nombreP )
                        {
                            return true;
                        }
                        aux = aux.sig;
                    }
                }
            }
            else
            {
                if (totnodos > 0)
                {
                    aux = inicio;
                    while (aux != null)
                    {
                        if (aux.nombreP == nombreP && aux.cadena == clave)
                        {
                            return true;
                        }
                        aux = aux.sig;
                    }
                }
            }
            return false;
        }
        //Retorna el codigo dado su codigo random 
        public string RetornarNombre(string codigo)
        {
            NodoC aux;
            if (totnodos > 0)
            {
                aux = inicio;
                while (aux != null)
                {
                    if (aux.cadena == codigo)
                    {
                        return aux.nombreP;
                    }
                    aux = aux.sig;
                }
            }
            return "";
        }
        //Siempre se inserta al inicio
        public bool Insertar(string ValorClave, string nombreP)
        {
            NodoC nue;
            if (!Existe(nombreP,ValorClave))
            {
                if (inicio == null)
                {
                    inicio = new NodoC(ValorClave, nombreP);
                }
                else
                {
                    nue = new NodoC(ValorClave, nombreP);
                    nue.sig = inicio;
                    inicio = nue;
                }
                totnodos++;
                return true;
            }
            return false;
        }

      
        public int BuscarPosicDe(string ValorClave)
        {
            //retorna posicion del nodo con ValorClave recibido (si existe)
            int pos = 1; //asume que Clave esta en 1er nodo de la lista
            NodoC aux;
            aux = inicio;
            while (aux != null)
            {
                if (aux.cadena == ValorClave)
                    //finaliza funcion, retornando posicion donde se encuentra Clave
                    return pos;
                aux = aux.sig;
                pos++;
            }
            return 0; //no existe Clave en el listado
        }

        public bool Borrar(string ValorClave)
        {
            int pos;
            NodoC ant, borrar;
            pos = BuscarPosicDe(ValorClave);
            if (pos > 0)
            {
                if (pos == 1)
                    inicio = inicio.sig;
                else
                {

                    ant = inicio;
                    borrar = ant.sig;
                    while (borrar != null)
                    {
                        //--Por cada vez que el while surja efecto, se evalua este if y se compara las weas
                        if (borrar.cadena == ValorClave)
                        {
                            //Y aqui lo que se hace es dejar de apuntar a borrar, y ahora ant.sig apunta a borrar.sig, o sea que borrar saleXD
                            ant.sig = borrar.sig;
                            break;
                        }
                        //Agarra el valor de borrar, por que borrar anteriormente agarraba el valor de .sig de inicio
                        //O sea apuntava a otro valor, ant se va moviendo
                        ant = borrar;
                        //Se cambia el valor de borrar al borrar .siguiente, borrar tambien se va moviendo 1 casilla mas (porasidecirlo)
                        //que ant
                        borrar = borrar.sig;

                    }
                }
                totnodos--;
                return true;
            }
            return false;
        }
    }
}
