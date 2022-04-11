namespace Compilador___Projecto_Final
{
    public class Token
    {
        // Atibuto que obtendra el token, digase tipo de variable, definicion de expresion, etc
        public string NombreToken { get; set; }

        // Registro en la tabla de simbolos, tendrá valor si es un identificador
        // si no tiene valor es porque es una palabra reservada o constante definida.
        public int? IdTablaSimbolos { get; set; }

        //Tendrá el tipo de elemento que estaremos tratando.
        public Enums.TipoElemento TipoElemento { get; set; }
    }
}
