using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;

namespace AccesoDeDatos
{
    public class QueryElementos
    {
        public List<DataTable> ObtenerListaElementos(Dictionary<string, Dictionary<string, string>> queryes)
        {
            string ConnStr = QueryHandler.ConeccionBBDD;
            List<DataTable> datos = null;

            using (OracleConnection connection = new OracleConnection(ConnStr))
            {
                OracleCommand cmd = null;
                connection.Open();
                foreach(var q in queryes)
                {
                    cmd = new OracleCommand(q.Key, connection);
                    foreach (string key in q.Value.Keys)
                        cmd.Parameters.Add(new OracleParameter(key, q.Value[key]));

                    //OracleDataAdapter sda = new OracleDataAdapter(cmd);
                    //DataTable dt = new DataTable();
                    //sda.Fill(dt);
                    //connection.Close();
                    //return dt;
                }
                //using (SqlCommand command1 = new SqlCommand(commandText1, connection))
                //{
                //}
                //using (SqlCommand command2 = new SqlCommand(commandText2, connection))
                //{
                //}
                // etc
            }

            return datos;
        }
    }
}
