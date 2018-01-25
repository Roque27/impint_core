using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Proceso
    {
        public int Numero { get; set; } //CargaProxNroProceso
        public int NroUsuario { get; set; } //SeleccionaPersona
        public string TimCodigo { get; set; } //SeleccionaImpresora
        public string GeneraDocCorreo { get; set; } //CargaPlantillas
        public int ParametroDeVencimiento { get; set; } //SeleccionaParametroDeVencimiento
    }
}
