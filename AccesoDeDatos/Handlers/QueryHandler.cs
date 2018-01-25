using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data;

namespace AccesoDeDatos
{
    public class QueryHandler
    {
        //static string ConeccionBBDD = ConfigurationManager.ConnectionStrings["connStrExc"].ConnectionString;
        static string ConeccionBBDD = "Data Source=SICT2;User Id=lgas;Password=taxi; Integrated Security = no;";

        static public object ExecuteScalar(string StrSql, Dictionary<string, object> Dic_Param)
        {
            string ConnStr = ConeccionBBDD;
            using (OracleConnection connection = new OracleConnection(ConnStr))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand(StrSql, connection);
                foreach (string key in Dic_Param.Keys)
                    cmd.Parameters.Add(new OracleParameter(key, Dic_Param[key]));

                object Resultado = cmd.ExecuteScalar();
                connection.Close();
                return Resultado;
            }
        }

        static public void ExecuteNonQuery(string StrSql, Dictionary<string, object> Dic_Param)
        {
            string ConnStr = ConeccionBBDD;
            using (OracleConnection connection = new OracleConnection(ConnStr))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand(StrSql, connection);

                foreach (string key in Dic_Param.Keys)
                    cmd.Parameters.Add(new OracleParameter(key, Dic_Param[key]));

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        static public DataTable ExecuteQuery(string StrSql, Dictionary<string, object> Dic_Param)
        {
            string ConnStr = ConeccionBBDD;
            using (OracleConnection connection = new OracleConnection(ConnStr))
            {
                connection.Open();
                OracleCommand cmd = new OracleCommand(StrSql, connection);

                foreach (string key in Dic_Param.Keys)
                    cmd.Parameters.Add(new OracleParameter(key, Dic_Param[key]));

                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                connection.Close();
                return dt;
            }
        }
    }
}
