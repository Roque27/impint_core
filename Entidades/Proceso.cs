using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    class Proceso
    {
        int num_proceso { get; set; } //CargaProxNroProceso
        int usr_numero { get; set; } //SeleccionaPersona
        string tim_codigo { get; set; } //SeleccionaImpresora
        string crr_genera_planilla { get; set; } //CargaPlantillas
        int parametro_vencimiento { get; set; } //SeleccionaParametroDeVencimiento
    }
}
