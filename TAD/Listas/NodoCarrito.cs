using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Catedra_PED.TAD.Listas
{
   public class NodoCarrito
    {

        public string nombre;
        public decimal valor;
        public int cantidad;
        public NodoCarrito sig;
        public NodoCarrito()
        {

        }
        public NodoCarrito(string n, decimal v, int c, NodoCarrito t
            ) 
        {
            nombre = n;
            valor = v;
            cantidad = c;
            sig = t;

        }

     
    }
}
