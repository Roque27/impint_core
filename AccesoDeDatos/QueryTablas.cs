using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDeDatos
{
    public class QueryTablas
    {
        public Dictionary<string, List<string>> DatosProcesados { get; private set; }

        public QueryTablas(DatoExtraccion datos)
        {
            switch(datos.Tabla)
            {
                case "Personas":
                    this.DatosProcesados = Personas(datos.);
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
    }
}
