using Proyecto_Catedra_PED.Categorias;
using Proyecto_Catedra_PED.DB;
using Proyecto_Catedra_PED.TAD.Listas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Proyecto_Catedra_PED.TAD
{
    public class ColaVentas
    {
        //Cola ventas ocupada para alojar varios datos (explicados en su nodo)
        Nodo primerNodo;
        Nodo ultimoNodo;
        int totnodos = 0;
      
        public ColaVentas()
        {

        }

        //Insertando siempre al inicio, sin necesidad de importar el Orden
        public void Insertar(int? id_cli, int? id_ven, string pro, int t, decimal? tot, DateTime fe)
        {
          
            
                Nodo aux = new Nodo(id_cli, id_ven, pro, tot, t, fe, null);
                if (primerNodo == null)
                {
                    primerNodo = ultimoNodo = aux;

                }
                else
                {
                    ultimoNodo.sig = aux;
                    ultimoNodo = aux;
                }
                totnodos++;
          
           
         
        }

        public int total()
        {
            return totnodos;
        }
        //Método buscar empleado para el encuentro de Id coincidiente
        public Nodo[] Buscar(int id)
        {
            if (IdExiste(id) == true)
            {
                Nodo aux = primerNodo;
                Nodo[] vec = new Nodo[totnodos];
                int i = 0;
                while (aux != null)
                {
                    if (aux.id_Venta == id)
                    {

                        vec[i] = aux;
                        i++;
                    }

                    aux = aux.sig;
                }
                return vec;
            }

            return null;
        }
       //Método ocupado para imprimir la cantidad sumada de los productos donde se coincida el id
        public int cant(int id)
        {
            Nodo aux = primerNodo;
            int TOT = 0;
            while (aux != null)
            {
                if(aux.id_Venta == id)
                TOT += aux.cant;
                aux = aux.sig;
            }
            return TOT;
        }
        //Prioridad ocupada en la cola Filtro
        public int Prioridad(int id22)
        {
            Nodo aux = primerNodo;
            //Se busca guardar los productos y su cantidad en estos vectores
            string[] productos = new string[100];
            int[] cantidad = new int[100];
            int K = 0;
            int TOT = 0;
            while(aux != null && aux.id_Venta== id22)
            {
                //aPLICO EL MISMO CONCEPTO DE ANTES, INSERTANDO CON CORRELACION
                productos[K] = aux.productos;
                cantidad[K] = aux.cant;
                TOT += cantidad[K];
                K++;
                aux = aux.sig;
            }
            //for (int i = 0; i < 100; i++)
        
        
   
            //Comprobar prioridad
            // Inicializar contadores
            int facil = 0, mediano = 0, alto = 0;

            for (int i = 0; i < productos.Length; i++)
            {
                //Se guardan en estas variables 
                string producto = productos[i];
                int cantidadProducto = cantidad[i];
                //Y se chequea su priorirdad sumando cantidad en los contadores
                //dependiendo de si se cumple su condicion
                if (producto != null && producto != "")
                {
                    if (producto.Contains("Tacos"))
                    {
                        if (cantidadProducto == 1)
                            facil++;
                        else if (cantidadProducto < 3)
                            mediano++;
                        else
                            alto++;
                    }
                    else if (producto.Contains("Burritos"))
                    {
                        if (cantidadProducto < 3)
                            mediano++;
                        else
                            alto++;
                    }
                    else if (producto.Contains("Torta"))
                    {
                        if (cantidadProducto > 3)
                            alto++;
                        else
                            mediano++;
                    }
                    else
                    {
                        facil++; //Si no es ninguno, se considera bebida uwu
                    }
                }
            }
           
            //Ahora el valor más alto de los tres se retornara con su indicador
            // 1 = facil. 2 = mediano. 3 = alto.
            if (facil >= mediano && facil >= alto)
                return 1;
            if (mediano >= facil && mediano >= alto)
                return 2;
            if (alto >= facil && alto >= mediano)
                return 3;
            else
            {
                return -1;
            }


        }

        public bool IdExiste(int id)
        {
            Nodo aux = primerNodo;
            while (aux != null)
            {
                if (aux.id_Venta == id)
                    return true;
                aux = aux.sig;
            }
            return false;
        }

        public void AceptarVenta(DateTime nuevaFecha, string nuevaDescripcion, int id_venta, bool criterio)
        {
            //Elimino la venta por que ya esta aceptada/denegada.
            //Proceso de eliminacion:
            Nodo actual = primerNodo;
            Nodo anterior = null;

            // Si el valor a eliminar está en el primer nodo
            if (actual != null && actual.id_Venta == id_venta)
            {
                primerNodo = actual.sig;

            }

            // Buscar el nodo con el valor a eliminar
            while (actual != null && actual.id_Venta != id_venta)
            {
                anterior = actual;
                actual = actual.sig;
            }

            // Si el valor no está presente en la cola
            if (actual == null)
            {
                
            }

            // Eliminar el nodo
            if(anterior!= null && actual!= null)
            anterior.sig = actual.sig;

            //Proceso de cambio en la bd si esta aceptada
            if (criterio == true)
            {
                using (lanacaDB111 db = new lanacaDB111())
                {
                    Venta ven = new Venta();
                    ven = db.Venta.Find(id_venta);
                   ven.descripcion = nuevaDescripcion;
                    ven.fecha = nuevaFecha;
                    try
                    {
                        db.Entry(ven).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch(Exception ex) 
                    {
                        MessageBox.Show(ex.ToString());
                    
                    }
                }
            }
            //Si no esta aceptada, se deniega y no hay necesidad de ocupar parametros
            else
            {
                using (lanacaDB111 db = new lanacaDB111())
                {
                    Venta ven = new Venta();
                    ven = db.Venta.Find(id_venta);
                    ven.descripcion = "Denegada";
                    ven.fecha = nuevaFecha;
                    try
                    {
                        db.Entry(ven).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());

                    }
                }
            }
        }

        public Nodo[] Imprimir()
        {
            if (primerNodo== null)
            {

                return null;
            }
            else
            {
                int i = 0;
                Nodo[] aux = new Nodo[totnodos];
                Nodo nodoActual = primerNodo;
                while (nodoActual != null)
                {
                    aux[i] = nodoActual;
                    i++;
                    nodoActual = nodoActual.sig;
                }
                return aux;
            }

        }
       
    }

   


}
