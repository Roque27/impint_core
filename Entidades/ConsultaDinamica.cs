using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class ConsultaDinamica
    {
        public string Tabla { get; set; }
        public string Query { get; set; }
        public Dictionary<string,string> Parametros { get; set; }
        public Dictionary<string, MetodoExtension> MeotodosColumnas { get; set; }
    }
}
