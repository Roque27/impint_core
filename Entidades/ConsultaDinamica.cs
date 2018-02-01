using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class ConsultaDinamica
    {
        public string query { get; set; }
        public Dictionary<string,string> parametros { get; set; }
        public Dictionary<string, MetodoExtension> meotodosColumnas { get; set; }
    }
}
