using Irony.Parsing;


namespace _200816543_XForm.Analizadores
{
    class Gramatica:Grammar
    {
        public Gramatica():base(false) //no es case sensitive
        {
            #region Terminales
            #region Comentarios
            CommentTerminal comentarioLinea = new CommentTerminal("comentarioLinea", "$$", "\n", "\r\n"); 
            CommentTerminal comentarioBloque = new CommentTerminal("comentarioBloque", "$#", "#$");
            base.NonGrammarTerminals.Add(comentarioLinea);
            base.NonGrammarTerminals.Add(comentarioBloque);
            #endregion

            #region ExpresionesRegulares
            IdentifierTerminal id = new IdentifierTerminal("id");
            //NumberLiteral number = new NumberLiteral("number");
            var number = TerminalFactory.CreateCSharpNumber("number");
            StringLiteral cadena = new StringLiteral("cadena", "\"", StringOptions.AllowsAllEscapes);
            StringLiteral caracter = new StringLiteral("caracter", "\'", StringOptions.IsChar);
            #endregion

            #region PalabrasReservadas
            KeyTerm miEntero = ToTerm("entero"),
                miDecimal = ToTerm("decimal"),
                miCadena = ToTerm("cadena"),
                miCaracter = ToTerm("caracter"),
                miBooleano = ToTerm("booleano"),
                miVacio = ToTerm("vacio"),
                miPrincipal = ToTerm("principal"),
                miRetorno = ToTerm("retorno"),
                miRomper = ToTerm("romper"),
                miDefecto = ToTerm("defecto"),
                miContinuar = ToTerm("continuar"),
                miIf = ToTerm("si"),
                miElse = ToTerm("sino"),
                miDo = ToTerm("hacer"),
                miWhile = ToTerm("mientras"),
                miFor = ToTerm("repetir"),
                miHasta = ToTerm("hasta"),
                miPrint = ToTerm("imprimir"),
                miVerdadero = ToTerm("verdadero"),
                miFalso = ToTerm("falso")
                ;

                MarkReservedWords("entero", "decimal", "cadena", "caracter",
                    "booleano", "vacio", "principal", "retorno", "defecto", 
                    "continuar", "si", "sino", "hacer", "mientras", "repetir", 
                    "hasta", "imprimir", "verdadero", "falso");

            #endregion

            #region Simbolos
                Terminal parizq = ToTerm("("),
                    parder = ToTerm(")"),
                    llaveizq = ToTerm("{"),
                    llaveder = ToTerm("}"),
                    mas = ToTerm("+"),
                    menos = ToTerm("-"),
                    por = ToTerm("*"),
                    div = ToTerm("/"),
                    potencia = ToTerm("^"),
                    modulo = ToTerm("%"),
                    coma = ToTerm(","),
                    ptComa = ToTerm(";"),
                    igual = ToTerm("="),
                    masMas = ToTerm("++"),
                    menosMenos = ToTerm("--"),
                    miOr = ToTerm("||"),
                    miAnd = ToTerm("&&"),
                    not = ToTerm("!"),
                    igualIgual = ToTerm("=="),
                    diferente = ToTerm("!="),
                    mayorQue = ToTerm(">"),
                    mayorIgualQue = ToTerm(">="),
                    menorQue = ToTerm("<"),
                    menorIgualQue = ToTerm("<=")
                ;
            #endregion

            #endregion

            #region NoTerminales
            NonTerminal S = new NonTerminal("S"),
                CUERPO = new NonTerminal("CUERPO"),
                CAMPOS = new NonTerminal("CAMPOS"),
                METODO = new NonTerminal("METODO"),
                SENTENCIAS = new NonTerminal("SENTENCIAS"),
                LISTA_SENTENCIA = new NonTerminal("LISTA_SENTENCIA"),
                DECLARACION = new NonTerminal("DECLARACION"),
                ASIGNACION = new NonTerminal("ASIGNACION"),
                LISTA_IDS = new NonTerminal("LISTA_IDS"),
                LISTA_PARAM = new NonTerminal("LISTA_PARAM"),
                PARAMETRO = new NonTerminal("PARAMETRO"),
                LISTA_ATRI = new NonTerminal("LISTA_ATRI"),
                ATRIBUTO = new NonTerminal("ATRIBUTO"),
                SENTENCIA = new NonTerminal("SENTENCIA"),
                SENTENCIA_IF = new NonTerminal("SENTENCIA_IF"),
                SENTENCIA_WHILE = new NonTerminal("SENTENCIA_WHILE"),
                SENTENCIA_BREAK = new NonTerminal("SENTENCIA_BREAK"),
                SENTENCIA_CONTINUE = new NonTerminal("SENTENCIA_CONTINUE"),
                SENTENCIA_RETURN = new NonTerminal("SENTENCIA_RETURN"),
                SENTENCIA_PRINT = new NonTerminal("SENTENCIA_PRINT"),
                SENTENCIA_CLASE = new NonTerminal("SENTENCIA_CLASE"),
                LLAMADA = new NonTerminal("LLAMADA"),
                ACCESO = new NonTerminal("ACCESO"),
                EXP = new NonTerminal("EXP"),
                EXP_ARIT = new NonTerminal("EXP_ARIT"),
                EXP_REL = new NonTerminal("EXP_REL"),
                EXP_LOG = new NonTerminal("EXP_LOG"),
                LISTA_ARG = new NonTerminal("LISTA_ARG"),
                TIPO = new NonTerminal("TIPO"),
                TIPO_PRIM = new NonTerminal("TIPO_PRIM")
                ;
            #endregion

            #region GramaticaAntigua
            //NonTerminal S = new NonTerminal("S"),
            //            I = new NonTerminal("I"),
            //            CUERPO = new NonTerminal("CUERPO"),
            //            DECLARACION_GLOBAL = new NonTerminal("DECLARACION_GLOBAL"),
            //            LISTA_IDS = new NonTerminal("LISTA_IDS"),
            //            METODO = new NonTerminal("METODO"),
            //            MT_ENCABEZADO = new NonTerminal("MT_ENCABEZADO"),
            //            MT_CUERPO = new NonTerminal("MT_CUERPO"),
            //            SENTENCIA = new NonTerminal("SENTENCIA"),
            //            ASIGNACION = new NonTerminal("ASIGNACION"),
            //            DECLARACION_LOCAL = new NonTerminal("DECLARACION_LOCAL"),
            //            MT_LLAMADA = new NonTerminal("MT_LLAMADA"),
            //            //PLOT = new NonTerminal("PLOT"),
            //            //IMG = new NonTerminal("IMG"),
            //            MT_RETURN = new NonTerminal("MT_RETURN"),
            //            E = new NonTerminal("E")//,
            //MT_PARAMETROS = new NonTerminal("MT_PARAMETROS"),
            //FUNCION = new NonTerminal("FUNCION"),
            //FUNC_CUERPO = new NonTerminal("FUNC_CUERPO"),
            //SENTENCIA2 = new NonTerminal("SENTENCIA2"),
            //FUNC_RETURN = new NonTerminal("FUNC_RETURN"),
            //CONSTANTES = new NonTerminal("CONSTANTES"),
            //DIMENSION = new NonTerminal("DIMENSION"),
            //MAIN = new NonTerminal("MAIN"),
            //MAIN_CUERPO = new NonTerminal("MAIN_CUERPO"),
            //SENTENCIA3 = new NonTerminal("SENTENCIA3")
            ;
            #endregion

            S.Rule = EXP; 
                //CUERPO;

/*            CUERPO.Rule = MakePlusRule(CUERPO, CAMPOS);

            CAMPOS.Rule = METODO
                        | DECLARACION
                        | id
                        //| SENTENCIA_CLASE
                        ;

            METODO.Rule = TIPO + id + parizq + LISTA_PARAM + parder + SENTENCIAS
                        | id + id + parizq + LISTA_PARAM + parder + SENTENCIAS
                        | TIPO + id + parizq + parder + SENTENCIAS
                        | id + id + parizq +parder + SENTENCIAS
                        | TIPO + miPrincipal + parizq + parder + SENTENCIAS
                        ;

            LISTA_PARAM.Rule = MakePlusRule(LISTA_PARAM, coma, PARAMETRO);

            PARAMETRO.Rule = TIPO + id;

            SENTENCIAS.Rule = llaveizq + LISTA_SENTENCIA+ llaveder;

            LISTA_SENTENCIA.Rule = MakePlusRule(LISTA_SENTENCIA, SENTENCIA);

            SENTENCIA.Rule = DECLARACION + ptComa
                              | ASIGNACION + ptComa
                              | ACCESO + ptComa
                              | LLAMADA + ptComa
                              | SENTENCIA_IF
                              | SENTENCIA_WHILE
                              | SENTENCIA_RETURN + ptComa
                              | SENTENCIA_BREAK + ptComa
                              | SENTENCIA_CONTINUE + ptComa
                              | SENTENCIA_PRINT + ptComa
                              //| SENTENCIA_CLASE + ptComa
                              ;

            DECLARACION.Rule = TIPO + LISTA_IDS + "=" + EXP
                            | TIPO + LISTA_IDS
                            | id + id
                            ;

            ASIGNACION.Rule = LISTA_IDS + "=" + EXP
                              | id + "." + id + "=" + EXP
                              ;

            LISTA_IDS.Rule = MakePlusRule(LISTA_IDS, coma, id);

            SENTENCIA_IF.Rule = miIf + parizq + EXP + parder + SENTENCIAS
                                | miIf + parizq + EXP + parder + SENTENCIAS + miElse + SENTENCIAS
                                ;

            SENTENCIA_WHILE.Rule = miWhile + parizq + EXP + parder + SENTENCIAS
                ;

            SENTENCIA_RETURN.Rule = miRetorno + EXP
                                    | miRetorno;

            SENTENCIA_BREAK.Rule = miRomper;

            SENTENCIA_CONTINUE.Rule = miContinuar;

            SENTENCIA_PRINT.Rule = miPrint + parizq + LISTA_ATRI + parder;

            //Pendiente sentencia struct

            LLAMADA.Rule = id + parizq + LISTA_ARG + parder
                          | id + parizq + parder
                          ;

            ACCESO.Rule = id + "." + id;*/

            EXP.Rule = EXP_ARIT //YAPP
                       | EXP_LOG
                       | EXP_REL
                       | TIPO_PRIM //YAPP
                       // | ACCESO
                       | parizq + EXP + parder
                       //| LLAMADA
                       ;

            EXP_LOG.Rule = EXP + miOr + EXP
                           | EXP + miAnd + EXP
                           | not + EXP
                            ;

            EXP_REL.Rule = EXP + igualIgual + EXP
                           | EXP + diferente + EXP
                           | EXP + menorQue + EXP
                           | EXP + mayorQue + EXP
                           | EXP + menorIgualQue + EXP
                           | EXP + mayorIgualQue + EXP
                            ;

            EXP_ARIT.Rule = menos + EXP //YAPP
                | EXP + mas + EXP //YAPP
                | EXP + menos + EXP //YAPP
                | EXP + por + EXP //YAPP
                | EXP + div + EXP //YAPP
                | EXP + modulo + EXP //YAPP
                | EXP + potencia + EXP //YAPP
                | EXP + menosMenos
                | EXP + masMas
                //| MT_LLAMADA
        ;

            TIPO_PRIM.Rule = number //YAPP
                        | cadena
                        | caracter
                        | miVerdadero
                        | miFalso
                        | id
                        ;

            /*LISTA_ARG.Rule = MakeStarRule(LISTA_ARG, coma, EXP);

            TIPO.Rule = miBooleano
                | miCaracter
                | miCadena
                | miEntero
                | miDecimal
                | miVacio
                ;*/

            this.Root = S;


            #region Precedencia
            RegisterOperators(1, Associativity.Right, igual);
            RegisterOperators(2, Associativity.Left, miOr);
            RegisterOperators(3, Associativity.Left, miAnd);
            RegisterOperators(4, Associativity.Left, igualIgual, diferente);
            RegisterOperators(5, Associativity.Left, menorQue, menorIgualQue, mayorQue, mayorIgualQue);
            RegisterOperators(6, Associativity.Left, mas, menos);
            RegisterOperators(7, Associativity.Left, por, div, modulo);
            RegisterOperators(8, Associativity.Right, potencia);
            RegisterOperators(9, Associativity.Right, masMas, menosMenos, not);
            

            MarkPunctuation(parizq, parder, llaveder, llaveizq, ptComa, coma);
            

            /*RegisterOperators(1, "||");
            RegisterOperators(2, "&&");
            RegisterOperators(3, "==", "!=");
            RegisterOperators(4, "<", "<=",">",">=");
            RegisterOperators(5, "+", "-");
            RegisterOperators(6, "*", "/", "%");
            //RegisterOperators(8, "(", ")");*/
            #endregion

            //RegisterOperators(7, Associativity.Right, "--");
            //RegisterOperators(7, Associativity.Right, "++");
            //RegisterOperators(7, Associativity.Right, "!");
            //RegisterOperators(7, Associativity.Right, "+");
            //RegisterOperators(7, Associativity.Right, "-");
            //RegisterOperators(7, Associativity.Right, "*");
        }
    }
}
