using _200816543_XForm.Analizadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace _200816543_XForm.Acciones
{
    class PrimeraPasada : Accion
    {
        public List<TablaSimbolos> primeraPasada = new List<TablaSimbolos>();

        //public void doAction(ParseTreeNode ptNode)
        //{
        //    action(ptNode);
        //}

        public void action(ParseTreeNode nodo)
        {
            ejecutarExp(nodo.ChildNodes[0]);
        }

        public TablaSimbolos ejecutarExp(ParseTreeNode node)
        {
            Object result = null;
            TablaSimbolos resultado = new TablaSimbolos();
            switch (node.Term.Name.ToString())
            {
                #region EXP
                case "EXP":
                    {
                        if (node.ChildNodes.Count == 1)
                        {
                            resultado = ejecutarExp(node.ChildNodes[0]);
                        }
                        break;
                    }
                #endregion

                #region EXP_ARIT
                case "EXP_ARIT":
                    {
                        //if (node.ChildNodes.Count == 1)
                        //{
                        //    resultado = ejecutarExp(node.ChildNodes[0]);
                        //}

                        //else 
                        if (node.ChildNodes.Count == 3)
                        {
                            resultado.TablaSimbolosTipo = "numero";
                            if (node.ChildNodes[1].Term.Name.ToString() == "+")
                            {                               
                                    double op1 = Convert.ToDouble(ejecutarExp(node.ChildNodes[0]).valor);
                                    double op2 = Convert.ToDouble(ejecutarExp(node.ChildNodes[2]).valor);
                                    result = op1 + op2;
                                    resultado.TablaSimbolosTipo = "numero";
                                    resultado.valor = result;
                                    Console.WriteLine("Los operadores son numeros");                              
                            }
                            else if (node.ChildNodes[1].Term.Name.ToString() == "-")
                            {
                                double op1 = Convert.ToDouble(ejecutarExp(node.ChildNodes[0]).valor);
                                double op2 = Convert.ToDouble(ejecutarExp(node.ChildNodes[2]).valor);
                                result = op1 - op2;
                                resultado.TablaSimbolosTipo = "numero";
                                resultado.valor = result;
                            }
                            else if (node.ChildNodes[1].Term.Name.ToString() == "*")
                            {
                                double op1 = Convert.ToDouble(ejecutarExp(node.ChildNodes[0]).valor);
                                double op2 = Convert.ToDouble(ejecutarExp(node.ChildNodes[2]).valor);
                                result = op1 * op2;
                                resultado.TablaSimbolosTipo = "numero";
                                resultado.valor = result;
                            }
                            else if (node.ChildNodes[1].Term.Name.ToString() == "/")
                            {
                                double op1 = Convert.ToDouble(ejecutarExp(node.ChildNodes[0]).valor);
                                double op2 = Convert.ToDouble(ejecutarExp(node.ChildNodes[2]).valor);
                                result = op1 / op2;
                                resultado.TablaSimbolosTipo = "numero";
                                resultado.valor = result;
                            }
                            else if (node.ChildNodes[1].Term.Name.ToString() == "%")
                            {
                                double op1 = Convert.ToDouble(ejecutarExp(node.ChildNodes[0]).valor);
                                double op2 = Convert.ToDouble(ejecutarExp(node.ChildNodes[2]).valor);
                                result = op1 % op2;
                                resultado.TablaSimbolosTipo = "numero";
                                resultado.valor = result;
                            }                         
                            else if (node.ChildNodes[1].Term.Name.ToString() == "^")
                            {
                                double op1 = Convert.ToDouble(ejecutarExp(node.ChildNodes[0]).valor);
                                double op2 = Convert.ToDouble(ejecutarExp(node.ChildNodes[2]).valor);
                                result = Math.Pow(op1, op2);
                                resultado.TablaSimbolosTipo = "numero";
                                resultado.valor = result;
                            }
                            //else if (node.ChildNodes[0].Term.Name.ToString() == "(" && node.ChildNodes[2].Term.Name.ToString() == ")")
                            //{
                            //    //ejecutarExp(node.ChildNodes[1]);
                            //    //double op2 = Convert.ToDouble(ejecutarExp(node.ChildNodes[2]).ToString());
                            //    resultado = ejecutarExp(node.ChildNodes[1]);
                            //}
                        }
                        Console.WriteLine("RESULTADOOOOOOOOOOOO " + resultado.valor.ToString());
                        break;
                    }
                #endregion

                #region EXP_LOG
                case "EXP_LOG":
                    if (node.ChildNodes.Count == 3)
                    {
                        resultado.TablaSimbolosTipo = "numero";
                        if (node.ChildNodes[1].Term.Name.ToString() == "||")
                        {
                            double op1 = Convert.ToDouble(ejecutarExp(node.ChildNodes[0]).valor);
                            double op2 = Convert.ToDouble(ejecutarExp(node.ChildNodes[2]).valor);
                            result = op1 + op2;
                            resultado.TablaSimbolosTipo = "numero";
                            resultado.valor = result;
                        }
                    }
                    break;
                #endregion

                        #region TIPO_PRIM
                case "TIPO_PRIM":
                    {
                        if (node.ChildNodes.Count == 1)
                        {
                            resultado = ejecutarExp(node.ChildNodes[0]);
                        }
                    }
                    break;
                #endregion

                case "number":
                    {
                        result = node.Token.Value;
                        resultado.TablaSimbolosTipo = "numero";
                        resultado.valor = result;
                        break;
                    }
            }
            return resultado;
        }
    }


}
