using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;

namespace _200816543_XForm.Analizadores
{
    class Analizador
    {
        private Grammar gramatica;

        private Analizador()
        {
            gramatica = null;
        }

        public Analizador(Grammar gramatica)
        {
            this.gramatica = gramatica;
        }

        public ParseTree isValid(string codigoFuente)
        {
            LanguageData lenguaje;
            Parser parsear;
            try
            {
                lenguaje = new LanguageData(gramatica);
                parsear = new Parser(lenguaje);
                ParseTree arbol = parsear.Parse(codigoFuente);
                if (arbol.Root != null)
                {
                    return arbol;
                }
                else
                {
                    bool error = arbol.HasErrors();
                    if (error)
                    {
                        int cont = arbol.Tokens.Count;
                        for (int i = 0; i < cont; i++)
                        {
                            if (arbol.Tokens[i].IsError())
                            {
                                System.IO.File.WriteAllText(@"C:\Users\eliu\Dropbox\compi2_2sem_2018\Proyecto1\XForm\200816543_XForm\Errores.html", arbol.Tokens[i].ToString());
                                Console.WriteLine("->" + arbol.Tokens[i].ToString());
                            }
                        }
                    }
                    return null;
                }
            }
            catch {
                Console.WriteLine("Error al intentar parsear");
                return null;
            }
        }

        public void parse(ParseTree arbol, Accion action)
        {
            ActionMaker act = new ActionMaker(arbol.Root);
            act.getEval(action); //act.getEval(action);
        }

        private class ActionMaker
        {

            private ParseTreeNode root;

            public ActionMaker(ParseTreeNode ptRoot)
            {
                root = ptRoot;
            }

            //public Object getEval(Accion action) {
            public void getEval(Accion action)
            {
                //return action.action(root);
                action.action(root);
            }
        }


    }
}
