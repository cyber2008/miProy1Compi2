using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace _200816543_XForm.Analizadores
{
        interface Accion
        {
           // void doAction(ParseTreeNode ptNode);
            void action(ParseTreeNode ptNode);
        }
}
