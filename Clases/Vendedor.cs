using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Catedra_PED.Clases
{
    internal class Vendedor : Empleado
    {

        public Vendedor(string nom, string apell)
        {
            nombre = nom;
            apellido = apell;
            sucursal = "Ventista";
            id = "VD230331";
        }
    }
}
