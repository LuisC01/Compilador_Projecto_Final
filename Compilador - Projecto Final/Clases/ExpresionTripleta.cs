namespace Compilador___Projecto_Final
{
    public class ExpresionTripleta
    {
        public int Codigo { get; set; }
        public Tripleta TripletaInicial { get; set; }
        public Lexema Operador { get; set; }
        public Lexema PrimerLexema { get; set; }
        public Lexema SegundoLexema { get; set; }
        public Tripleta PrimerTripleta { get; set; }
        public Tripleta SegundaTripleta { get; set; }
        public string TextoMandatorio { get; set; }
    }
}
