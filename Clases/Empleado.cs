using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Catedra_PED
{
     class Empleado
    {
        //Esto se iba a ocupar para el manejo de seguridad, pero no se lo implemente
        //Para no entropecer el programa, ya que seria muy tardado comprobar a cada rato lo mismo

        protected string nombre{ get; set; }
        protected string apellido { get; set; }
        protected string id { get; set; }
        protected string sucursal { get; set; }
    }
}
