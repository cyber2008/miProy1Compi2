using _200816543_XForm.ambito;
using _200816543_XForm.ast.miBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200816543_XForm.ast.funcionesEspeciales
{
    public class Imprimir:Instruccion
    {
        private Exp exp;

        public Imprimir(Exp exp)
        {
            this.exp = exp;
        }
        public object ejecutar(Ambito amb, AST arbol)
        {
            object obj = exp.getValorImplicito(amb, arbol);
            if (obj != null)
            {
                Console.WriteLine(obj.ToString());
            }
            else {
                Console.WriteLine("Se intento imprimir una expresion null");
            }
            return null;
        }

        public string get3D()
        {
            throw new NotImplementedException();
        }
    }
}
