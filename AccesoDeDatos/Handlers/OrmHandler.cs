using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;

namespace AccesoDeDatos.Handlers
{
    public class OrmHandler
    {
        //static string ConeccionBBDD = ConfigurationManager.ConnectionStrings["connStrExc"].ConnectionString;
        static string ConeccionBBDD = "Data Source=SICT2;User Id=lgas;Password=taxi; Integrated Security = no;";

        static public Proceso GetOrmProceso(string StrSql, Dictionary<string, object> Dic_Param)
        {
            string ConnStr = ConeccionBBDD;
            Proceso p = null;

            using (OracleConnection connection = new OracleConnection(ConnStr))
            {
                connection.Open();

                using (OracleCommand cmd = new OracleCommand(StrSql, connection))
                {
                    foreach (string key in Dic_Param.Keys)
                        cmd.Parameters.Add(new OracleParameter(key, Dic_Param[key]));

                    using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            p = new Proceso
                            {
                                Numero = Convert.ToInt32(reader["cpr_numero"]),
                                NroUsuario = Convert.ToInt32(reader["usr_numero"]),
                                TimCodigo = Convert.ToString(reader["tim_codigo"]).Trim(),
                                GeneraDocCorreo = reader.Read<string>("crr_genera_planilla", "0").Trim(),
                                ParametroDeVencimiento = Convert.ToInt32(reader["vencimiento"])
                            };
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return p;
        }
    }
}