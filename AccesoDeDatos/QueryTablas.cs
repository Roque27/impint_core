using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDeDatos
{
    public class QueryTablas : IDisposable
    {
        public Dictionary<string, List<string>> DatosProcesados { get; private set; }

        public QueryTablas(DatoExtraccion datos)
        {
            switch(datos.Tabla)
            {
                case "Personas":
                    this.DatosProcesados = Personas(datos.Columnas);
                    break;
                case "Contratos":
                    this.DatosProcesados = Contratos(datos.Columnas);
                    break;
                case "Servicios":
                    this.DatosProcesados = Servicios(datos.Columnas);
                    break;
                case "Lecturas":
                    this.DatosProcesados = Lecturas(datos.Columnas);
                    break;
                case "Ordenativos":
                    this.DatosProcesados = Ordenativos(datos.Columnas);
                    break;
                case "Potencias":
                    this.DatosProcesados = Potencias(datos.Columnas);
                    break;
                case "StockEquipos":
                    this.DatosProcesados = StockEquipos(datos.Columnas);
                    break;
                case "Sucursales":
                    this.DatosProcesados = Sucursales(datos.Columnas);
                    break;
                case "Bancos":
                    this.DatosProcesados = Bancos(datos.Columnas);
                    break;
                case "Cargos":
                    this.DatosProcesados = Cargos(datos.Columnas);
                    break;
                case "TiposIVA":
                    this.DatosProcesados = TiposIVA(datos.Columnas);
                    break;
                case "Tarifas":
                    this.DatosProcesados = Tarifas(datos.Columnas);
                    break;
                case "Documentos":
                    this.DatosProcesados = Documentos(datos.Columnas);
                    break;
                case "TotalesTramites":
                    this.DatosProcesados = TotalesTramites(datos.Columnas);
                    break;
                case "Usuarios":
                    this.DatosProcesados = Usuarios(datos.Columnas);
                    break;
                case "PrsNumOri":
                    this.DatosProcesados = PrsNumOri(datos.Columnas);
                    break;
                default:
                    this.DatosProcesados = datos.Columnas;
                    break;
            }
        }

        private Dictionary<string, List<string>> Personas(Dictionary<string, List<string>> datos)
        {
            return datos;
        }

        private Dictionary<string, List<string>> Contratos(Dictionary<string, List<string>> datos)
        {
            return datos;
        }

        private Dictionary<string, List<string>> Servicios(Dictionary<string, List<string>> datos)
        {
            return datos;
        }

        private Dictionary<string, List<string>> Lecturas(Dictionary<string, List<string>> datos)
        {
            return datos;
        }

        private Dictionary<string, List<string>> Ordenativos(Dictionary<string, List<string>> datos)
        {
            return datos;
        }

        private Dictionary<string, List<string>> Potencias(Dictionary<string, List<string>> datos)
        {
            return datos;
        }

        private Dictionary<string, List<string>> StockEquipos(Dictionary<string, List<string>> datos)
        {
            return datos;
        }

        private Dictionary<string, List<string>> Sucursales(Dictionary<string, List<string>> datos)
        {
            return datos;
        }

        private Dictionary<string, List<string>> Bancos(Dictionary<string, List<string>> datos)
        {
            return datos;
        }

        private Dictionary<string, List<string>> Cargos(Dictionary<string, List<string>> datos)
        {
            return datos;
        }

        private Dictionary<string, List<string>> TiposIVA(Dictionary<string, List<string>> datos)
        {
            return datos;
        }

        private Dictionary<string, List<string>> Tarifas(Dictionary<string, List<string>> datos)
        {
            return datos;
        }

        private Dictionary<string, List<string>> Documentos(Dictionary<string, List<string>> datos)
        {
            return datos;
        }

        private Dictionary<string, List<string>> TotalesTramites(Dictionary<string, List<string>> datos)
        {
            return datos;
        }

        private Dictionary<string, List<string>> Usuarios(Dictionary<string, List<string>> datos)
        {
            return datos;
        }

        private Dictionary<string, List<string>> PrsNumOri(Dictionary<string, List<string>> datos)
        {
            return datos;
        }

        public void Dispose()
        {
            this.DatosProcesados = null;
            GC.SuppressFinalize(this);
        }

        ~QueryTablas()
        {
            this.Dispose();
        }
    }
}
