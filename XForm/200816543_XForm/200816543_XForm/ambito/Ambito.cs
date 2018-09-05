using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200816543_XForm.ambito
{
    public class Ambito
    {
        private Hashtable tabla;

        private Ambito anterior;

        //Constructor que crea un nuevo ambito en base al anterior
        public Ambito(Ambito anterior) {
            tabla = new Hashtable();
            this.anterior = anterior;
        }

        public void agregar(string id, Simbolo simbolo) {
            tabla.Add(id, simbolo);
        }

        public bool existe(string id) {
            for (Ambito a = this; a != null; a = a.anterior) {
                if (a.tabla.Contains(id)) {
                    return true;
                }
            }
            return false;
        }

        public bool existeActual(string id) {
            Simbolo siEncontro = (Simbolo)(tabla[id]);
            return siEncontro != null;
        }

        //Obtener un simbolo en base a una clave
        public Simbolo get(string id) {
            for (Ambito a = this; a != null; a = a.anterior) {

                Simbolo siEncontro = (Simbolo)(a.tabla[id]);
                if (siEncontro != null) {
                    return siEncontro;
                }
            }
            Console.WriteLine("El simbolo: "+id+ "no se declaro en el ambito actual ni externo (ambito.Ambito)");
            return null;
        }

        public void reemplaza(string id, Simbolo nuevoVal) {

            for (Ambito a=this; a != null; a = a.anterior) {

                Simbolo siEncontro = (Simbolo)(a.tabla[id]);
                if (siEncontro != null) {
                    tabla[id] = nuevoVal;
                }
            }
            Console.WriteLine("El simbolo: "+id+ " no se ha declarado en este ambito o externo (ambito.Ambito)");
        }

        public Hashtable Tabla {
            get { return tabla; }
            set { tabla = value; }
        }

        public Ambito Anterior {
            get { return anterior; }
            set { anterior = value; }
        }
    }
}
