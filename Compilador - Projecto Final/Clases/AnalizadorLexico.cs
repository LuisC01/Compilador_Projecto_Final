using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Procesos
{
    public class AnalizadorLexico
    {
        /// <summary>
        /// Recibe el codigo en texto y me regresa una lista de lexema
        /// </summary>
        /// <param name="codigoTexto">Este codigo debe venir sin comentarios y sin saltos</param>
        /// <returns></returns>
        public List<Lexema> ExtraerLexemas(string codigoTexto)
        {
            string s = Enums.TipoVariablePatron();
            List<Lexema> lexemas = new List<Lexema>();

            //TODO: Falta separar correctamente los tipos de operadores
            Regex r = new Regex(@"(?<" + Enums.TipoElemento.OperadorRelacional + @">(==|!=|>=|>|<=|<|\+=|\*=))" + "|" +
                                @"(?<" + Enums.TipoElemento.OperadorLogico + @">(&&|!|\|\|))" + "|" +
                                @"(?<" + Enums.TipoElemento.OperadorIncremental + @">(\+\+))" + "|" +
                                @"(?<" + Enums.TipoElemento.OperadorDecremental + @">(--))" + "|" +
                                @"(?<" + Enums.TipoElemento.OperadorAritmetico + @">[+|\-|*|%|/])" + "|" + 
                                @"(?<" + Enums.TipoElemento.TipoVariable + ">(" + Enums.TipoVariablePatron() + "))" + "|" +
                                @"(?<" + Enums.TipoElemento.PalabraReservada + ">(" + Enums.TipoPalabraReservadaPatron() + "))" + "|" +
                                @"(?<" + Enums.TipoElemento.PalabraDefinicion + ">(" + Enums.TipoPalabraDefinicionPatron() + "))" + "|" +
                                @"(?<" + Enums.TipoElemento.Numero + @">(\d+(\.\d+)?))" + "|" +
                                @"(?<" + Enums.TipoElemento.Variable + ">[_A-Za-z_]+([0-9]+)?)" + "|" +
                                @"(?<" + Enums.TipoElemento.Cadena + @">(@""(?:[^""]|"""")*""|""(?:\\.|[^\\""])*""))" + "|" +
                                @"(?<" + Enums.TipoElemento.Caracter + ">\'([^\'\\\\\\n]|\\\\.)\')" + "|" +
                                @"(?<" + Enums.TipoElemento.OperadorAsignacion + ">(=|-=|%=))" + "|" + //TODO: Pendiente el += y *=
                                @"(?<" + Enums.TipoElemento.Parentesis + @">[(|)])" + "|" +
                                @"(?<" + Enums.TipoElemento.Llave + @">[{|}])" + "|" +
                                @"(?<" + Enums.TipoElemento.Corchete + @">[\[|\]])" + "|" +
                                @"(?<" + Enums.TipoElemento.OperadorTerminador + ">(;))" + "|" +
                                @"(?<" + Enums.TipoElemento.Coma + ">(,))" + "|" +
                                @"(?<" + Enums.TipoElemento.Error + @">\W|_)"
                               );
            Match m = r.Match(codigoTexto);

            while (m.Success)
            {
                if (m.Groups[Enums.TipoElemento.OperadorAritmetico.ToString()].Success) //Si es un operador, procedemos a hacer cualquier otra cosa
                {
                    lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.OperadorAritmetico});
                }
                else if (m.Groups[Enums.TipoElemento.TipoVariable.ToString()].Success)
                {
                    lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.TipoVariable });
                }
                else if (m.Groups[Enums.TipoElemento.PalabraReservada.ToString()].Success)
                {
                    lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.PalabraReservada });
                }
                else if (m.Groups[Enums.TipoElemento.Variable.ToString()].Success)
                {
                    lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.Variable });
                }
                else if (m.Groups[Enums.TipoElemento.Cadena.ToString()].Success)
                {
                    lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.Cadena });
                }
                else if (m.Groups[Enums.TipoElemento.Caracter.ToString()].Success)
                {
                    lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.Caracter });
                }
                else if (m.Groups[Enums.TipoElemento.Numero.ToString()].Success)
                {
                    if (m.Value.Any(char.IsLetter))
                    {
                        lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.Error, Error = true, MensajeError = "Lexema no reconocido" });
                    }
                    else
                    {
                        lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.Numero });
                    }
                }
                else if (m.Groups[Enums.TipoElemento.OperadorAsignacion.ToString()].Success)
                {
                    lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.OperadorAsignacion });
                }
                else if (m.Groups[Enums.TipoElemento.OperadorRelacional.ToString()].Success)
                {
                    lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.OperadorRelacional });
                }
                else if (m.Groups[Enums.TipoElemento.OperadorLogico.ToString()].Success)
                {
                    lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.OperadorLogico });
                }
                else if (m.Groups[Enums.TipoElemento.Parentesis.ToString()].Success)
                {
                    lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.Parentesis });
                }
                else if (m.Groups[Enums.TipoElemento.Llave.ToString()].Success)
                {
                    lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.Llave });
                }
                else if (m.Groups[Enums.TipoElemento.Corchete.ToString()].Success)
                {
                    lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.Corchete });
                }
                else if (m.Groups[Enums.TipoElemento.OperadorTerminador.ToString()].Success)
                {
                    lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.OperadorTerminador });
                }
                else if (m.Groups[Enums.TipoElemento.Coma.ToString()].Success)
                {
                    lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.Coma });
                }
                else if (m.Groups[Enums.TipoElemento.PalabraDefinicion.ToString()].Success)
                {
                    lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.PalabraDefinicion });
                }
                else if (m.Groups[Enums.TipoElemento.OperadorIncremental.ToString()].Success)
                {
                    lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.OperadorIncremental });
                }
                else if (m.Groups[Enums.TipoElemento.OperadorDecremental.ToString()].Success)
                {
                    lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.OperadorDecremental });
                }
                else
                {
                    if (!string.IsNullOrEmpty(m.Value) && !string.IsNullOrWhiteSpace(m.Value))
                    {
                        lexemas.Add(new Lexema() { Texto = m.Value, TipoElemento = Enums.TipoElemento.Error, Error = true, MensajeError = "Lexema no reconocido" });
                    } 
                }
                m = m.NextMatch();
            }
            return lexemas;
        }

        /// <summary>
        /// Toma un codigo y le retira los comentarios
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public string RetirarComentarios(string codigo)
        {
            string comentariosBloque = @"/\*(.*?)\*/";
            string comentariosLinea = @"//(.*?)\r?\n";
            string strings = @"""((\\[^\n]|[^""\n])*)""";
            string verbatimStrings = @"@(""[^""]*"")+";

            string newCode = Regex.Replace(codigo,
                comentariosBloque + "|" + comentariosLinea + "|" + strings + "|" + verbatimStrings,
                me =>
                {
                    if (me.Value.StartsWith("/*") || me.Value.StartsWith("//"))
                        return me.Value.StartsWith("//") ? Environment.NewLine : "";
                    // Se mantiene el string
                    return me.Value;
                },
                RegexOptions.Singleline);
            return newCode;
        }

        /// <summary>
        /// Toma un codigo y le retira los saltos de linea
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public string RetirarSaltos(string codigo)
        {
            return codigo.Replace(Environment.NewLine, null);
        }
    }
}