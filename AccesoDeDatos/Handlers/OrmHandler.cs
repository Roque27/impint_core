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
                                trt_numero = Convert.ToInt32(reader["trt_numero"]),
                                ord_numero = Convert.ToInt32(reader["ord_numero"]),
                                srv_codigo = Convert.ToInt32(reader["srv_codigo"]),
                                cnt_numero = Convert.ToInt32(reader["cnt_numero"]),
                                tor_codigo = Convert.ToString(reader["tor_codigo"]),
                                ord_fecha_generacion = reader.ReadDateTimeString("ord_fecha_generacion", "dd/mm/yyyy"),
                                scf_codigo = Convert.ToInt32(reader["scf_codigo"]),
                                sec_codigo_origen = reader.ReadFullInt("sec_codigo_origen").ToString(),
                                tor_grupo = reader.ReadFullInt("tor_grupo").ToString(),
                                tor_descripcion = Convert.ToString(reader["tor_descripcion"]).Trim(),
                                prs_numero = reader.ReadFullInt("prs_numero"),
                                rowid = Convert.ToString(reader["rowid"]),
                                crr_tipo = Convert.ToString(reader["crr_tipo"]),
                                crr_codigo = Convert.ToString(reader["crr_codigo"]),
                                nro_aviso = Convert.ToString(reader["nro_aviso"]),
                                tipoDireccion = (reader["srv_codigo"] != DBNull.Value? TipoDireccion.ConContrato : TipoDireccion.ConContrato)
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

        static public List<Direccion> GetOrmOrdenativosDatosGeograficos(string StrSql, Dictionary<string, object> Dic_Param)
        {
            string ConnStr = ConeccionBBDD;
            List<Direccion> lista = new List<Direccion>();

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
                            lista.Add(new Direccion {
                                prs_numero = Convert.ToInt32(reader["prs_numero"]),
                                prs_razon_social = Convert.ToString(reader["prs_razon_social"]).Trim(),
                                prs_direccion = Convert.ToString(reader["prs_direccion"]).Trim(),
                                cfc_codigo = Convert.ToString(reader["cfc_codigo"]).Trim(),
                                calle_nombre = Convert.ToString(reader["cll_nombre"]).Trim(),
                                calle_numero = Convert.ToString(reader["nro"]).Trim(),
                                calle_bis = Convert.ToString(reader["bis"]).Trim(),
                                piso = Convert.ToString(reader["piso"]).Trim(),
                                departamento = Convert.ToString(reader["depto"]).Trim(),
                                torre = Convert.ToString(reader["torre"]).Trim(),
                                cod_postal = Convert.ToString(reader["c_postal"]),
                                agf_nombre = Convert.ToString(reader["agf_nombre"]).Trim(),
                                direccion_completa = Convert.ToString(reader["cnt_direccion_pago"]).Trim(),
                                rowid = Convert.ToString(reader["rowid"])
                            });
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