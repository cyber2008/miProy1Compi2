using _200816543_XForm.ambito;
using System;

namespace _200816543_XForm.ast.miBase
{
    public interface Instruccion:NodoAST
    {
        Object ejecutar(Ambito amb, AST arbol);
    }
}
