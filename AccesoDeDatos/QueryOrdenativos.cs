using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDeDatos
{
    public class QueryOrdenativos
    {
        public QueryOrdenativos()
        {
            
        }

        public DateTime PruebaConeccion()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            string queryDB = "SELECT SYSDATE " +
                             "FROM DUAL ";

            DateTime dt = Convert.ToDateTime(QueryHandler.ExecuteScalar(queryDB, parameters));
            return dt;
        }
    }
}
