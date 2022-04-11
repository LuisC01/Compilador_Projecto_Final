namespace Compilador___Projecto_Final
{
    // Esta clase nos permititra crear un registro en la tabla de simbolos,
    // solo se crean registros para variables y no para palabra reservadas.
    public class RegistroTabla
    {
        // Atributo de codigo que guardara el tipo de variable para lo que se esta creando el registro.
        public int Codigo { get; set; }

        // Atributo que Guardará el nombre de la variable para la cual estamo creando el regitro.
        public string Nombre { get; set; }

        // Atributo Indica el tipo de variable que es.
        public Enums.TipoVariable? TipoVariable { get; set; }

        // Atributo Me ayuda a saber que valor tiene en este momento una variable.
        public string Valor { get; set; }
    }
}