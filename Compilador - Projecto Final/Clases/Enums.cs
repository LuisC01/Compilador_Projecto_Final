using System;

namespace Compilador___Projecto_Final
{
    public static class Enums
    {
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

        public enum OperadoresAritmeticos
        {
            Suma,
            Resta,
            Multiplicacion,
            Division,
            Incremental,
            Decremental
        }

        public enum OperadoresRelacionales
        {
            Igualdad,
            Desigualdad,
            Mayor,
            MayorIgual,
            Menor,
            MenorIgual
        }

        public enum OperadoresLogicos
        {
            And,
            Or
        }

        public enum OperadoresAsignacion
        {
            Igual,
            MasIgual,
            MenosIgual,
            MultiplicacionIgual,
            DivisionIgual
        }

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