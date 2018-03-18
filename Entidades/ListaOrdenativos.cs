using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Entidades
{
    public class ListaOrdenativos
    {
        public List<Ordenativo> Ordenativos { get; set; }

        public ListaOrdenativos()
        {
            this.Ordenativos = new List<Ordenativo>();
        }

        public void CompletarDatosGeograficos(Dictionary<string, Direccion> direcciones)
        {
            if (this.Ordenativos != null && this.Ordenativos.Count > 0)
            {
                foreach (Ordenativo o in this.Ordenativos)
                {
                    o.datos_geograficos = direcciones[o.rowid];
                }
            }
        }

        public void CompletarNotCodigos(List<Tuple<string, string, string>> notCodigos)
        {
            if(this.Ordenativos != null && this.Ordenativos.Count > 0)
            {
                foreach(Ordenativo o in this.Ordenativos)
                {
                    o.not_codigo = notCodigos.Where(n => n.Item1.Equals(o.tor_codigo) && n.Item2.Equals(o.datos_geograficos.cfc_codigo.Equals(n.Item2)))
                        .Select(n => n.Item3).FirstOrDefault();
                }
            }
        }
    }
}
