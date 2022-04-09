namespace Compilador___Projecto_Final
{
    public class Tripleta
    {
        public int Codigo { get; set; }
        public Lexema Operador { get; set; }
        public Lexema PrimerOperando { get; set; }
        public Lexema SegundoOperando { get; set; }
        public Bloque Bloque { get; set; }
    }
}