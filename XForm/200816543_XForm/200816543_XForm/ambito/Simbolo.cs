using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200816543_XForm.ambito
{
    public class Simbolo
    {

        public enum Tipos {
            STRING,
            INT,
            DOUBLE,
            CHAR,
            BOOL,
            NULL,
            OBJET
        }

        private string id;

        private object valor;

        private Tipos tipo;

        private LinkedList<Simbolo> listaParam;

        private bool funcion;
        
        //Constructor para la declaracion de variables u objetos
        public Simbolo(string id) {
            this.id = id;
            this.funcion = false;
        }

        //Constructor para declaración de parametros de los métodos
        public Simbolo(Tipos tipo, string id) {
            this.tipo = tipo;
            this.id = id;
            funcion = false;
        }

        public Simbolo(Tipos tipo, string id, object valor) {
            this.tipo = tipo;
            this.id = id;
            this.valor = valor;
            funcion = false;
        }

        public Simbolo(string id, object valor)
        {
            this.id = id;
            this.valor = valor;
            funcion = false;
        }

        //Constructor para definicion de funciones
        public Simbolo(string id, Tipos tipo, LinkedList<Simbolo> listaParam ) {
            this.id = id;
            this.tipo = tipo;
            this.listaParam = listaParam;
            funcion = true;
        }

        public string Id {
            get { return id; }
            set { id = value; }
        }

        public object Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public Tipos Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public LinkedList<Simbolo> ListaParametros
        {
            get { return listaParam; }
            set { listaParam = value; }
        }

        public bool Funcion
        {
            get { return funcion; }
            set { funcion = value; }
        }
    }
}
