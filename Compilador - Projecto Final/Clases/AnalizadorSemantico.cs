using System.Collections.Generic;
using System.Linq;

namespace Compilador___Projecto_Final
{
    public class AnalizadorSemantico
    {
        public AnalizadorSemantico()
        {
            TablaSimbolos = new TablaSimbolos();
            Errores = new List<string>();
        }

        public TablaSimbolos TablaSimbolos { get; set; }

        public List<string> Errores { get; set; }
        
        public void ProcesarLexemas(List<Lexema> lexemas, List<Bloque> bloques)
        {
            TablaSimbolos = new TablaSimbolos();
            Errores = new List<string>();
            List<Lexema> lexemasVariables = lexemas.Where(x => x.TipoElemento == Enums.TipoElemento.Variable).ToList();

            foreach (Lexema lexema in lexemasVariables)
            {
                int indiceActual = lexemas.IndexOf(lexema);

                if (lexemas.ElementAtOrDefault(indiceActual - 1) != null &&
                    EsTipoDeclaracion(lexemas[indiceActual - 1].Texto))
                {
                    ProcesarDeclaracion(lexema, indiceActual, lexemas);
                }
                else if(lexemas[indiceActual + 1].TipoElemento == Enums.TipoElemento.OperadorAsignacion)
                {
                    int indexPuntoComa = IndicePuntoComa(lexemas, indiceActual);
                    if (indexPuntoComa != -1 && PuntoComaCorrecto(lexemas, indiceActual, indexPuntoComa))
                    {
                        ProcesarReAsignacion(lexema, indiceActual, lexemas);
                    }
                }
            }
        }

        public bool EsTipoDeclaracion(string texto)
        {
            if (texto == "int" || texto == "char" || texto == "float" || texto == "double" || texto == "void" || texto == "booleano" || texto == "string")
            {
                return true;
            }

            return false;

        }

        public void ProcesarDeclaracion(Lexema lexema, int indiceLexema, List<Lexema> lexemas)
        {
            if (VariableDeclarada(lexema))
            {
                Errores.Add("Error: La variable \"" + lexema.Texto + "\" ya habia sido declarada anteriormente");
            }

            Enums.TipoVariable tipoVariable = TextoToTipo(lexemas[indiceLexema - 1].Texto);

            if (lexemas[indiceLexema + 1].TipoElemento == Enums.TipoElemento.OperadorAsignacion)
            {
                TablaSimbolos.InsertarRegistro(new RegistroTabla()
                {
                    Nombre = lexema.Texto,
                    TipoVariable = tipoVariable,
                    Valor = ProcesarAsignacion(indiceLexema + 2, lexemas, tipoVariable)
                });

            }
            else if (lexemas[indiceLexema + 1].TipoElemento == Enums.TipoElemento.OperadorTerminador)
            {
                TablaSimbolos.InsertarRegistro(new RegistroTabla()
                {
                    Nombre = lexema.Texto,
                    TipoVariable = tipoVariable
                });
            }
        }

        public void ProcesarReAsignacion(Lexema lexema, int indiceLexema, List<Lexema> lexemas)
        {
            if (!VariableDeclarada(lexema))
            {
                Errores.Add("Error: La variable \"" + lexema.Texto + "\" no ha sido declarada anteriormente");
            }
            else
            {
                RegistroTabla registroActual = TablaSimbolos.RegistrosTabla.First(x => x.Nombre == lexema.Texto);
                Enums.TipoVariable tipoVariable = registroActual.TipoVariable == null
                    ? Enums.TipoVariable.Void
                    : registroActual.TipoVariable.Value;

                string resultAsignacion = ProcesarAsignacion(indiceLexema + 2, lexemas, tipoVariable);

                if (resultAsignacion != "Error")
                {
                    TablaSimbolos.ActualizarValorRegistro(registroActual.Nombre, resultAsignacion);
                }
            }
        }

