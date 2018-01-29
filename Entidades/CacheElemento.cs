using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class CacheElemento
    {
        [JsonProperty("Key")]
        public string Key { get; set; }
        [JsonProperty("From")]
        public string From { get; set; }
        [JsonProperty("Where")]
        public string Where { get; set; }
        [JsonProperty("Columnas")]
        public List<CacheColumna> Columnas { get; set; }

        public CacheElemento()
        {
            this.Columnas = new List<CacheColumna>();
        }
    }
}
