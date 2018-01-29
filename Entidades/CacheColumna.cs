using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class CacheColumna
    {
        [JsonProperty("Columna")]
        public string Columna { get; set; }

        [JsonProperty("Expresion")]
        public string Expresion { get; set; }

        [JsonProperty("Metodo")]
        [JsonConverter(typeof(MetodoExtensionTypeConverter))]
        public MetodoExtension Metodo { get; set; }
    }
}