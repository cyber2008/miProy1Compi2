using _200816543_XForm.ambito;
using _200816543_XForm.ambito.simbolos;
using _200816543_XForm.ast;
using _200816543_XForm.ast.funcionesEspeciales;
using _200816543_XForm.ast.miBase;
using _200816543_XForm.ast.valorImplicito;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _200816543_XForm.ambito.Simbolo;

namespace _200816543_XForm.Analizadores
{
    public class ConstructorAst
    {
        public AST Analizar(ParseTreeNode root) {
            return (AST)aux(root);
        }

        public object aux(ParseTreeNode actual) {

            if (posActualGram(actual, "S")) {
                return aux(actual.ChildNodes[0]);
            }
            else if (posActualGram(actual, "CUERPO")) {
                LinkedList<Instruccion> instrucciones = new LinkedList<Instruccion>();
                foreach (ParseTreeNode hijo in actual.ChildNodes) {
                    instrucciones.AddLast((Instruccion)aux(hijo));
                }
                return new AST(instrucciones);
            }
            else if (posActualGram(actual, "CAMPOS")) {
                if (actual.ChildNodes.Count == 1) {
                    return aux(actual.ChildNodes[0]);
                }
            }
            else if (posActualGram(actual, "METODO")) {
                if (actual.ChildNodes.Count == 4)
                {
                    //hacer algo
                }
                else {
                    if (posActualGram(actual.ChildNodes[0], "TIPO")) {
                        if (posActualGram(actual.ChildNodes[1], "miPrincipal")) {
                            return new Principal((Tipos)aux(actual.ChildNodes[0]), getLexema(actual, 1), new LinkedList<Simbolo>(), (LinkedList<NodoAST>)aux(actual.ChildNodes[2]));
                        }
                    }
                }
            }
            else if (posActualGram(actual, "SENTENCIAS")) {
                return aux(actual.ChildNodes[0]);
            }
            else if (posActualGram(actual, "LISTA_SENTENCIA")) {
                LinkedList<NodoAST> llSentencias = new LinkedList<NodoAST>();

                foreach (ParseTreeNode hijo in actual.ChildNodes) {
                    llSentencias.AddLast((NodoAST)aux(hijo));
                }
                return llSentencias;
            }
            else if (posActualGram(actual, "SENTENCIA")) {
                return aux(actual.ChildNodes[0]);
            }
            else if (posActualGram(actual, "DECLARACION")) {
                if (actual.ChildNodes.Count == 3)
                {
                    return new Declaracion((Tipos)aux(actual.ChildNodes[0]), (LinkedList<Simbolo>)aux(actual.ChildNodes[1]), (Exp)aux(actual.ChildNodes[2]));
                }
                else {
                    if (posActualGram(actual.ChildNodes[0], "TIPO")) {
                        return new Declaracion((Tipos)aux(actual.ChildNodes[0]), (LinkedList<Simbolo>)aux(actual.ChildNodes[1]), null);
                    }
                    else {
                        //DeclaracionClase
                    }
                    
                }
            }
            //else if (posActualGram(actual, "ASIGNACION")) {

            //}
            else if (posActualGram(actual, "SENTENCIA_PRINT")) {
                return new Imprimir((Exp) aux(actual.ChildNodes[1]));
            }

            else if (posActualGram(actual, "LISTA_IDS")) {
                LinkedList<Simbolo> llSimbolos = new LinkedList<Simbolo>();
                foreach (ParseTreeNode hijo in actual.ChildNodes) {
                    llSimbolos.AddLast(new Simbolo(hijo.Token.Text));
                }
                return llSimbolos;
            }

            else if (posActualGram(actual, "EXP")) {

                return aux(actual.ChildNodes[0]);
            }
            else if (posActualGram(actual, "EXP_ARIT")) {

                if (actual.ChildNodes.Count == 3)
                {
                    return new Operacion((Exp)aux(actual.ChildNodes[0]), (Exp)aux(actual.ChildNodes[2]), Operacion.getOperador(getLexema(actual, 1)));
                }
            }
            else if (posActualGram(actual, "TIPO_PRIM")) {

                if (posActualGram(actual.ChildNodes[0], "number")) {

                    double result = Convert.ToDouble(getLexema(actual, 0));
                    try {
                        int result2 = Convert.ToInt32(getLexema(actual, 0));
                        return new Tipo_Prim(result2);
                    }
                    catch (Exception) {
                        return new Tipo_Prim(result);
                    }
                }
                else if (posActualGram(actual.ChildNodes[0], "cadena"))
                {
                    string aux = getLexema(actual, 0).ToString();
                    aux = aux.Replace("\\n", "\n");
                    aux = aux.Replace("\\t", "\t");
                    aux = aux.Replace("\\r", "\r");
                    aux = aux.Substring(1, aux.Length - 2);
                    return new Tipo_Prim(aux);
                }
                else if (posActualGram(actual.ChildNodes[0], "id"))
                {
                    return new Identificador(getLexema(actual, 0));
                }
                //else if () {

                //}

            }
            else if (posActualGram(actual, "TIPO"))
            {
                if (posActualGram(actual.ChildNodes[0], "entero")) {
                    return Tipos.INT;
                }
                else
                {
                    return Tipos.OBJET;
                }

            }

            return null;
        }

        static bool posActualGram(ParseTreeNode nodo, string nombre) {
            return nodo.Term.Name.Equals(nombre, System.StringComparison.InvariantCultureIgnoreCase);
        }

        static string getLexema(ParseTreeNode nodo, int num)
        {
            return nodo.ChildNodes[num].Token.Text;
        }
    }
}
