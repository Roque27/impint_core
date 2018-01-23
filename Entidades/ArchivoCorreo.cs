using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class ArchivoCorreo
    {
        string ord_numero { get; set; }
        string scf_codigo { get; set; }
        string cpr_numero { get; set; }
        string importe_aviso { get; set; }
        string anio { get; set; }
        string mes { get; set; }
        string dia { get; set; }
        string razon_social { get; set; }
        string nombre_completo { get; set; }

        string calle_persona { get; set; }
        string calle_numero_persona { get; set; }
        string piso_persona { get; set; }
        string departamento_persona { get; set; }
        string cod_postal_persona { get; set; }
        string localidad_persona { get; set; }
         
        string calle_pago { get; set; }
        string calle_numero_pago { get; set; }
        string piso_pago { get; set; }
        string departamento_pago { get; set; }
        string cod_postal_pago { get; set; }
        string localidad_pago { get; set; }

        string tipo_correo { get; set; }
        string correo { get; set; }
        string cantidad_facturas { get; set; }
    }
}
