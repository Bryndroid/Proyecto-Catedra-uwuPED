using Proyecto_Catedra_PED.TAD.Listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Catedra_PED
{
    //Nodo para ventas, venta_productos y producto (combinación).
    public class Nodo
    {
        
        public int? id_cliente;
        public int? id_Venta;
        public string productos;
        public decimal? total;
        public int cant;
        public DateTime fecha;
        public Nodo sig;
        public Nodo()
        {

        }
        public Nodo(int? id_cli,int? id_ven, string pro, decimal? tot,int cat, DateTime fe, Nodo Zsig)
        {
            id_cliente= id_cli;
            id_Venta= id_ven;
            productos = pro;
            cant = cat;
            total= tot;
            fecha= fe;
            sig = Zsig;
            
            
        }

        
    }
}
