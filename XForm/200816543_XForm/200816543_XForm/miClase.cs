using _200816543_XForm.ambito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200816543_XForm.ast.miBase
{
    public class miClase
    {
        private LinkedList<Declaracion> declaraciones;

        private string id;

        public miClase(LinkedList<Declaracion> declaraciones, string id) {
            this.Declaraciones = declaraciones;
            this.Id = id;
        }

        public LinkedList<Declaracion> Declaraciones {
            get { return declaraciones; }
            set { declaraciones = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
