using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesos
{
    public class Token
    {
        /// <summary>
        /// Token literal: int,definicion,+
        /// </summary>
        public string NombreToken { get; set; }

        /// <summary>
        /// Registro en la tabla de simbolos, tendrá valor si es un identificador
        /// si no tiene valor es porque es una palabra reservada o constante
        /// </summary>
        public int? IdTablaSimbolos { get; set; }

        /// <summary>
        /// Tendrá el tipo de elemento que estaremos tratando
        /// </summary>
        public Enums.TipoElemento TipoElemento { get; set; }


    }
}
