using _200816543_XForm.ambito;
using _200816543_XForm.ast.miBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _200816543_XForm.ambito.Simbolo;

namespace _200816543_XForm.ast.cambioFlujo
{
    public class Retorno:Exp
    {
        private bool retornoVoid;
        private Exp valorDeRetorno;

        /**
         * @fn  public Return(Expresion valorDeRetorno)
         *
         * @brief   Constructor utilizado en sentencias Return Expresion; es decir en funciones.
         *
         * @author  Javier Estuardo Navarro
         * @date    26/08/2018
         *
         * @param   valorDeRetorno The valorDeRetorno to return.
         */

        public Retorno(Exp valorDeRetorno)
        {
            this.valorDeRetorno = valorDeRetorno;
            retornoVoid = false;
        }

        /**
         * @fn  public Return()
         *
         * @brief   Constructor utilizado en sentencias Return; es decir en metodos (void).
         *
         * @author  Javier Estuardo Navarro
         * @date    26/08/2018
         */

        public Retorno()
        {
            retornoVoid = true;
        }

        /**
         * @fn  public bool isRetornoVoid()
         *
         * @brief   Consulta si el retorno es void.
         *
         * @author  Javier Estuardo Navarro
         * @date    26/08/2018
         *
         * @return  True si devuelve void, false si no.
         */

        public bool isRetornoVoid()
        {
            return retornoVoid;
        }

        public Tipos getTipo(Ambito amb, AST arbol)
        {
            return valorDeRetorno.getTipo(amb, arbol);
        }


        public object getValorImplicito(Ambito amb, AST arbol)
        {
            return valorDeRetorno.getValorImplicito(amb, arbol);
        }

        public string get3D()
        {
            throw new NotImplementedException();
        }
    }
}
