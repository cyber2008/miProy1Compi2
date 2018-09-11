using _200816543_XForm.ast;
using _200816543_XForm.ast.miBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200816543_XForm.ambito.simbolos
{
    public class Funcion : Simbolo, Instruccion
    {
        private string strTipoClase;
        private LinkedList<NodoAST> llInstrucciones;

        //public Funcion(Tipos tipo, string strId, LinkedList<Simbolo> llListaParam, LinkedList<NodoAST> llInstrucciones)
        //:base(tipo, strId, llListaParam){
        //    strTipoClase = string.Empty;
        //    this.llInstrucciones = llInstrucciones;
        //}

        public Funcion(string strId, LinkedList<Simbolo> llListaParam, LinkedList<NodoAST> llInstrucciones)
       : base(strId, llListaParam)
        {
            strTipoClase = string.Empty;
            this.llInstrucciones = llInstrucciones;
        }

        public Funcion(Tipos tipo, string identificador, LinkedList<Simbolo> listaParametros, LinkedList<NodoAST> instrucciones)
    : base(identificador, tipo, listaParametros)
        {
            strTipoClase = string.Empty;
            this.llInstrucciones = instrucciones;
        }
        public object ejecutar(Ambito amb, AST arbol)
        {
            foreach (NodoAST nodo in LLInstrucciones)
            {
                if (nodo is Instruccion) {
                    Instruccion ins = (Instruccion)nodo;
                    object objResult = ins.ejecutar(amb, arbol);
                    if (objResult != null) {
                        if (verificarTipo(this.Tipo, objResult)) {
                            return objResult;
                        }
                        else
                        {
                            Console.WriteLine("error");
                            return null;
                        }
                    }
                }
                else if (nodo is Exp)
                {
                    Exp expr = (Exp)nodo;
                    object result = expr.getValorImplicito(amb, arbol);
                    if (result != null)
                    {
                        if (expr.getTipo(amb, arbol) == this.Tipo)
                        {
                            return result;
                        }
                        else
                        {
                            Console.Write("EL tipo del retorno no es el declarado en la funcion");
                            return null;
                        }

                    }
                }

            }
            return null;
        }

        private bool verificarTipo(Tipos tipo, object result)
        {
            if (tipo == Tipos.INT && result is int)
            {
                return true;
            }
            if (tipo == Tipos.STRING && result is string)
            {
                return true;
            }
            else if (tipo == Tipos.CHAR && result is char)
            {
                return true;
            }
            else if (tipo == Tipos.DOUBLE && result is Double)
            {
                return true;
            }
            else if (tipo == Tipos.BOOL && result is bool)
            {
                return true;
            }
            //else if (tipo == Tipos.OBJET && result is Objeto)
            //{
            //    return true;
            //}
            else
            {
                return false;
            }

        }

        public LinkedList<NodoAST> LLInstrucciones {
            get { return llInstrucciones; }
            set { llInstrucciones = value; }
        }
        public string get3D()
        {
            throw new NotImplementedException();
        }
    }
}
