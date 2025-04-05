using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Catedra_PED.Hash
{
    public class NodoC
    {
        //Nodo con valor de su cadena y nombreP, para facilitar su busqueda e imprimir
        //en el datagrid su nombre y cadena
        public string cadena;
        public string nombreP;
        public NodoC sig;
        public NodoC(string key, string nombreP1)
        {
            sig = null;
            nombreP = nombreP1;
            cadena = key;
        }
    }
}
