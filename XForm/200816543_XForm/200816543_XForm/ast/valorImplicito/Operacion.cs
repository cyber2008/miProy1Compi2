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
    public class Operacion : Exp
    {

        public enum Operador
        {
            SUMA,
            RESTA,
            MULTIPLICACION,
            DIVISION,
            MODULO,
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
                case "%":
                    return Operador.MODULO;
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
                case "!":
                    return Operador.NOT;
                default:
                    return Operador.DESCONOCIDO;
            }
        }

        public Operacion(Exp op1, Exp op2, Operador signoOp)
        {
            this.ope1 = op1;
            this.ope2 = op2;
            this.signoOp = signoOp;
        }

        public Operacion(Exp operandoU, Operador operador)
        {
            this.signoOpUnario = operandoU;
            this.signoOp = operador;
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
                #region Suma
                case Operador.SUMA:
                    //Tipo resultante de datos: Bool
                    if (op1 is bool && op2 is bool)//Booleano - Booleano
                    {
                        return (bool)op1 || (bool)op2;
                    }
                    else if (op1 is bool && op2 is double)//Booleano - Numerico
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 + (double)op2;
                    }
                    else if (op1 is bool && op2 is int)//Booleano - Numerico
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 + (int)op2;
                    }
                    else if (op1 is bool && op2 is string) {
                        string strResult = (string)op1 + "" + op2;
                        return strResult;
                    }
                    //Tipo resultante de datos: Decimal
                    else if (op1 is int && op2 is double)
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
                    }
                    else
                    {
                        Console.WriteLine("error de tipos en suma");
                        //Program.getGUI().appendSalida("Error de tipos en la suma");
                    }
                    break;
                #endregion

                #region Resta
                case Operador.RESTA:
                    //Tipo resultante de datos: Decimal
                    if (op1 is int && op2 is double)
                    {
                        return (int)op1 - (double)op2;
                    }
                    else if (op1 is double && op2 is int)
                    {
                        return (double)op1 - (int)op2;
                    }
                    else if (op1 is double && op2 is char)
                    {
                        return (double)op2 - (int)((char)(op2));
                    }
                    else if (op1 is char && op2 is double)
                    {
                        return (int)((char)(op1)) - (double)op2;
                    }
                    else if (op1 is bool && op2 is double)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 - (double)op2;
                    }
                    else if (op1 is double && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return (double)op1 - o2;
                    }
                    else if (op1 is double && op2 is double)
                    {
                        return (double)op1 - (double)op2;
                    } //Tipo resultante de datos: Entero
                    else if (op1 is int && op2 is char)
                    {
                        return (int)op1 - (int)((char)op2);
                    }
                    else if (op1 is char && op2 is int)
                    {
                        return (int)((char)op1) - (int)op2;
                    }
                    else if (op1 is bool && op2 is int)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 - (int)op2;
                    }
                    else if (op1 is int && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return (int)op1 - o2;
                    }
                    else if (op1 is int && op2 is int)
                    {
                        return (int)op1 - (int)op2;
                    } //Tipo resultante de datos: Cadena
                    else if (op1 is string || op2 is string)
                    {
                        Console.WriteLine("Error de tipos, se utilizo el operador"
                                + " menos para dos cadenas");
                        return null;
                    } //Tipo resultante de datos: Bool
                    else if (op1 is bool && op2 is bool)
                    {
                        Console.WriteLine("Error de tipos, se utilizo el operador"
                                + " menos para dos boolos");
                        return null;
                    }
                    break;
                #endregion

                #region Multiplicacion
                case Operador.MULTIPLICACION:
                    //Tipo resultante de datos: Decimal
                    if (op1 is int && op2 is double)
                    {
                        return (int)op1 * (double)op2;
                    }
                    else if (op1 is double && op2 is int)
                    {
                        return (double)op1 * (int)op2;
                    }
                    else if (op1 is double && op2 is char)
                    {
                        return (double)op2 * (int)((char)(op2));
                    }
                    else if (op1 is char && op2 is double)
                    {
                        return (int)((char)(op1)) * (double)op2;
                    }
                    else if (op1 is bool && op2 is double)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 * (double)op2;
                    }
                    else if (op1 is double && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return (double)op1 * o2;
                    }
                    else if (op1 is double && op2 is double)
                    {
                        return (double)op1 * (double)op2;
                    } //Tipo resultante de datos: Entero
                    else if (op1 is int && op2 is char)
                    {
                        return (int)op1 * (int)((char)op2);
                    }
                    else if (op1 is char && op2 is int)
                    {
                        return (int)((char)op1) * (int)op2;
                    }
                    else if (op1 is bool && op2 is int)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 * (int)op2;
                    }
                    else if (op1 is int && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return (int)op1 * o2;
                    }
                    else if (op1 is int && op2 is int)
                    {
                        return (int)op1 * (int)op2;
                    } //Tipo resultante de datos: Cadena
                    else if (op1 is string || op2 is string)
                    {
                        Console.WriteLine("Error de tipos, se utilizo el operador"
                                + " por para dos cadenas");
                        return null;
                    } //Tipo resultante de datos: Bool
                    else if (op1 is bool && op2 is bool)
                    {
                        return (bool)op1 && (bool)op2;
                    }
                    break;
                #endregion
                
                #region Division
                case Operador.DIVISION:
                    //Tipo resultante de datos: Decimal
                    if (op1 is int && op2 is double)
                    {
                        if ((double)op2 != 0.0)
                        {
                            return (int)op1 / (double)op2;
                        }
                        else
                        {
                            Console.WriteLine("Excepcion aritmetica: division(/) por cero");
                            return null;
                        }
                    }
                    else if (op1 is double && op2 is int)
                    {
                        if ((int)op2 != 0)
                        {
                            return (double)op1 / (int)op2;
                        }
                        else
                        {
                            Console.WriteLine("Excepcion aritmetica: division(/) por cero");
                            return null;
                        }
                    }
                    else if (op1 is double && op2 is char)
                    {
                        if ((int)((char)(op2)) != 0)
                        {
                            return (double)op2 / (int)((char)(op2));
                        }
                        else
                        {
                            Console.WriteLine("Excepcion aritmetica: division(/) por cero");
                            return null;
                        }
                    }
                    else if (op1 is char && op2 is double)
                    {
                        if ((double)op2 != 0.0)
                        {
                            return (int)((char)(op1)) / (double)op2;
                        }
                        else
                        {
                            Console.WriteLine("Excepcion aritmetica: division(/) por cero");
                            return null;
                        }
                    }
                    else if (op1 is bool && op2 is double)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        if ((double)op2 != 0.0)
                        {
                            return o1 / (double)op2;
                        }
                        else
                        {
                            Console.WriteLine("Excepcion aritmetica: division(/) por cero");
                            return null;
                        }
                    }
                    else if (op1 is double && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        if (o2 != 0)
                        {
                            return (double)op1 / o2;
                        }
                        else
                        {
                            Console.WriteLine("Excepcion aritmetica: division(/) por cero");
                            return null;
                        }
                    }
                    else if (op1 is double && op2 is double)
                    {
                        if ((double)op2 != 0.0)
                        {
                            return (double)op1 / (double)op2;
                        }
                        else
                        {
                            Console.WriteLine("Excepcion aritmetica: division(/) por cero");
                            return null;
                        }
                    } //Tipo resultante de datos: Entero
                    else if (op1 is int && op2 is char)
                    {
                        if ((int)((char)(op2)) != 0)
                        {
                            return (int)op1 / (int)((char)op2);
                        }
                        else
                        {
                            Console.WriteLine("Excepcion aritmetica: division(/) por cero");
                            return null;
                        }
                    }
                    else if (op1 is char && op2 is int)
                    {
                        if ((int)op2 != 0)
                        {
                            return (int)((char)op1) / (int)op2;
                        }
                        else
                        {
                            Console.WriteLine("Excepcion aritmetica: division(/) por cero");
                            return null;
                        }
                    }
                    else if (op1 is bool && op2 is int)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        if ((int)op2 != 0)
                        {
                            return o1 / (int)op2;
                        }
                        else
                        {
                            Console.WriteLine("Excepcion aritmetica: division(/) por cero");
                            return null;
                        }
                    }
                    else if (op1 is int && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        if (o2 != 0)
                        {
                            return (int)op1 / o2;
                        }
                        else
                        {
                            Console.WriteLine("Excepcion aritmetica: division(/) por cero");
                            return null;
                        }
                    }
                    else if (op1 is int && op2 is int)
                    {
                        if ((int)op2 != 0)
                        {
                            return (int)op1 / (int)op2;
                        }
                        else
                        {
                            Console.WriteLine("Excepcion aritmetica: division(/) por cero");
                            return null;
                        }
                    } //Tipo resultante de datos: Cadena
                    else if (op1 is string || op2 is string)
                    {
                        Console.WriteLine("Error de tipos, se utilizo el operador"
                                + " division para dos cadenas");
                        return null;
                    } //Tipo resultante de datos: Bool
                    else if (op1 is bool && op2 is bool)
                    {
                        Console.WriteLine("Error de tipos, se utilizo el operador"
                                + " division para dos boolos");
                        return null;
                    }
                    break;
                #endregion

                #region Potencia
                case Operador.POTENCIA:
                    //Tipo resultante de datos: Decimal
                    if (op1 is int && op2 is double)
                    {
                        return Math.Pow((int)op1, (double)op2);
                    }
                    else if (op1 is double && op2 is int)
                    {
                        return Math.Pow((double)op1, (int)op2);
                    }
                    else if (op1 is double && op2 is char)
                    {
                        return Math.Pow((double)op2, (int)((char)(op2)));
                    }
                    else if (op1 is char && op2 is double)
                    {
                        return Math.Pow((int)((char)(op1)), (double)op2);
                    }
                    else if (op1 is bool && op2 is double)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return Math.Pow(o1, (double)op2);
                    }
                    else if (op1 is double && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return Math.Pow((double)op1, o2);
                    }
                    else if (op1 is double && op2 is double)
                    {
                        return Math.Pow((double)op1, (double)op2);
                    } //Tipo resultante de datos: Entero
                    else if (op1 is int && op2 is char)
                    {
                        return Math.Pow((int)op1, (int)((char)op2));
                    }
                    else if (op1 is char && op2 is int)
                    {
                        return Math.Pow((int)((char)op1), (int)op2);
                    }
                    else if (op1 is bool && op2 is int)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return Math.Pow(o1, (int)op2);
                    }
                    else if (op1 is int && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return Math.Pow((int)op1, o2);
                    }
                    else if (op1 is int && op2 is int)
                    {
                        return Math.Pow((int)op1, (int)op2);
                    } //Tipo resultante de datos: Cadena
                    else if (op1 is string || op2 is string)
                    {
                        Console.WriteLine("Error de tipos, se utilizo el operador"
                                + " potencia para dos cadenas");
                        return null;
                    } //Tipo resultante de datos: Bool
                    else if (op1 is bool && op2 is bool)
                    {
                        Console.WriteLine("Error de tipos, se utilizo el operador"
                                + " potencia para dos boolos");
                        return null;
                    }
                    break;
                #endregion

                #region Modulo
                case Operador.MODULO:
                    if (op1 is int && op2 is int) {
                        return (int)op1 % (int)op2;
                    } else if (op1 is int && op2 is double) {
                        return (int)op1 % (double)op2;
                    }
                    else if (op1 is double && op2 is int) {
                        return (double)op1%(int)op2;
                    }
                    else if (op1 is double && op2 is double) {
                        return (double)op1 % (double)op2;
                    } else if (op1 is bool && op2 is int) {

                        int o2 = (bool)op1 ? 1 : 0;
                        return o2 % (int)op2;
                    }
                    else if (op1 is bool && op2 is double)
                    {
                        double o2 = (bool)op1 ? 1 : 0;
                        return 02 % (double)op2;
                        //return (double)op1 % o2;
                    }
                    else
                    {
                        Console.WriteLine("error de tipos en modulo");
                    }
                    break;
                #endregion

                #region MayorQue
                case Operador.MAYOR_QUE:
                    //Tipo resultante de datos: Decimal
                    if (op1 is int && op2 is double)
                    {
                        return (int)op1 > (double)op2;
                    }
                    else if (op1 is double && op2 is int)
                    {
                        return (double)op1 > (int)op2;
                    }
                    else if (op1 is double && op2 is char)
                    {
                        return (double)op2 > (int)((char)(op2));
                    }
                    else if (op1 is char && op2 is double)
                    {
                        return (int)((char)(op1)) > (double)op2;
                    }
                    else if (op1 is bool && op2 is double)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 > (double)op2;
                    }
                    else if (op1 is double && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return (double)op1 > o2;
                    }
                    else if (op1 is double && op2 is double)
                    {
                        return (double)op1 > (double)op2;
                    } //Tipo resultante de datos: Entero
                    else if (op1 is int && op2 is char)
                    {
                        return (int)op1 > (int)((char)op2);
                    }
                    else if (op1 is char && op2 is int)
                    {
                        return (int)((char)op1) > (int)op2;
                    }
                    else if (op1 is bool && op2 is int)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 > (int)op2;
                    }
                    else if (op1 is int && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return (int)op1 > o2;
                    }
                    else if (op1 is int && op2 is int)
                    {
                        return (int)op1 > (int)op2;
                    } //Tipo resultante de datos: Cadena
                    else if (op1 is string || op2 is string)
                    {
                        return op1.ToString().Length > op2.ToString().Length;
                    } //Tipo resultante de datos: Bool
                    else if (op1 is bool && op2 is bool)
                    {
                        Console.WriteLine("Error de tipos, se utilizo el operador"
                                + " mayor que para dos bools");
                        return null;
                    }
                    break;
                #endregion

                #region MayorIgualQue
                case Operador.MAYOR_IGUAL_QUE:
                    //Tipo resultante de datos: Decimal
                    if (op1 is int && op2 is double)
                    {
                        return (int)op1 >= (double)op2;
                    }
                    else if (op1 is double && op2 is int)
                    {
                        return (double)op1 >= (int)op2;
                    }
                    else if (op1 is double && op2 is char)
                    {
                        return (double)op2 >= (int)((char)(op2));
                    }
                    else if (op1 is char && op2 is double)
                    {
                        return (int)((char)(op1)) >= (double)op2;
                    }
                    else if (op1 is bool && op2 is double)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 >= (double)op2;
                    }
                    else if (op1 is double && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return (double)op1 >= o2;
                    }
                    else if (op1 is double && op2 is double)
                    {
                        return (double)op1 >= (double)op2;
                    } //Tipo resultante de datos: Entero
                    else if (op1 is int && op2 is char)
                    {
                        return (int)op1 >= (int)((char)op2);
                    }
                    else if (op1 is char && op2 is int)
                    {
                        return (int)((char)op1) >= (int)op2;
                    }
                    else if (op1 is bool && op2 is int)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 >= (int)op2;
                    }
                    else if (op1 is int && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return (int)op1 >= o2;
                    }
                    else if (op1 is int && op2 is int)
                    {
                        return (int)op1 >= (int)op2;
                    } //Tipo resultante de datos: Cadena
                    else if (op1 is string || op2 is string)
                    {
                        return op1.ToString().Length > op2.ToString().Length;
                    } //Tipo resultante de datos: Bool
                    else if (op1 is bool && op2 is bool)
                    {
                        Console.WriteLine("Error de tipos, se utilizo el operador"
                                + " mayor igual que para dos bools");
                        return null;
                    }
                    break;
                #endregion

                #region MenorQue
                case Operador.MENOR_QUE:
                    //Tipo resultante de datos: Decimal
                    if (op1 is int && op2 is double)
                    {
                        return (int)op1 < (double)op2;
                    }
                    else if (op1 is double && op2 is int)
                    {
                        return (double)op1 < (int)op2;
                    }
                    else if (op1 is double && op2 is char)
                    {
                        return (double)op2 < (int)((char)(op2));
                    }
                    else if (op1 is char && op2 is double)
                    {
                        return (int)((char)(op1)) < (double)op2;
                    }
                    else if (op1 is bool && op2 is double)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 < (double)op2;
                    }
                    else if (op1 is double && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return (double)op1 < o2;
                    }
                    else if (op1 is double && op2 is double)
                    {
                        return (double)op1 < (double)op2;
                    } //Tipo resultante de datos: Entero
                    else if (op1 is int && op2 is char)
                    {
                        return (int)op1 < (int)((char)op2);
                    }
                    else if (op1 is char && op2 is int)
                    {
                        return (int)((char)op1) < (int)op2;
                    }
                    else if (op1 is bool && op2 is int)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 < (int)op2;
                    }
                    else if (op1 is int && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return (int)op1 < o2;
                    }
                    else if (op1 is int && op2 is int)
                    {
                        return (int)op1 < (int)op2;
                    } //Tipo resultante de datos: Cadena
                    else if (op1 is string || op2 is string)
                    {
                        return op1.ToString().Length < op2.ToString().Length;
                    } //Tipo resultante de datos: Bool
                    else if (op1 is bool && op2 is bool)
                    {
                        Console.WriteLine("Error de tipos, se utilizo el operador"
                                + " menor que para dos boolos");
                        return null;
                    }
                    break;
                #endregion

                #region MenorIgualQue
                case Operador.MENOR_IGUAL_QUE:
                    //Tipo resultante de datos: Decimal
                    if (op1 is int && op2 is double)
                    {
                        return (int)op1 <= (double)op2;
                    }
                    else if (op1 is double && op2 is int)
                    {
                        return (double)op1 <= (int)op2;
                    }
                    else if (op1 is double && op2 is char)
                    {
                        return (double)op2 <= (int)((char)(op2));
                    }
                    else if (op1 is char && op2 is double)
                    {
                        return (int)((char)(op1)) <= (double)op2;
                    }
                    else if (op1 is bool && op2 is double)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 <= (double)op2;
                    }
                    else if (op1 is double && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return (double)op1 <= o2;
                    }
                    else if (op1 is double && op2 is double)
                    {
                        return (double)op1 <= (double)op2;
                    } //Tipo resultante de datos: Entero
                    else if (op1 is int && op2 is char)
                    {
                        return (int)op1 <= (int)((char)op2);
                    }
                    else if (op1 is char && op2 is int)
                    {
                        return (int)((char)op1) <= (int)op2;
                    }
                    else if (op1 is bool && op2 is int)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 <= (int)op2;
                    }
                    else if (op1 is int && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return (int)op1 <= o2;
                    }
                    else if (op1 is int && op2 is int)
                    {
                        return (int)op1 <= (int)op2;
                    } //Tipo resultante de datos: Cadena
                    else if (op1 is string || op2 is string)
                    {
                        return op1.ToString().Length <= op2.ToString().Length;
                    } //Tipo resultante de datos: Bool
                    else if (op1 is bool && op2 is bool)
                    {
                        Console.WriteLine("Error de tipos, se utilizo el operador"
                                + " menor que para dos boolos");
                        return null;
                    }
                    break;
                #endregion

                #region IgualIgual
                case Operador.IGUAL_IGUAL:
                    //Tipo resultante de datos: Decimal
                    if (op1 is int && op2 is double)
                    {
                        return (int)op1 == (double)op2;
                    }
                    else if (op1 is double && op2 is int)
                    {
                        return (double)op1 == (int)op2;
                    }
                    else if (op1 is double && op2 is char)
                    {
                        return (double)op2 == (int)((char)(op2));
                    }
                    else if (op1 is char && op2 is double)
                    {
                        return (int)((char)(op1)) == (double)op2;
                    }
                    else if (op1 is bool && op2 is double)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 == (double)op2;
                    }
                    else if (op1 is double && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return (double)op1 == o2;
                    }
                    else if (op1 is double && op2 is double)
                    {
                        return (double)op1 == (double)op2;
                    } //Tipo resultante de datos: Entero
                    else if (op1 is int && op2 is char)
                    {
                        return (int)op1 == (int)((char)op2);
                    }
                    else if (op1 is char && op2 is int)
                    {
                        return (int)((char)op1) == (int)op2;
                    }
                    else if (op1 is bool && op2 is int)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 == (int)op2;
                    }
                    else if (op1 is int && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return (int)op1 == o2;
                    }
                    else if (op1 is int && op2 is int)
                    {
                        return (int)op1 == (int)op2;
                    } //Tipo resultante de datos: Cadena
                    else if (op1 is string || op2 is string)
                    {
                        return op1.ToString().Equals(op2.ToString());
                    } //Tipo resultante de datos: Bool
                    else if (op1 is bool && op2 is bool)
                    {
                        return (bool)op1 == (bool)op2;
                    }
                    break;
                #endregion

                #region DiferenteQue
                case Operador.DIFERENTE_QUE:
                    //Tipo resultante de datos: Decimal
                    if (op1 is int && op2 is double)
                    {
                        return (int)op1 != (double)op2;
                    }
                    else if (op1 is double && op2 is int)
                    {
                        return (double)op1 != (int)op2;
                    }
                    else if (op1 is double && op2 is char)
                    {
                        return (double)op2 != (int)((char)(op2));
                    }
                    else if (op1 is char && op2 is double)
                    {
                        return (int)((char)(op1)) != (double)op2;
                    }
                    else if (op1 is bool && op2 is double)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 == (double)op2;
                    }
                    else if (op1 is double && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return (double)op1 != o2;
                    }
                    else if (op1 is double && op2 is double)
                    {
                        return (double)op1 != (double)op2;
                    } //Tipo resultante de datos: Entero
                    else if (op1 is int && op2 is char)
                    {
                        return (int)op1 != (int)((char)op2);
                    }
                    else if (op1 is char && op2 is int)
                    {
                        return (int)((char)op1) != (int)op2;
                    }
                    else if (op1 is bool && op2 is int)
                    {
                        int o1 = (bool)op1 ? 1 : 0;
                        return o1 != (int)op2;
                    }
                    else if (op1 is int && op2 is bool)
                    {
                        int o2 = (bool)op1 ? 1 : 0;
                        return (int)op1 != o2;
                    }
                    else if (op1 is int && op2 is int)
                    {
                        return (int)op1 != (int)op2;
                    } //Tipo resultante de datos: Cadena
                    else if (op1 is string || op2 is string)
                    {
                        return !op1.ToString().Equals(op2.ToString());
                    } //Tipo resultante de datos: Bool
                    else if (op1 is bool && op2 is bool)
                    {
                        return (bool)op1 != (bool)op2;
                    }
                    break;
                #endregion

                #region Logicas
                case Operador.OR:
                    if (op1 is bool && op2 is bool)
                    {
                        return (bool)op1 || (bool)op2;
                    }
                    else
                    {
                        Console.WriteLine("Error de tipos, se utilizo un operador"
                                + " or, ambos operandos deben ser de tipo bool");
                        return null;
                    }
                case Operador.AND:
                    if (op1 is bool && op2 is bool)
                    {
                        return (bool)op1 && (bool)op2;
                    }
                    else
                    {
                        Console.WriteLine("Error de tipos, se utilizo un operador"
                                + " and, ambos operandos deben ser de tipo bool");
                        return null;
                    }
                case Operador.NOT:
                    if (opU is bool)
                    {
                        return !(bool)op1;
                    }
                    else
                    {
                        Console.WriteLine("Error de tipos, se utilizo un operador"
                                + " not, el operando debe ser de tipo bool");
                        return null;
                    }
                #endregion
                default:
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
