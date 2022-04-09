using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Modulo,
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
            Or,
            Not
        }

        public enum OperadoresAsignacion
        {
            Igual,
            MasIgual,
            MenosIgual,
            MultiplicacionIgual,
            DivisionIgual,
            ModuloIgual
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
            While,
            Do,
            Return,
            Continue
        }

        public enum PalabrasDefinicion
        {
            Auto,
            Signed,
            Const,
            Extern,
            Register,
            Unsigned
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

        public static string TipoPalabraDefinicionPatron()
        {
            string patron = "";
            foreach (string name in Enum.GetNames(typeof(PalabrasDefinicion)))
            {
                patron = patron + name.ToLower() + "|";
            }

            patron = patron.Remove(patron.Length - 1);

            return patron;
        }
    }
}