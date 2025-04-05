using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Catedra_PED.Clases
{
    internal class Gerente:Empleado
    {
        public Gerente(string nom, string apell) 
        {
            nombre = nom;
            apellido= apell;
            sucursal = "Gerente";
            id = "GE230331";
        
        }
    }
}
