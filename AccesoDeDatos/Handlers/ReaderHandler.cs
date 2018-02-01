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

        public static int ReadInt(this OracleDataReader reader, string column)
        {
            return Convert.ToInt32(reader[column]);
        }

        public static int ReadFullInt(this OracleDataReader reader, string column)
        {
            var value = reader[column];

            return DBNull.Value.Equals(value)
                       ? 0
                       : Convert.ToInt32(value);
        }

        public static string ReadString(this OracleDataReader reader, string column)
        {
            return reader[column].ToString();
        }

        public static string ReadFullString(this OracleDataReader reader, string column)
        {
            var value = reader[column];

            return DBNull.Value.Equals(value)
                       ? String.Empty
                       : (value).ToString().Trim();
        }

        public static string ReadDateString(this OracleDataReader reader, string column)
        {
            return Convert.ToDateTime(reader[column]).ToString("dd/mm/yyyy");
        }

        public static DateTime ReadDateTime(this OracleDataReader reader, string column)
        {
            return Convert.ToDateTime(reader[column]);
        }
    }
}
