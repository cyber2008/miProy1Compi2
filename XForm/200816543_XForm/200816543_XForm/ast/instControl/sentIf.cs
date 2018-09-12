using _200816543_XForm.ambito;
using _200816543_XForm.ast.miBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200816543_XForm.ast.instControl
{
    public class sentIf:Condicional, Instruccion
    {
        private LinkedList<NodoAST> instruccionesElse;

        public sentIf(Exp cond, LinkedList<NodoAST> instrucciones, LinkedList<NodoAST> InstruccionesElse)
        :base(cond, instrucciones){
            this.InstruccionesElse = InstruccionesElse;
        }

        public object ejecutar(Ambito amb, AST arbol)
        {   
            if ((bool)(Condicion.getValorImplicito(amb, arbol)))
            {
                //Si se cumple
                Ambito local = new Ambito(amb);
                foreach (NodoAST nodo in condInstrucciones) {

                    if (nodo is Instruccion) {
                        Instruccion ins = (Instruccion)nodo;
                        object result = ins.ejecutar(local, arbol);
                        if (result != null) {
                            return result;
                        }
                    } else if (nodo is Exp) {
                        Exp expr = (Exp)nodo;
                        return expr.getValorImplicito(local, arbol);
                    }
                }
            }//Si no se cumple
            else {
                Ambito local = new Ambito(amb);
                foreach (NodoAST nodo in InstruccionesElse) {
                    if (nodo is Instruccion)
                    {
                        Instruccion ins = (Instruccion)nodo;
                        object result = ins.ejecutar(local, arbol);
                        if (result != null) {
                            return result;
                        }
                    } else if (nodo is Exp) {
                        Exp expr = (Exp)nodo;
                        return expr.getValorImplicito(local, arbol);
                    }
                }
            }
            return null;
        }

        public LinkedList<NodoAST> InstruccionesElse {
            get { return instruccionesElse; }
            set { instruccionesElse = value; }
        }

        public string get3D()
        {
            throw new NotImplementedException();
        }
    }
}
