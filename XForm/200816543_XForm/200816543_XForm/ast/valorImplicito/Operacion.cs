using _200816543_XForm.ambito;
using _200816543_XForm.ast.miBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200816543_XForm.ast.valorImplicito
{
    //Clase para representar operaciones aritmeticas, logicas y relacionales
    public class Operacion:Exp
    {

        public enum Operador
        {
            SUMA,
            RESTA,
            MULTIPLICACION,
            DIVISION,
            POTENCIA,
            MENOS_UNARIO,
            MAYOR_QUE,
            MAYOR_IGUAL_QUE,
            MENOR_QUE,
            MENOR_IGUAL_QUE,
            IGUAL_IGUAL,
            DIFERENTE_QUE,
            OR,
            AND,
            NOT,
            DESCONOCIDO
        }

        private Exp ope1;
        private Exp ope2;
        private Exp signoOpUnario;
        private Operador signoOp;

        public static Operador getOperador(string op)
        {
            switch (op)
            {
                case "+":
                    return Operador.SUMA;
                case "-":
                    return Operador.RESTA;
                case "*":
                    return Operador.MULTIPLICACION;
                case "/":
                    return Operador.DIVISION;
                case "^":
                    return Operador.POTENCIA;
                case ">":
                    return Operador.MAYOR_QUE;
                case ">=":
                    return Operador.MAYOR_IGUAL_QUE;
                case "<":
                    return Operador.MENOR_QUE;
                case "<=":
                    return Operador.MENOR_IGUAL_QUE;
                case "==":
                    return Operador.IGUAL_IGUAL;
                case "!=":
                    return Operador.DIFERENTE_QUE;
                case "||":
                    return Operador.OR;
                case "&&":
                    return Operador.AND;
                default:
                    return Operador.DESCONOCIDO;
            }
        }

        public Operacion(Exp op1, Exp op2, Operador signoOp) {
            this.ope1 = op1;
            this.ope2 = op2;
            this.signoOp = signoOp;
        }

        public Simbolo.Tipos getTipo(Ambito amb, AST arbol)
        {
            object valor = getValorImplicito(amb, arbol);
            if (valor is bool)
            {
                return Simbolo.Tipos.BOOL;
            }
            else if (valor is string)
            {
                return Simbolo.Tipos.STRING;
            }
            else if (valor is char)
            {
                return Simbolo.Tipos.CHAR;
            }
            else if (valor is int)
            {
                return Simbolo.Tipos.INT;
            }
            else if (valor is double)
            {
                return Simbolo.Tipos.DOUBLE;
            }
            else
            {
                return Simbolo.Tipos.NULL;
            }
        }

        public object getValorImplicito(Ambito amb, AST arbol)
        {
            object op1 = new object(), op2 = new object(), opU = new object();
            if (signoOpUnario == null)
            {
                op1 = ope1.getValorImplicito(amb, arbol);
                op2 = ope2.getValorImplicito(amb, arbol);
            }
            else
            {
                opU = signoOpUnario.getValorImplicito(amb, arbol);
            }
            switch (signoOp)
            {
                case Operador.SUMA:
                    //Tipo resultante de datos: Decimal
                    if (op1 is int && op2 is double)
                    {
                        return (int)op1 + (double)op2;
                    }
                    else if (op1 is double && op2 is int)
                    {
                        return (double)op1 + (int)op2;
                    }
                    else if (op1 is double && op2 is char)
                    {
                        return (double)op2 + (int)((char)(op2));
                    }
                    else if (op1 is char && op2 is double)
                    {
                        return (int)((char)(op1)) + (double)op2;
                    }
                    else if (op1 is bool && op2 is double)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 + (double)op2;
                    }
                    else if (op1 is double && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return (double)op1 + o2;
                    }
                    else if (op1 is double && op2 is double)
                    {
                        return (double)op1 + (double)op2;
                    } //Tipo resultante de datos: Entero
                    else if (op1 is int && op2 is char)
                    {
                        return (int)op1 + (int)((char)op2);
                    }
                    else if (op1 is char && op2 is int)
                    {
                        return (int)((char)op1) + (int)op2;
                    }
                    else if (op1 is bool && op2 is int)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 + (int)op2;
                    }
                    else if (op1 is int && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return (int)op1 + o2;
                    }
                    else if (op1 is int && op2 is int)
                    {
                        return (int)op1 + (int)op2;
                    } //Tipo resultante de datos: Cadena
                    else if (op1 is string || op2 is string)
                    {
                        return op1.ToString() + op2.ToString();
                    } //Tipo resultante de datos: Bool
                    else if (op1 is bool && op2 is bool)
                    {
                        return (bool)op1 || (bool)op2;
                    }
                    else
                    {
                        Console.WriteLine("error de tipos");
                        //Program.getGUI().appendSalida("Error de tipos en la suma");
                    }
                    break;
            }
            return null;
        }        

        public string get3D()
        {
            throw new NotImplementedException();
        }
    }
}
