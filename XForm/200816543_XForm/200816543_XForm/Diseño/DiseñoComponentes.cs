using _200816543_XForm.Acciones;
using _200816543_XForm.ambito;
using _200816543_XForm.ambito.simbolos;
using _200816543_XForm.Analizadores;
using _200816543_XForm.ast;
using _200816543_XForm.ast.miBase;
using Irony.Parsing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _200816543_XForm.Diseño
{
    class DiseñoComponentes
    {
        ArrayList ListaPestaña = new ArrayList();
        
        public static int intContadorPestana = 0;

        public void crearPestaña(TabControl miTab, ArrayList ListaTextBox)
        {
            // Creamos una nueva Pestaña
            TabPage NuevaPestaña = new TabPage("Nueva Pestaña " + intContadorPestana); // Creamos una nueva pestaña
            RichTextBox NuevoTextBox = new RichTextBox();
            NuevoTextBox.Text = "$#Escribe tu codigo aqui#$";
            NuevoTextBox.Name = "textArea" + intContadorPestana;
            //Tamaño de las ventanas
            NuevoTextBox.Width = 657;
            NuevoTextBox.Height = 307;
            ListaPestaña.Add(NuevaPestaña); // cada pestaña creada los añadimos en un arraylist
            miTab.TabPages.Add(NuevaPestaña); //cargamos la pestaña en el control
            NuevaPestaña.Controls.Add(NuevoTextBox);
            ListaTextBox.Add(NuevoTextBox);
            intContadorPestana++; //variable que lleva el control de la cantidad de pestaña creada
            miTab.SelectedTab = NuevaPestaña; //seleccionamos la pestaña
        }

        public void codigoaEvaluar(string strCodigoaEvaluar) {


            //MessageBox.Show("" + codF);

            Analizadores.Analizador analizar = new Analizador(new Gramatica());
            ParseTree arbol = analizar.isValid(strCodigoaEvaluar);
            if (arbol != null)
            {
                ConstructorAst constAst = new ConstructorAst();
                AST arbolAux = constAst.Analizar(arbol.Root);
                Ambito global = new Ambito(null);

                try {

                    if (arbolAux != null)
                    {
                        foreach (Instruccion inst in arbolAux.Instrucciones) {
                            //if (inst is Funcion) {

                            //}
                            if (inst is Declaracion) {
                                Declaracion declaracion = (Declaracion)inst;
                                declaracion.ejecutar(global, arbolAux);
                            }
                            //toca deficion clase

                        }

                        foreach (Instruccion ins in arbolAux.Instrucciones)
                        {
                            if (ins is Funcion)
                            {
                                Funcion funcion = (Funcion)ins;
                                global.agregar(funcion.Id, funcion);
                                foreach (NodoAST instruccion in funcion.LLInstrucciones)
                                {
                                    //if (instruccion is DefinicionStruct)
                                    //{
                                    //    DefinicionStruct crear = (DefinicionStruct)instruccion;
                                    //    crear.ejecutar(global, auxArbol);
                                    //}
                                }
                            }
                            if (ins is Declaracion)
                            {
                                Declaracion declaracion = (Declaracion)ins;
                                declaracion.ejecutar(global, arbolAux);
                            }
                            //if (ins is DefinicionStruct)
                            //{
                            //    DefinicionStruct crear = (DefinicionStruct)ins;
                            //    crear.ejecutar(global, auxArbol);
                            //}

                        }

                        foreach (Instruccion ins in arbolAux.Instrucciones)
                        {
                            if (ins is Principal)
                            {
                                Principal main = (Principal)ins;
                              
                                Ambito local = new Ambito(global);

                                main.ejecutar(local, arbolAux);
                            }
                        }
                    }
                    else {
                        MessageBox.Show("Cadena invalida");
                    }

                }
                catch(Exception ex) {
                    MessageBox.Show(ex.ToString());
                }

                //analizar.parse(arbol, new PrimeraPasada());
                MessageBox.Show("Cadena Valida");
            }
            else
            {
                MessageBox.Show("No Valida");
            }
        }
    }
}