        public string ProcesarAsignacion(int indiceInicioAsignacion, List<Lexema> lexemas, Enums.TipoVariable tipoVariable)
        {
            string result = "";
            
            if (lexemas[indiceInicioAsignacion + 1].TipoElemento == Enums.TipoElemento.OperadorTerminador)
            {
                if (lexemas[indiceInicioAsignacion].TipoElemento == Enums.TipoElemento.Variable)
                {
                    if (VariableDeclarada(lexemas[indiceInicioAsignacion]))
                    {
                        RegistroTabla registroTabla = TablaSimbolos.RegistrosTabla.First(x => x.Nombre == lexemas[indiceInicioAsignacion].Texto);

                        if (registroTabla.TipoVariable == tipoVariable)
                        {
                            result = registroTabla.Valor;
                        }
                        else
                        {
                            result = "Error";
                            Errores.Add("Se intenta asignar a \"" + lexemas[indiceInicioAsignacion - 2] +
                                        "\" un tipo incompatible: " + registroTabla.TipoVariable);
                            ;
                        }
                    }
                    else
                    {
                        result = "Error";
                        Errores.Add("Se intenta asignar a \"" + lexemas[indiceInicioAsignacion - 2].Texto + "\" el valor de una variable que no existe");
                    }
                }
                else
                {
                    if (TipoElementoToTipoVar(lexemas[indiceInicioAsignacion].TipoElemento, lexemas[indiceInicioAsignacion].Texto) == tipoVariable) //Esta asignando el tipo correcto
                    {
                        result = lexemas[indiceInicioAsignacion].Texto;
                    }
                    else
                    {
                        result = "Error";
                        Errores.Add("El valor que se intento asignar a \"" + lexemas[indiceInicioAsignacion - 2].Texto + "\" no es compatible con el tipo " + tipoVariable);
                    }
                }
            }
            else
            {
                string resTentativo = AsignacionCompleja(indiceInicioAsignacion, IndicePuntoComa(lexemas, indiceInicioAsignacion) - 1, lexemas, tipoVariable);
                if (tipoVariable == Enums.TipoVariable.Int && resTentativo.Contains("."))
                {
                    result = "Error";
                    Errores.Add("El valor que se intenta asignar a \"" + lexemas[indiceInicioAsignacion - 2].Texto + "\"" + " fue: " + resTentativo + " y" + " no es compatible con el tipo " + tipoVariable);
                }
                else
                {
                    result = resTentativo;
                }
            }
            return result;
        }


        public string AsignacionCompleja(int indiceInicio, int indiceFin, List<Lexema> lexemas,
            Enums.TipoVariable tipoVariable, string resultParcial = "")
        {
            string result = "";

            List<Lexema> copiaLexemas = new List<Lexema>();
            for (int i = indiceInicio; i <= indiceFin; i++)
            {
                copiaLexemas.Add(lexemas[i]);
            }

            for (int i = 0; i < copiaLexemas.Count; i++)
            {
                if (copiaLexemas[i].TipoElemento == Enums.TipoElemento.Variable)
                {
                    if (VariableDeclarada(copiaLexemas[i]))
                    {
                        copiaLexemas[i] = VariableValor(copiaLexemas[i]);
                    }
                    else
                    {
                        Errores.Add("La variable \"" + copiaLexemas[i].Texto + "\" no esta declarada");
                        result = "Error";
                        break;
                    }
                }
            }

            if (copiaLexemas.Any(y => y.TipoElemento == Enums.TipoElemento.Parentesis))
            {

            }
            else
            {
                Lexema ladoIzq = null;
                Lexema ladoDer = null;
                Lexema op = null;
                for (int i = 0; i < copiaLexemas.Count; i++)
                {
                    Lexema lexemaActual = copiaLexemas[i];
                    if (lexemaActual.TipoElemento == Enums.TipoElemento.Numero || lexemaActual.TipoElemento == Enums.TipoElemento.Cadena || lexemaActual.TipoElemento == Enums.TipoElemento.Caracter)
                    {
                        if (ladoIzq == null)
                        {
                            ladoIzq = lexemaActual;
                        }
                        else
                        {
                            ladoDer = lexemaActual;
                        }
                    }

                    if (lexemaActual.TipoElemento == Enums.TipoElemento.OperadorAritmetico)
                    {
                        op = lexemaActual;

                        if (copiaLexemas.ElementAtOrDefault(i + 2) != null && (copiaLexemas[i + 2].Texto == "*" || copiaLexemas[i + 2].Texto == "/"))
                        {
                            copiaLexemas[i + 1].Texto = AsignacionCompleja(i + 1, i + 3, copiaLexemas, tipoVariable);
                            copiaLexemas[i + 3].Texto = "0";
                            copiaLexemas[i + 2].Texto = "+";
                        }
                    }

                    if (ladoIzq != null && ladoDer != null && op != null)
                    {
                        result = RealizarOperacion(ladoIzq, ladoDer, op, tipoVariable);

                        ladoIzq = new Lexema()
                        {
                            Texto = result,
                            TipoElemento = Enums.TipoElemento.Numero
                        };
                        ladoDer = null;
                        op = null;
                    }
                }
            }
            return result;
        }

