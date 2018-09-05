using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace _200816543_XForm.Acciones
{
    public class TablaSimbolos : IEquatable<TablaSimbolos>
    {
        public int TablaSimbolosNo { get; set; }
        public string TablaSimbolosNombre { get; set; }
        public string TablaSimbolosTipo { get; set; }
        public string TablaSimbolosAmbito { get; set; }
        public int TablaSimbolosValor { get; set; }
        public ParseTreeNode apuntador { get; set; }
        public Object valor { get; set; }

        public override string ToString()
        {
            return "No: " + TablaSimbolosNo + "   Name: " + TablaSimbolosNombre +
                "   Tipo: " + TablaSimbolosTipo + "   Ambito: " + TablaSimbolosAmbito +
                    "   Valor: " + valor + " apuntador: " + apuntador;
        }

        public bool Equals(TablaSimbolos other)
        {
            if (other == null) return false;
            return (this.TablaSimbolosNombre.Equals(other.TablaSimbolosNombre));
        }
    }
}
