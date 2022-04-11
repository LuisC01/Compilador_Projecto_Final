namespace Compilador___Projecto_Final
{
    public class Lexema
    {
        //Constructor de la clase lexer que identifica la operacion o la interpreta
        public Lexema()
        {
            this.Error = false;
        }
        //Atributo tipo string que Indica el texto del lexema: digase las variables el valor del numero etc
        public string Texto { get; set; }
        // Atributo tipo Enums que Indica el tipo de elemento utilizado
        public Enums.TipoElemento TipoElemento { get; set; }
        // atributo booleano que identifica los errores.
        public bool Error { get; set; }
        // Atributo tipo string que brinda el mensaje de error.
        public string MensajeError { get; set; }

    }
}
