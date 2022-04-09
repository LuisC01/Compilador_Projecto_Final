using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Compilador___Projecto_Final
{
    public class AnalizadorLexico
    {
        public List<Lexema> ExtraerLexemas(string codigoTexto)
        {
            string s = Enums.TipoVariablePatron();
            List<Lexema> lexemas = new List<Lexema>();

            Regex r = new Regex(@"(?<" + Enums.TipoElemento.OperadorRelacional + @">(==|!=|>=|>|<=|<|\+=|\*=))" + "|" +
                                @"(?<" + Enums.TipoElemento.OperadorLogico + @">(&&|!|\|\|))" + "|" +
                                @"(?<" + Enums.TipoElemento.OperadorIncremental + @">(\+\+))" + "|" +
                                @"(?<" + Enums.TipoElemento.OperadorDecremental + @">(--))" + "|" +
                                @"(?<" + Enums.TipoElemento.OperadorAritmetico + @">[+|\-|*|%|/])" + "|" + 
                                @"(?<" + Enums.TipoElemento.TipoVariable + ">(" + Enums.TipoVariablePatron() + "))" + "|" +
                                @"(?<" + Enums.TipoElemento.PalabraReservada + ">(" + Enums.TipoPalabraReservadaPatron() + "))" + "|" +
                                @"(?<" + Enums.TipoElemento.Numero + @">(\d+(\.\d+)?))" + "|" +
                                @"(?<" + Enums.TipoElemento.Variable + ">[_A-Za-z_]+([0-9]+)?)" + "|" +
                                @"(?<" + Enums.TipoElemento.Cadena + @">(@""(?:[^""]|"""")*""|""(?:\\.|[^\\""])*""))" + "|" +
                                @"(?<" + Enums.TipoElemento.Caracter + ">\'([^\'\\\\\\n]|\\\\.)\')" + "|" +
                                @"(?<" + Enums.TipoElemento.OperadorAsignacion + ">(=|-=|%=))" + "|" +
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
                if (m.Groups[Enums.TipoElemento.OperadorAritmetico.ToString()].Success)
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
                    
                    return me.Value;
                },
                RegexOptions.Singleline);
            return newCode;
        }

        public string RetirarSaltos(string codigo)
        {
            return codigo.Replace(Environment.NewLine, null);
        }
    }
}