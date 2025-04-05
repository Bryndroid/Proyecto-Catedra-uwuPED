using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Catedra_PED.Heap
{
   public class Nodo
    {
        public Productos Item { get; set; }
        public Nodo Izquierda { get; set; }
        public Nodo Derecha { get; set; }

        public Nodo(Productos item)
        {
            Item = item;
            Izquierda = null;
            Derecha = null;
        }
    }
}
