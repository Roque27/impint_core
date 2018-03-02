using AccesoDeDatos.Handlers;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;
using System.Linq;

namespace AccesoDeDatos
{
    public class QueryElementos
    {
        public List<DatoExtraccion> ObtenerListaElementos(List<ConsultaDinamica> queryes)
        {
            string ConnStr = QueryHandler.ConeccionBBDD;
            List<DatoExtraccion> datos = new List<DatoExtraccion>();

            List<String> lista = new List<String>();

            using (OracleConnection connection = new OracleConnection(ConnStr))
            {
                OracleCommand cmd = null;
                connection.Open();
                foreach(var q in queryes)
                {
                    DatoExtraccion Tabla = new DatoExtraccion();

                    cmd = new OracleCommand(q.Query, connection);
                    foreach (var p in q.Parametros.Keys)
                        cmd.Parameters.Add(new OracleParameter(p, q.Parametros[p]));

                    Tabla.Tabla = q.Tabla;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            foreach (var c in q.MeotodosColumnas)
                            {
                                if (Tabla.Columnas.Keys.Any( x => x.Equals(c.Key)))
                                    Tabla.Columnas[c.Key].Add(ReaderHandler.Read(reader, c.Key, c.Value));
                                else
                                    Tabla.Columnas.Add(c.Key, new List<string>() { ReaderHandler.Read(reader, c.Key, c.Value) });
                            }
                        }
                        reader.Close();
                    }

                    Tabla.Columnas = (new QueryTablas(Tabla)).DatosProcesados;

                    datos.Add(Tabla);
                }
            }
            return datos;
        }
    }
}
