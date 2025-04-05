using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Catedra_PED.Clases
{
    internal class Mozo:Empleado
    {

        public Mozo(string nom, string apell) 
        {
         nombre = nom;
          apellido = apell;
            sucursal = "Personal Almacen";
            id = "MZ230331";
        }
    }
}
