using _200816543_XForm.ambito;
using _200816543_XForm.ambito.simbolos;
using _200816543_XForm.ast.miBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _200816543_XForm.ambito.Simbolo;

namespace _200816543_XForm.ast.valorImplicito
{
    public class Llamada: Exp
    {
        private string id;
        private LinkedList<Exp> valores;

        public Llamada(string id) {
            this.id = id;
            this.valores = new LinkedList<Exp>();
        }

        public Llamada(string id, LinkedList<Exp> valores) {
            this.id = id;
            this.valores = valores;
        }


        public Simbolo.Tipos getTipo(Ambito amb, AST arbol)
        {
            object valor = this.getValorImplicito(amb, arbol);
            if (valor is bool)
            {
                return Tipos.BOOL;
            }
            else if (valor is string)
            {
                return Tipos.STRING;
            }
            else if (valor is char)
            {
                return Tipos.CHAR;
            }
            else if (valor is int)
            {
                return Tipos.INT;
            }
            else if (valor is double)
            {
                return Tipos.DOUBLE;
            }
            else if (valor is Object)
            {
                return Tipos.OBJET;
            }
            else
            {
                return Tipos.NULL;
            }
        }

        public object getValorImplicito(Ambito amb, AST arbol)
        {
            if (amb.existe(id))
            {
                //La funcion existe en el entorno actual o externo
                Funcion funcion = (Funcion)amb.get(id);
                Ambito local = new Ambito(amb);
                /*
                 * Tras acceder al simbolo que representa la funcion que se llamara en el entorno
                 * Se crea un entorno local para el manejo de las variables locales a dicha funcion.
                 */
                if (verificarParametros(valores, funcion.ListaParametros, local, arbol))
                {
                    // Tras verificar que los parametros correspondan en longitud y tipo, se ejecuta la funcion.
                    return funcion.ejecutar(local, arbol);
                }
            }
            else
            {
                Console.WriteLine("La funcion" + id + " no ha sido declarada");
            }
            return null;
        }



        bool verificarParametros(LinkedList<Exp> valores, LinkedList<Simbolo> parametros, Ambito ent, AST arbol)
        {
            // Esto se agrego debido a que LinkedList no tiene metodo get(index) o ElementAt(index)
            IList param = new List<Simbolo>(parametros);
            IList vals = new List<Exp>(valores);
            if (vals.Count == param.Count)
            {
                // La cantidad de valores y parametros es la correcta.
                /*
                 * Variables auxiliares que permitirán verificacion de tipos y carga de parametros 
                 * al entorno local de la función.
                */
                Simbolo sim_aux;
                string id_aux;
                Tipos tipoPar_aux;
                Tipos tipoVal_aux;
                Exp exp_aux;
                object val_aux;

                for (int i = 0; i < parametros.Count; i++)
                {
                    sim_aux = (Simbolo)param[i];
                    id_aux = sim_aux.Id;
                    tipoPar_aux = sim_aux.Tipo;

                    exp_aux = (Exp)vals[i];
                    tipoVal_aux = exp_aux.getTipo(ent, arbol);
                    val_aux = exp_aux.getValorImplicito(ent, arbol);
                    if (tipoPar_aux == tipoVal_aux)
                    {
                        // Si los tipos corresponden se agregan los parametros con su respectivo valor.
                        ent.agregar(id_aux, new Simbolo(tipoPar_aux, id_aux, val_aux));
                    }
                    else
                    {
                        Console.WriteLine("Llamada a: " + id + ", El tipo de los parametros no coinciden con "
                                + "el valor correspondiente utilizado en la llamada, Parametro:" + id_aux);
                        return false;
                    }
                }
                return true;
            }
            else
            {
                Console.WriteLine("Llamada a: " + id + "La cantidad de parametros no coincide");
            }
            return false;
        }

        public string get3D()
        {
            throw new NotImplementedException();
        }
    }
}
