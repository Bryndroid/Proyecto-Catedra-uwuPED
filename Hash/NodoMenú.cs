using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Catedra_PED.Hash
{
    public class NodoM
    {
        //Nodo basado en sus atributos con su tabla de productos
        public string nombreProducto;
        public int? id_Produ;
        public string descripcion;
        public decimal? precio;
        public NodoM sig;


        public NodoM(string nombre, string descrip, int? id_pro, decimal? preci
            )
        {
            
                nombreProducto = nombre;
                id_Produ = id_pro;
                descripcion = descrip;
                precio = preci;
            sig = null;
          
        }
        public NodoM() { 
        }
    }
}
