using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace AccesoDeDatos
{
    public class QueryProcesos : QueryHandler
    {
        public QueryProcesos()
        {

        }

        public Proceso IniciarNuevoProceso()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            string queryDB = "SELECT SYSDATE " +
                             "FROM DUAL ";

            DateTime dt = Convert.ToDateTime(QueryHandler.ExecuteScalar(queryDB, parameters));
            return dt;
        }
    }
}
