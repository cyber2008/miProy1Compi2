using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200816543_XForm.ast.miBase
{
    public class Condicional
    {
        private LinkedList<NodoAST> instrucciones;
        private Exp condicion;

        public Condicional(Exp Condicion, LinkedList<NodoAST> Instrucciones) {
            this.Condicion = Condicion;
            this.condInstrucciones = Instrucciones;
        }

        public LinkedList<NodoAST> condInstrucciones {
            get { return instrucciones; }
            set { instrucciones = value; }
        }

        public Exp Condicion{
            get{ return condicion; }
            set{ condicion = value; }
        }
    }
}
