using Proyecto_Catedra_PED.DB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Catedra_PED.Hash
{
    public class THash
    {
        ListaC claves = new ListaC();
        ListaM[] menu;
        string llave;
     
        Random random;
        public THash() 
        {
            //Vector posicion para manejar menos colisiones posibles
            menu = new ListaM[10000]; 
            random = new Random();
        }
        public int Claves { get => claves.Totclaves; }

        public NodoC[] VerLlaves()
        {
            //Se obtiene las claves en conjunto de vectores
            return claves.VerConjuntoLlaves();

        }
        string GenerarC()
        {
            int longitud = 5;

            // Caracteres que pueden estar en la cadena aleatoria
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzÏíóá";

            // Crear una cadena aleatoria
            char[] cadenaAleatoria = new char[longitud];
            for (int i = 0; i < longitud; i++)
            {
                // Elegir un carácter aleatorio de la lista de caracteres
                cadenaAleatoria[i] = caracteres[random.Next(caracteres.Length)];
            }
            string cadenaAleatoriaStr = new string(cadenaAleatoria);

            return cadenaAleatoriaStr;
        }

        //Funciona el hashing, respetar mayusculas
     
       int DetPosi(string cadena)
        {
            if (cadena.Contains("Tacos"))
            {

                llave = GenerarC();

                return Hashing(llave);
            }
            else if (cadena.Contains("Torta"))
            {
                
               llave = GenerarC();
        
                return Hashing(llave); 
            }
            else if (cadena.Contains("Burritos"))
            {
                llave = GenerarC();

                return Hashing(llave);
            }
            else
            //Se trata de bebidas 
            {
                llave = GenerarC();

                return Hashing(llave);
            }



        }
        int Hashing(string clave)
        {
            int valor=0;
            foreach (char c in clave)
            {
                valor += (int)c;
            }
            //en otra variable hago el resultado de hacer hashing
            int hash = valor % 999;
            return hash;

        }
        //--------------------------------------------------------------------------
        //Cadena es como clave.
        //deaful me ayudara a determinar si se trata de un cargado de valores o de que se está ingresando valores
        public bool InsertarDefault(NodoM p, bool defaul)
        {
            
            if(defaul == true)
            {
                if (!claves.Existe(p.nombreProducto, llave))
                {
                    int posicion = DetPosi(p.nombreProducto);
                    //Con la llave ya generada en el hashing
                   
                    claves.Insertar(llave, p.nombreProducto);

                    if (menu[posicion] == null)
                    {
                        //Crea lista de (valores, claves) en posicion
                        //Se crea el objeto por que ya tienes un indice sin un valor
                        menu[posicion] = new ListaM();
                    }

                    menu[posicion].InsertarI(p);
                    return true;
              
                }
                return false;
            }
            //Se trata de un ingreso nuevo en el programa
            else
            {
                if (!claves.Existe(p.nombreProducto, ""))
                {
                    int posicion = DetPosi(p.nombreProducto);
                    //Con la llave ya generada en el hashing
                    claves.Insertar(llave, p.nombreProducto);

                    if (menu[posicion] == null)
                    {
                        //Crea lista de (valores, claves) en posicion
                        //Se crea el objeto por que ya tienes un indice sin un valor
                        menu[posicion] = new ListaM();
                    }

                    menu[posicion].InsertarI(p);
                    //Ahora pa la db
                    NodoM[] pa = menu[posicion].Imprimir();
                    for (int i = 0; i < pa.Length; i++)
                        InsertarDB(pa[i]);
                    return true;
                 
                }
                return false;
            }
          
        }
        void InsertarDB(NodoM p)
        {
            using(lanacaDB111 db = new lanacaDB111())
            {
               
                Producto producto = new Producto();
                //Aplico este if por si ese id producto ya existe (colisiones)
                producto = db.Producto.Find(p.id_Produ);
                if (producto == null)
                {
                    //Ahora si se inserta
                    Producto producto2 = new Producto();
                    producto2.Nombre = p.nombreProducto;
                    producto2.precio = p.precio;
                    producto2.descripcion = p.descripcion;
                    producto2.id_Produc = (int)p.id_Produ;
                    try
                    {
                        db.Producto.Add(producto2);
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("SE CAYÓ EL PORTON");
                    }
                }
               
               
            }
        }
        //--------------------------------------------------------------------------
    
        //AQUI VA A DIGITAR LA CLAVE QUE ESTA EN EL LISTBOX
        //ESTO ES IMPRESION
        public NodoM BuscarC(string ValorLlave)
        {
            NodoM AutoTemp;
            string nombrep = claves.RetornarNombre(ValorLlave);
            if (claves.Existe(nombrep,ValorLlave)== true)
            {
        
                AutoTemp = menu[Hashing(ValorLlave)].RetornarAuto(nombrep);
                return AutoTemp;
            }
            return null;
        }
        //--------------------------------------------------------------------------
        //Para modificar, ocupare la logica que estan en tablas hash. Borrar y luego agregar
        public void ModificarNodo(string ValorLlave,NodoM tt, bool t)
        {
            bool a =Borrar(ValorLlave, false);
            
           bool k = InsertarDefault(tt, false);
            if(a == true && k == true)
            {
                //Modificar pa la db :p
                ModificarBd(tt);
            }
        }
      
       //--------------------------------------------------------------------------
       public bool Borrar(string clave, bool bd)
        {
            string n = claves.RetornarNombre(clave);
           
            if(claves.Existe(n,clave)== true)
            {
                //Borra por el Id todo, la clave y el nombre
                claves.Borrar(clave);
                int hash = Hashing(clave);
                int ind = menu[hash].Buscar(n);
                menu[hash].Remover(ind);
                //Cambiar a true por si quiere borrar en la bd directamente
                if (bd == true)
                    BorrarBd(n);
                return true;
            }
            else
            {
                return false;
            }
        }
        void BorrarBd(string nombreProducto)
        {
            using (lanacaDB111 db = new lanacaDB111())
            {
                try
                {
                    // Buscar el producto por nombre
                    Producto pro = db.Producto.FirstOrDefault(p => p.Nombre == nombreProducto);

                    if (pro != null)
                    {
                        // Remover el producto
                        db.Producto.Remove(pro);
                        db.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Se cayó el portón");
                }
            }
        }
        public void ModificarBd(NodoM p)
        {
            using(lanacaDB111 db = new lanacaDB111()) 
            {
                Producto pro = new Producto();
                pro = db.Producto.Find(p.id_Produ);
                pro.precio = p.precio;
                pro.Nombre = p.nombreProducto;
                pro.descripcion = p.descripcion;
                try
                {

                    db.Entry(pro).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }catch(Exception)
                {
                    MessageBox.Show("Se cayó el porton");
                }
                
            }

        }
      
      
    }
}
