using _200816543_XForm.ambito;
using _200816543_XForm.ast.miBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200816543_XForm.ast.valorImplicito
{
    public class Tipo_Prim:Exp
    {
        private object valor;

        public Tipo_Prim(object valor) {
            this.valor = valor;
        }

        public Simbolo.Tipos getTipo(Ambito amb, AST arbol)
        {
            object valor = this.getValorImplicito(amb, arbol);
            if (valor is bool) {
                return Simbolo.Tipos.BOOL;
            }
            else if (valor is string) {
                return Simbolo.Tipos.STRING;
            }
            else if (valor is char) {
                return Simbolo.Tipos.CHAR;
            }
            else if (valor is int) {
                return Simbolo.Tipos.INT;
            }
            else if (valor is double) {
                return Simbolo.Tipos.DOUBLE;
            }
            else {
                return Simbolo.Tipos.OBJET;
            }
        }

        public object getValorImplicito(Ambito amb, AST arbol)
        {
            return valor;
        }

        public string get3D()
        {
            throw new NotImplementedException();
        }
    }
}
