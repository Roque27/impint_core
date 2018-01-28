using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class CacheElemento
    {
        public string Key { get; set; }
        public string FromTabla { get; set; }
        public List<CacheColumna> Columnas { get; set; }

        public CacheElemento()
        {
            this.Columnas = new List<CacheColumna>();
        }
    }
}
