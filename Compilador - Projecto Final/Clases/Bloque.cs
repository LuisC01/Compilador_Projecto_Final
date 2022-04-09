using System.Collections.Generic;
using System.Linq;

namespace Compilador___Projecto_Final
{
    public class Bloque
    {
        public Bloque()
        {
            this.BloquesInterno = new List<Bloque>();
            this.Lexemas = new List<Lexema>();
        }

        public List<Lexema> Lexemas { get; set; }

        public int Incia { get; set; }

        public int Finaliza { get; set; }

        public List<Bloque> BloquesInterno { get; set; }

        public Bloque BloquePadre { get; set; }

        public string Error { get; set; }

        public List<string> ErroresHijo()
        {
            if (BloquesInterno == null || BloquesInterno.Count == 0)
            {
                return new List<string>();
            }

            return BloquesInterno.Select(y => y.ErrorCompleto()).ToList();
        }

        public string ErrorCompleto()
        {
            if (string.IsNullOrEmpty(Error))
            {
                return null;
            }

            return Error + " ---> " + string.Join(" ", Lexemas.Select(y => y.Texto));
        }

        public void HacersePadre()
        {
            foreach (Bloque bloque in BloquesInterno)
            {
                bloque.BloquePadre = this;
                bloque.HacersePadre();
            }
        }

        public List<Bloque> BloquesPlanos()
        {
            List<Bloque> retorno = new List<Bloque>();
            if (BloquePadre == null)
            {
                retorno.Add(this);
            }
            
            if (BloquesInterno != null && BloquesInterno.Count > 0)
            {
                retorno.AddRange(BloquesInterno);
                retorno.AddRange(BloquesInterno.SelectMany(y => y.BloquesPlanos()));
            }
            return retorno;
        }

        public List<Bloque> GetBloquesHijos()
        {
            return BloquesInterno;
        }
    }
}
