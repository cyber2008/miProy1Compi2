using _200816543_XForm.Acciones;
using _200816543_XForm.Analizadores;
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
                analizar.parse(arbol, new PrimeraPasada());
                MessageBox.Show("Cadena Valida");
            }
            else
            {
                MessageBox.Show("No Valida");
            }
        }
    }
}
