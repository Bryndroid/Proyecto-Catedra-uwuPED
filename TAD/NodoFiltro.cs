using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Catedra_PED.TAD
{
   public  class NodoFiltro
    {
        //Parametros coincidentes a la tabla Venta (sin el campo fecha)
        public int? id_cliente;
        public int? id_ven;
        public decimal? precio;
        public NodoFiltro sig;
        public NodoFiltro(int? id_cli,int? id_v, decimal? preci) 
        { 
            id_cliente = id_cli;
            id_ven= id_v;
            precio = preci;
            sig = null;
        
        }

        public NodoFiltro()
        {
            id_cliente= 0;
            id_ven= 0;
            precio= 0;
            sig = null;
        }
    }
}
