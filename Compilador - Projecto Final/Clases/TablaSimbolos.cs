using System.Collections.Generic;
using System.Linq;

namespace Compilador___Projecto_Final
{
    public class TablaSimbolos
    {
        //Constructor de la clase tabla de simbolos.
        public TablaSimbolos()
        {
            RegistrosTabla = new List<RegistroTabla>();
            Tokens = new List<Token>();
        }

        //Atributos de lista de los objetos tokens y registro de tablas con sus respectivos
        //getter y setters.
        public List<RegistroTabla> RegistrosTabla { get; set; }
        public List<Token> Tokens { get; set; }

        // Este metodo me retorna cual es el siguiente correlativo que debe tener el siguiente registro
        // a ingresar.
        public int SiguienteCorrelativo()
        {
            if (RegistrosTabla.Count == 0)
            {
                return 1;
            }
            else
            {
                return RegistrosTabla.Max(x => x.Codigo) + 1;
            }
        }

        // Este metodo nos permite evaluar los nombres de las expresiones ingresar los registros a la lista de registros de la tabla
        public void InsertarRegistro(RegistroTabla registro)
        {
            if (RegistrosTabla.Any(x => x.Nombre == registro.Nombre))
            {
                ActualizarValorRegistro(registro.Nombre, registro.Valor);
            }
            else
            {
                registro.Codigo = SiguienteCorrelativo();
                RegistrosTabla.Add(registro);
            }
        }

        // Este metodo tiene la funcion de actualizar el valor del registro si es necesario
        public void ActualizarValorRegistro(string nombre, string valor)
        {
            RegistrosTabla.First(x => x.Nombre == nombre).Valor = valor;
        }

        // Primera fase del manejo de tokens y creacion de la tabla de simbolos.
        public void ProcesarListadoLexemas(List<Lexema> listadoLexemas)
        {
            foreach (var lexema in listadoLexemas.Where(x => x.TipoElemento == Enums.TipoElemento.Variable))
            {
                Tokens.Add(new Token()
                {
                    IdTablaSimbolos = SiguienteCorrelativo(),
                    NombreToken = lexema.Texto,
                    TipoElemento = lexema.TipoElemento
                });

                var indiceActual = listadoLexemas.IndexOf(lexema);
                Enums.TipoVariable? tipoVariable = null;
                InsertarRegistro(new RegistroTabla { Nombre = lexema.Texto , TipoVariable = tipoVariable});
            }
        }

        public Enums.TipoVariable? TextoToTipo(string texto)
        {
            switch (texto)
            {
                case "int":
                    return Enums.TipoVariable.Int;
                case "char":
                    return Enums.TipoVariable.Char;
                case "float":
                    return Enums.TipoVariable.Float;
                case "double":
                    return Enums.TipoVariable.Double;
                case "void":
                    return Enums.TipoVariable.Void;
                case "string":
                    return Enums.TipoVariable.String;
                case "booleano":
                    return Enums.TipoVariable.Booleano;
            }
            return null;
        }
    }
}
