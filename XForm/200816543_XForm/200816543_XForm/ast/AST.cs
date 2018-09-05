using _200816543_XForm.ast.miBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200816543_XForm.ast
{
    public class AST
    {
        private LinkedList<miClase> miclase;
        private LinkedList<Instruccion> instrucciones;

        public AST(LinkedList<Instruccion> instrucciones) {
            miClase = new LinkedList<miClase>();
            this.instrucciones = instrucciones;
        }

        public void addClase(miClase c) {
            miClase.AddLast(c);
        }

        public LinkedList<miClase> miClase {
            get { return miclase; }
            set { miclase = value; }
        }

        public LinkedList<Instruccion> Instrucciones
        {
            get { return instrucciones; }
            set { instrucciones = value; }
        }
    }
}