        public Lexema VariableValor(Lexema lexema)
        {
            RegistroTabla registro = TablaSimbolos.RegistrosTabla.First(x => x.Nombre == lexema.Texto);
            return new Lexema()
            {
                Texto = registro.Valor,
                TipoElemento = TipoVarToTipoElemento(registro.TipoVariable.Value)
            };
        }

        public string RealizarOperacion(Lexema ladoIzq, Lexema ladoDer, Lexema op, Enums.TipoVariable tipoVariable)
        {
            string result = "";
            Enums.TipoVariable tipoIzq = TipoElementoToTipoVar(ladoIzq.TipoElemento, ladoIzq.Texto);
            Enums.TipoVariable tipoDer = TipoElementoToTipoVar(ladoDer.TipoElemento, ladoDer.Texto);

            if (tipoVariable == Enums.TipoVariable.Float || tipoVariable == Enums.TipoVariable.Double)
            {
                tipoIzq = tipoVariable;
                tipoDer = tipoVariable;
            }
            if (tipoIzq == tipoDer)
            {
                if (tipoIzq == Enums.TipoVariable.Int)
                {
                    int enteroIzq = int.Parse(ladoIzq.Texto);
                    int enteroDer = int.Parse(ladoDer.Texto);

                    if (op.Texto == "+")
                    {
                        result = (enteroIzq + enteroDer).ToString();
                    }
                    if (op.Texto == "-")
                    {
                        result = (enteroIzq - enteroDer).ToString();
                    }
                    if (op.Texto == "*")
                    {
                        result = (enteroIzq * enteroDer).ToString();
                    }
                    if (op.Texto == "/")
                    {
                        if (enteroDer == 0)
                        {
                            result = "Error";
                            Errores.Add("No se puede dividir entre cero");
                        }
                        else
                        {
                            if (((enteroIzq / enteroDer) % 1) == 0)
                            {
                                result = (enteroIzq / enteroDer).ToString();
                            }
                            else
                            {
                                result = "Error";
                                Errores.Add("La division resulta en un resultado decimal, no asiganble al tipo \"int\"");
                            }
                        }
                    }
                }
                else if (tipoIzq == Enums.TipoVariable.Float || tipoIzq == Enums.TipoVariable.Double)
                {
                    decimal decimalIzq = decimal.Parse(ladoIzq.Texto);
                    decimal decimalDer = decimal.Parse(ladoDer.Texto);

                    if (op.Texto == "+")
                    {
                        result = (decimalIzq + decimalDer).ToString();
                    }
                    if (op.Texto == "-")
                    {
                        result = (decimalIzq - decimalDer).ToString();
                    }
                    if (op.Texto == "*")
                    {
                        result = (decimalIzq * decimalDer).ToString();
                    }
                    if (op.Texto == "/")
                    {
                        if (decimalDer == 0)
                        {
                            result = "Error";
                            Errores.Add("No se puede dividir entre cero");
                        }
                        else
                        {
                            result = (decimalIzq / decimalDer).ToString();
                        }
                    }
                }
            }
            else
            {
                result = "Error";
                Errores.Add("Tipos de datos incompatibles: \"" + ladoIzq.Texto + "\" y \"" + ladoDer.Texto + "\"");
            }

            return result;
        }

        public int IndicePuntoComa(List<Lexema> lexemas, int posCursor)
        {
            bool salir = false;

            do
            {
                if (posCursor < lexemas.Count)
                {
                    if (lexemas[posCursor].Texto == ";")
                    {
                        salir = true;
                    }
                    else
                    {
                        posCursor++;
                    }
                }
                else
                {
                    salir = true;
                    posCursor = -1;
                }
            } while (!salir);

            return posCursor;
        }

