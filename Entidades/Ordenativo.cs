using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Ordenativo
    {
        public string rowid { get; set; }
        public int trt_numero { get; set; }
        public int ord_numero { get; set; }
        public int srv_codigo { get; set; }
        public int cnt_numero { get; set; }
        public string tor_codigo { get; set; }
        public DateTime ord_fecha_generacion { get; set; }
        public int scf_codigo { get; set; }
        public string sec_codigo_origen { get; set; }
        public string tor_grupo { get; set; }
        public string tor_descripcion { get; set; }
        public int prs_numero { get; set; }
        public string crr_tipo { get; set; }
        public string crr_codigo { get; set; }
        public string nro_aviso { get; set; } //SeleccionarNroAviso

        public string not_codigo { get; set; } //ObtenerNotCodigo

        public TipoDireccion tipoDireccion { get; set; }
        public Direccion datos_geograficos { get; set; }

        public List<Elemento> listaColumnas{ get; set; }

        public Ordenativo()
        {
            this.datos_geograficos = new Direccion();
            this.listaColumnas = new List<Elemento>();
        }
    }
}
