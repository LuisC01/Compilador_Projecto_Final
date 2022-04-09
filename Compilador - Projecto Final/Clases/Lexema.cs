namespace Compilador___Projecto_Final
{
    public class Lexema
    {
        public Lexema()
        {
            this.Error = false;
        }

        public string Texto { get; set; }

        public Enums.TipoElemento TipoElemento { get; set; }

        public bool Error { get; set; }

        public string MensajeError { get; set; }

    }
}
