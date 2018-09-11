using _200816543_XForm.ast.miBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _200816543_XForm.ambito.Simbolo;

namespace _200816543_XForm.ambito.simbolos
{
    public class Principal:Funcion
    {
        public Principal(string identificador, LinkedList<Simbolo> listaParametros, LinkedList<NodoAST> instrucciones)
        : base(identificador, listaParametros, instrucciones)
        {
        }
        //public Principal(Tipos tipo, string identificador, LinkedList<Simbolo> listaParametros, LinkedList<NodoAST> instrucciones)
        //:base (tipo, identificador, listaParametros, instrucciones)
        //{
        //}
    }
}
