using System.Collections.Generic;
using System.Linq;

namespace Compilador___Projecto_Final
{
    public class TablaSimbolos
    {
        public TablaSimbolos()
        {
            RegistrosTabla = new List<RegistroTabla>();
            Tokens = new List<Token>();
        }

        public List<RegistroTabla> RegistrosTabla { get; set; }
        public List<Token> Tokens { get; set; }

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

        public void ActualizarValorRegistro(string nombre, string valor)
        {
            RegistrosTabla.First(x => x.Nombre == nombre).Valor = valor;
        }

        public bool VariableEstaDeclarada(string nombreVariable)
        {
            return RegistrosTabla.Any(x => x.Nombre == nombreVariable);
        }
        
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
