using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Ordenativo
    {
        int trt_numero { get; set; }
        int ord_numero { get; set; }
        int srv_codigo { get; set; }
        short o.cnt_numero { get; set; }
        string tor_codigo { get; set; }
        DateTime ord_fecha_generacion { get; set; }
        short u.scf_codigo { get; set; }
        string sec_codigo_origen { get; set; }
        string tor_grupo { get; set; }
        string tor_descripcion { get; set; }
        int prs_numero { get; set; }
        Direccion datos_geograficos { get; set; }
        string rowid { get; set; }
        string crr_tipo { get; set; }
        string crr_codigo { get; set; }

        int not_codigo { get; set; } //ObtenerNotCodigo
        int nro_aviso { get; set; } //SeleccionarNroAviso

        List<Elemento> listaColumnas{ get; set; }

        public Ordenativo()
        {
            this.datos_geograficos = new Direccion();
            this.listaColumnas = new List<Elemento>();
        }
    }
}
