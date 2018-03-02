using Entidades;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Text;

namespace AccesoDeDatos.Handlers
{
    static public class ReaderHandler
    {
        public static string Read(OracleDataReader r, string col, MetodoExtension metodo)
        {
            string dato = null;

            switch (metodo)
            {
                case MetodoExtension.Read:
                    dato = r[col].ToString();
                    break;
                case MetodoExtension.ReadDateString:
                    dato = r.ReadDateTimeString(col, "dd/MM/yyyy");
                    break;
                //case MetodoExtension.ReadDateTime:
                //    dato = r.ReadDateTime(col);
                //    break;
                case MetodoExtension.ReadFullInt:
                    dato = r.ReadFullInt(col).ToString();
                    break;
                case MetodoExtension.ReadFullString:
                    dato = r.ReadFullString(col);
                    break;
                case MetodoExtension.ReadInt:
                    dato = r.ReadInt(col).ToString();
                    break;
                case MetodoExtension.ReadString:
                    dato = r.ReadString(col);
                    break;
            }
            return dato;
        }

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
            return reader[column].ToString().Trim();
        }

        public static string ReadFullString(this OracleDataReader reader, string column)
        {
            var value = reader[column];

            return DBNull.Value.Equals(value)
                       ? String.Empty
                       : (value).ToString().Trim();
        }

        public static DateTime ReadDateTime(this OracleDataReader reader, string column)
        {
            return Convert.ToDateTime(reader[column]);
        }

        public static string ReadDateTimeString(this OracleDataReader reader, string column, string formato)
        {
            return reader.ReadDateTime(column).ToString(formato);
        }
    }
}
