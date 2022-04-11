using System;

namespace Compilador___Projecto_Final
{
    public static class Enums
    {
        // Este metodo Enum nos permite hacer una lista de constantes que son
        // un tipo de elemento en el programa.
        public enum TipoElemento
        {
            Variable,
            PalabraReservada,
            TipoVariable,
            Numero,
            OperadorAritmetico,
            OperadorRelacional,
            OperadorLogico,
            OperadorAsignacion,
            OperadorTerminador,
            Parentesis,
            Corchete,
            Llave,
            Error,
            OperadorIncremental,
            OperadorDecremental,
            Cadena,
            Caracter,
            Coma
        }
        // Este metodo Enum nos permite hacer una lista de constantes que son
        // los operadores que se utilizan en el algoritmo que evaluara el compilador.
        public enum OperadoresAritmeticos
        {
            Suma,
            Resta,
            Multiplicacion,
            Division,
            Incremental,
            Decremental
        }
        // Este metodo Enum nos permite hacer una lista de constantes que son los tipos de
        // operadores relacionales que se utilizan en el algoritmo que evaluara el compilador.
        public enum OperadoresRelacionales
        {
            Igualdad,
            Desigualdad,
            Mayor,
            MayorIgual,
            Menor,
            MenorIgual
        }
        // Este metodo Enum nos permite hacer una lista de constantes que son los operadores
        // logicos que se utilizan en el algoritmo que evaluara el compilador.
        public enum OperadoresLogicos
        {
            And,
            Or,
            Not
        }
        // Este metodo Enum nos permite hacer una lista de constantes que son los operadores de
        // asignacion que se utilizan en el algoritmo que evaluara el compilador.
        public enum OperadoresAsignacion
        {
            Igual,
            MasIgual,
            MenosIgual,
            MultiplicacionIgual,
            DivisionIgual
        }
        // Este metodo Enum nos permite hacer una lista de constantes que son los tipos de 
        // variables basicas que se utilizan en el algoritmo que evaluara el compilador.
        public enum TipoVariable
        {
            Char,
            Int,
            Float,
            Double,
            Void,
            String,
            Booleano
        }
        // Este metodo Enum nos permite hacer una lista de constantes que son palabras reservadas
        // o condiciones de evaluacion que se utilizan en el algoritmo que evaluara el compilador.
        public enum PalabrasReservadas
        {
            If,
            Else,
            Switch,
            Case,
            Default,
            Break,
            For,
            Return,
            Continue
        }

        public static string TipoVariablePatron()
        {
            string patron = "";
            foreach (string name in Enum.GetNames(typeof(TipoVariable)))
            {
                patron = patron + name.ToLower() + "|";
            }
            patron = patron.Remove(patron.Length - 1);
            return patron;
        }

        public static string TipoPalabraReservadaPatron()
        {
            string patron = "";
            foreach (string name in Enum.GetNames(typeof(PalabrasReservadas)))
            {
                patron = patron + name.ToLower() + "|";
            }
            patron = patron.Remove(patron.Length - 1);
            return patron;
        }
    }
}