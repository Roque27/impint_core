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
        public List<DataTable> ObtenerListaElementos(List<ConsultaDinamica> queryes)
        {
            string ConnStr = QueryHandler.ConeccionBBDD;
            List<DataTable> datos = null;

            using (OracleConnection connection = new OracleConnection(ConnStr))
            {
                OracleCommand cmd = null;
                connection.Open();
                foreach(var q in queryes)
                {
                    cmd = new OracleCommand(q.query, connection);
                    foreach (string p in q.parametros)
                        cmd.Parameters.Add(new OracleParameter());


                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            p = new Proceso
                            {
                                Numero = Convert.ToInt32(reader["cpr_numero"]),
                                NroUsuario = Convert.ToInt32(reader["usr_numero"]),
                                TimCodigo = Convert.ToString(reader["tim_codigo"]).Trim(),
                                ParametroDeVencimiento = Convert.ToInt32(reader["vencimiento"])
                            };
                        }
                        reader.Close();
                    }
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
