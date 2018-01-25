using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Text;

namespace AccesoDeDatos.Handlers
{
    static public class ReaderHandler
    {
        public static T Read<T>(this OracleDataReader reader, string column, T defaultValue = default(T))
        {
            var value = reader[column];

            return (T)((DBNull.Value.Equals(value))
                       ? defaultValue
                       : Convert.ChangeType(value, typeof(T)));
        }
    }
}
