﻿using System;
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
        }

        public void CompletarDatosGeograficos(List<Tuple<string, string, string>> notCodigos)
        {
            if (this.Ordenativos != null && this.Ordenativos.Count > 0)
            {
                foreach (Ordenativo o in Ordenativos)
                {
                    //personas.prs_numero

                    //contratos.srv_codigo
                    //contratos.cnt_numero

                    //contratos.srv_codigo
                    //contratos.cnt_numero
                }
            }
        }

        public void CompletarNotCodigos(List<Tuple<string, string, string>> notCodigos)
        {
            if(this.Ordenativos != null && this.Ordenativos.Count > 0)
            {
                foreach(Ordenativo o in Ordenativos)
                {
                    o.not_codigo = notCodigos.Where(n => n.Item1.Equals(o.tor_codigo) && n.Item2.Equals(o.datos_geograficos.cfc_codigo.Equals(n.Item2)))
                        .Select(n => n.Item3).FirstOrDefault();

                }
            }
        }
    }
}