        public bool PuntoComaCorrecto(List<Lexema> lexemas, int posCursor, int indicePuntoComa)
        {
            int asignaciones = 0;
            int declarartipoVar = 0;
            int llaves = 0;

            for (int i = posCursor; i < indicePuntoComa; i++)
            {
                if (lexemas[i].TipoElemento == Enums.TipoElemento.OperadorAsignacion)
                {
                    asignaciones++;
                }
                if (lexemas[i].TipoElemento == Enums.TipoElemento.TipoVariable)
                {
                    declarartipoVar++;
                }
                if (lexemas[i].TipoElemento == Enums.TipoElemento.Llave)
                {
                    llaves++;
                }
            }
            if (asignaciones > 1 || declarartipoVar > 1 || llaves > 0)
            {
                return false;
            }
            return true;
        }

        public Enums.TipoVariable TipoElementoToTipoVar(Enums.TipoElemento tipoElemento, string textoElemento, Enums.TipoVariable helper = Enums.TipoVariable.Float)
        {
            Enums.TipoVariable tipoVariable = Enums.TipoVariable.Void;
            switch (tipoElemento)
            {
                case Enums.TipoElemento.Variable:
                    break;
                case Enums.TipoElemento.PalabraReservada:
                    break;
                case Enums.TipoElemento.TipoVariable:
                    break;
                case Enums.TipoElemento.Numero:
                    tipoVariable = textoElemento.Contains(".") ? helper : Enums.TipoVariable.Int;
                    break;
                case Enums.TipoElemento.OperadorAritmetico:
                    break;
                case Enums.TipoElemento.OperadorRelacional:
                    break;
                case Enums.TipoElemento.OperadorLogico:
                    break;
                case Enums.TipoElemento.OperadorAsignacion:
                    break;
                case Enums.TipoElemento.OperadorTerminador:
                    break;
                case Enums.TipoElemento.Parentesis:
                    break;
                case Enums.TipoElemento.Corchete:
                    break;
                case Enums.TipoElemento.Llave:
                    break;
                case Enums.TipoElemento.Error:
                    break;
                case Enums.TipoElemento.OperadorIncremental:
                    break;
                case Enums.TipoElemento.OperadorDecremental:
                    break;
                case Enums.TipoElemento.Caracter:
                    tipoVariable = Enums.TipoVariable.Char;
                    break;
                case Enums.TipoElemento.Cadena:
                    tipoVariable = Enums.TipoVariable.String;
                    break;
                case Enums.TipoElemento.Coma:
                    break;
            }
            return tipoVariable;
        }

        public Enums.TipoElemento TipoVarToTipoElemento(Enums.TipoVariable tipoVariable)
        {
            Enums.TipoElemento tipoElemento = Enums.TipoElemento.Error;

            switch (tipoVariable)
            {
                case Enums.TipoVariable.String:
                    tipoElemento = Enums.TipoElemento.Cadena;
                    break;
                case Enums.TipoVariable.Char:
                    tipoElemento = Enums.TipoElemento.Caracter;
                    break;
                case Enums.TipoVariable.Int:
                    tipoElemento = Enums.TipoElemento.Numero;
                    break;
                case Enums.TipoVariable.Float:
                    tipoElemento = Enums.TipoElemento.Numero;
                    break;
                case Enums.TipoVariable.Double:
                    tipoElemento = Enums.TipoElemento.Numero;
                    break;
                case Enums.TipoVariable.Void:
                    break;
            }
            return tipoElemento;
        }

        public bool VariableDeclarada(Lexema lexema)
        {
            return TablaSimbolos.RegistrosTabla.Any(y => y.Nombre == lexema.Texto);
        }

        public Enums.TipoVariable TextoToTipo(string texto)
        {
            switch (texto)
            {
                case "int":
                    return Enums.TipoVariable.Int;
                case "char":
                    return Enums.TipoVariable.Char;
                case "float":
                    return Enums.TipoVariable.Float;
                case "double":
                    return Enums.TipoVariable.Double;
                case "void":
                    return Enums.TipoVariable.Void;
                case "string":
                    return Enums.TipoVariable.String;
                case "booleano":
                    return Enums.TipoVariable.Booleano;
            }
            return Enums.TipoVariable.Void;
        }
    }
}
