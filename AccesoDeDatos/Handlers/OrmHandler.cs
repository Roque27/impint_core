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

        static public List<Ordenativo> GetOrmOrdenativosBase(string StrSql, Dictionary<string, object> Dic_Param)
        {
            string ConnStr = ConeccionBBDD;
            List<Ordenativo> lista = new List<Ordenativo>();

            using (OracleConnection connection = new OracleConnection(ConnStr))
            {
                connection.Open();

                using (OracleCommand cmd = new OracleCommand(StrSql, connection))
                {
                    foreach (string key in Dic_Param.Keys)
                        cmd.Parameters.Add(new OracleParameter(key, Dic_Param[key]));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Ordenativo
                            {
                                trt_numero = Convert.ToInt32(reader["cpr_numero"]),
                                ord_numero = Convert.ToInt32(reader["cpr_numero"]),
                                srv_codigo = Convert.ToInt32(reader["cpr_numero"]),
                                cnt_numero = Convert.ToInt32(reader["cpr_numero"]),
                                tor_codigo = Convert.ToString(reader["tim_codigo"]),
                                ord_fecha_generacion = Convert.ToDateTime(reader["cpr_numero"]),
                                scf_codigo = Convert.ToInt32(reader["cpr_numero"]),
                                sec_codigo_origen = Convert.ToString(reader["tim_codigo"]),
                                tor_grupo = Convert.ToString(reader["tim_codigo"]),
                                tor_descripcion = Convert.ToString(reader["tim_codigo"]).Trim(),
                                prs_numero = Convert.ToInt32(reader["cpr_numero"]),
                                rowid = Convert.ToString(reader["tim_codigo"]),
                                crr_tipo = Convert.ToString(reader["tim_codigo"]),
                                crr_codigo = Convert.ToString(reader["tim_codigo"]),
                                nro_aviso = Convert.ToString(reader["numero"])
                            });
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return lista;
        }

        static public List<Tuple<string, string, string>> GetOrmOrdenativosNotCodigo(string StrSql, Dictionary<string, object> Dic_Param)
        {
            string ConnStr = ConeccionBBDD;
            List<Tuple<string, string, string>> lista = new List<Tuple<string, string, string>>();

            using (OracleConnection connection = new OracleConnection(ConnStr))
            {
                connection.Open();

                using (OracleCommand cmd = new OracleCommand(StrSql, connection))
                {
                    foreach (string key in Dic_Param.Keys)
                        cmd.Parameters.Add(new OracleParameter(key, Dic_Param[key]));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(Tuple.Create(Convert.ToString(reader["tor_codigo"]), Convert.ToString(reader["cfc_codigo"]), Convert.ToString(reader["not_codigo"])));
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return lista;
        }

        static public List<Tuple<string, string, string>> GetOrmOrdenativosDatosGeograficos(string StrSql, Dictionary<string, object> Dic_Param)
        {
            string ConnStr = ConeccionBBDD;
            List<Tuple<string, string, string>> lista = new List<Tuple<string, string, string>>();

            using (OracleConnection connection = new OracleConnection(ConnStr))
            {
                connection.Open();

                using (OracleCommand cmd = new OracleCommand(StrSql, connection))
                {
                    foreach (string key in Dic_Param.Keys)
                        cmd.Parameters.Add(new OracleParameter(key, Dic_Param[key]));

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(Tuple.Create(Convert.ToString(reader["tor_codigo"]), Convert.ToString(reader["cfc_codigo"]), Convert.ToString(reader["not_codigo"])));
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return lista;
        }
    }
}