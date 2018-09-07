using _200816543_XForm.ambito;
using _200816543_XForm.ast.miBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _200816543_XForm.ambito.Simbolo;

namespace _200816543_XForm.ast.valorImplicito
{
    public class Identificador:Exp
    {
        private string id;

        public Identificador(string id)
        {
            this.id = id;
        }

        public Simbolo.Tipos getTipo(Ambito amb, AST arbol)
        {
            object objValor = getValorImplicito(amb, arbol);
            if (objValor is bool)
            {
                return Tipos.BOOL;
            }
            else if (objValor is string)
            {
                return Tipos.STRING;
            }
            else if (objValor is char)
            {
                return Tipos.CHAR;
            }
            else if (objValor is int)
            {
                return Tipos.INT;
            }
            else if (objValor is double)
            {
                return Tipos.DOUBLE;
            }
            //else if (objValor is Objecto) { }
            else
            {
                return Tipos.NULL;
            }
        }

        public object getValorImplicito(Ambito amb, AST arbol)
        {
            Simbolo sim = amb.get(id);
            return sim.Tipo == Tipos.OBJET ? sim : sim.Valor;
        }

        public string get3D()
        {
            throw new NotImplementedException();
        }
    }
}
