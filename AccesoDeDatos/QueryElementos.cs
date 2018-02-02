using AccesoDeDatos.Handlers;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;

namespace AccesoDeDatos
{
    public class QueryElementos
    {
        public List<DatoExtraccion> ObtenerListaElementos(List<ConsultaDinamica> queryes)
        {
            string ConnStr = QueryHandler.ConeccionBBDD;
            List<DatoExtraccion> datos = new List<DatoExtraccion>();

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
                            foreach(var c in q.MeotodosColumnas)
                                Tabla.Columnas.Add(c.Key, OrmHandler.Read(reader, c.Key, c.Value));
                        }
                        reader.Close();
                    }
                    datos.Add(Tabla);
                }
            }
            return datos;
        }
    }
}
