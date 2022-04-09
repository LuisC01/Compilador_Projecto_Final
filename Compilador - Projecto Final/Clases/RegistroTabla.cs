using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Procesos
{
    /// <summary>
    /// Objeto que ayudará a crear un registro en la tabla de simbolos, OJO que solo se crean
    /// registros para variables y no para palabra reservadas y demas
    /// </summary>
    public class RegistroTabla
    {

        public int Codigo { get; set; }
        /// <summary>
        /// Guardará el nombre de la variable para la cual estamo creando el regitro
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Indica el tipo de variable que es
        /// </summary>
        public Enums.TipoVariable? TipoVariable { get; set; }

        /// <summary>
        /// Me ayuda a saber que valor tiene en este momento una variable
        /// </summary>
        public string Valor { get; set; }

    }
}
