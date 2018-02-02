using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class DatoExtraccion
    {
        public string Tabla { get; set; }
        public Dictionary<string, List<string>> Columnas { get; set; }
        public DatoExtraccion Detalle { get; set; }

        public DatoExtraccion()
        {
            this.Columnas = new Dictionary<string, List<string>>();
        }

        public void AisgnarDetalle(DatoExtraccion _detalle)
        {
            this.Detalle = _detalle;
        }
    }
}
