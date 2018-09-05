using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _200816543_XForm.Analizadores;
using Irony.Ast;
using Irony.Parsing;

namespace _200816543_XForm
{
    public partial class Form1 : Form
    {
        ArrayList ListaTextBox = new ArrayList();
        String strCodigoaEvaluar;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Diseño.DiseñoComponentes dis = new Diseño.DiseñoComponentes();
            strCodigoaEvaluar = "";

            foreach (RichTextBox value in ListaTextBox)
            {
                strCodigoaEvaluar = strCodigoaEvaluar + value.Text;
            }
            dis.codigoaEvaluar(strCodigoaEvaluar);
        }

        private void nuevaPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Diseño.DiseñoComponentes dis = new Diseño.DiseñoComponentes();
            dis.crearPestaña(tabControl1, ListaTextBox);
        }
    }
}
