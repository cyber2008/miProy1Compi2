using _200816543_XForm.ambito;
using static _200816543_XForm.ambito.Simbolo;

namespace _200816543_XForm.ast.miBase
{
    public interface Exp:NodoAST
    {
        Tipos getTipo(Ambito amb, AST arbol);

        object getValorImplicito(Ambito amb, AST arbol);
    }
}
