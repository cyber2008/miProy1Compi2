using _200816543_XForm.ast;
using _200816543_XForm.ast.miBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _200816543_XForm.ambito.Simbolo;

namespace _200816543_XForm.ambito
{
    public class Declaracion : Instruccion
    {
        private Exp valInicial;

        private LinkedList<Simbolo> variables;

        //Si se inicializo la variable o no
        bool esInicializada() {
            return this.valInicial != null;
        }

        public Declaracion(Tipos tipo, LinkedList<Simbolo> variables, Exp valor) {
            foreach (Simbolo variable in variables) {
                variable.Tipo = tipo;
            }
            this.variables = variables;
            this.valInicial = valor;
        }

        public Declaracion(Tipos tipo, Simbolo variable) {
            variable.Tipo = tipo;
            LinkedList<Simbolo> variables = new LinkedList<Simbolo>();
            variables.AddLast(variable);
            this.variables = variables;
            this.valInicial = null;
        }

        public object ejecutar(Ambito amb, AST arbol)
        {
            foreach (Simbolo variable in variables) {
                string nombreVar = variable.Id;
                if (esInicializada())
                {
                    Tipos tipoVal = valInicial.getTipo(amb, arbol);
                    Tipos tipoVar = variable.Tipo;
                    if (amb.existeActual(nombreVar))
                    {
                        Console.WriteLine("Se intento declarar " + nombreVar
                                + "una variable ya existente en el entorno actual");
                    }
                    else
                    {
                        if (tipoVal == tipoVar)
                        {
                            object val = valInicial.getValorImplicito(amb, arbol);
                            variable.Valor = val;
                            amb.agregar(nombreVar, variable);
                        }
                        else
                        {
                            Console.WriteLine("Error de tipos"
                                    + ", se intenta setear un valor a la variable "
                                    + nombreVar + " diferente al que fue declarado");
                        }
                    }

                }
                else {
                    if (amb.existeActual(nombreVar))
                    {
                        Console.WriteLine("Se intento declarar "
                                + "una variable ya existente en el entorno actual");
                    }
                    else
                    {
                        amb.agregar(nombreVar, variable);
                    }
                }
            }
            return null;
        }

        public string get3D()
        {
            throw new NotImplementedException();
        }
    }
}
