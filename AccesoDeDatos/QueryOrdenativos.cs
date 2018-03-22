using AccesoDeDatos.Handlers;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AccesoDeDatos
{
    public class QueryOrdenativos
    {
        public QueryOrdenativos()
        {
            
        }

        public List<Ordenativo> ObtenerOrdenativoParaProcesar(string tipoAviso, string usuario, string csf, string sec, int minOrdenativo, int maxOrdenativo, string tipoCorreo, string codigoCorreo)
        {
            string queryDB = string.Empty;
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            queryDB = "SELECT o.trt_numero"
                    + " ,o.ord_numero"
                    + " ,o.srv_codigo"
                    + " ,o.cnt_numero"
                    + " ,o.tor_codigo"
                    + " ,o.ord_fecha_generacion"
                    + " ,u.scf_codigo"
                    + " ,o.sec_codigo_origen"
                    + " ,t.tor_grupo"
                    + " ,t.tor_descripcion"
                    + " ,o.prs_numero"
                    + " ,o.rowid"
                    + " ,o.crr_tipo"
                    + " ,o.crr_codigo"
                    + " ,NVL((MAX(cad_numero) OVER(PARTITION BY cd.cad_tipo)) + 1, o.ord_numero || '0') AS numero"
                    + " FROM ordenativos o"
                    + " INNER JOIN tipos_ordenativo t ON o.tor_codigo = t.tor_codigo"
                    + " LEFT JOIN cancel_deuda cd ON (cd.aviso_nro = o.ord_numero AND cd.cad_tipo = o.tor_codigo)"
                    + " CROSS JOIN usuarios u"
                    + " WHERE t.tor_codigo = :v_tor_codigo"
                    + " AND u.usr_codigo = :v_usr_codigo"
                    + " AND o.scf_codigo_origen = :v_scf_codigo"
                    + " AND o.sec_codigo_origen = :v_sec_codigo"
                    + " AND o.ord_numero BETWEEN :v_min_ord_num AND :v_max_ord_num"
                    + " AND o.crr_tipo = :v_crr_tipo"
                    + " AND o.crr_codigo = :v_crr_codigo"
                    + " AND o.ord_situacion = 'P'"
                    + " AND o.ord_estado = 'D'"
                    + " ORDER BY o.ord_numero";

            parameters.Add("v_tor_codigo", tipoAviso);
            parameters.Add("v_usr_codigo", usuario);
            parameters.Add("v_scf_codigo", csf);
            parameters.Add("v_sec_codigo", sec);
            parameters.Add("v_min_ord_num", minOrdenativo);
            parameters.Add("v_max_ord_num", maxOrdenativo);
            parameters.Add("v_crr_tipo", tipoCorreo);
            parameters.Add("v_crr_codigo", codigoCorreo);

            ListaOrdenativos lista = new ListaOrdenativos(OrmHandler.GetOrmOrdenativosBase(queryDB, parameters));

            //lista.CompletarDatosGeograficos(ObtenerDatosGeograficos(lista.ObtenerLista()));

            parameters.Clear();
            queryDB = "";

            parameters.Add("", string.Empty);

            //lista.CompletarNotCodigos(OrmHandler.GetOrmOrdenativosNotCodigo(queryDB, parameters));

            return lista.ObtenerLista();
        }

        public DateTime PruebaConeccion()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            string queryDB = "SELECT SYSDATE " +
                             "FROM DUAL ";

            DateTime dt = Convert.ToDateTime(QueryHandler.ExecuteScalar(queryDB, parameters));
            return dt;
        }

        public DataTable PruebaParametros(string id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("v_srv_cod", id);

            string queryDB = "SELECT * "
                            +"FROM SERVICIOS "
                            +"WHERE SRV_CODIGO = :v_srv_cod ";

            DataTable tabla = new DataTable();
            tabla.Columns.Add("SRV_CODIGO");
            tabla.Columns.Add("SCF_CODIGO");
            tabla.Columns.Add("AGE_CODIGO");
            tabla.Columns.Add("AGF_CODIGO");
            tabla = QueryHandler.ExecuteQuery(queryDB, parameters);

            return tabla;
        }

        public Dictionary<string, Direccion> ObtenerDatosGeograficos(List<Ordenativo> lista)
        {
            string queryDB = string.Empty;
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            queryDB = "";

            //SELECT personas.prs_numero
            //	,substr(personas.prs_razon_social, 1, 25) AS prs_razon_social
            //    , nvl(personas.prs_direccion, ' ') AS prs_direccion
            //     , personas.cfc_codigo
            //	,COALESCE(substr(calles.cll_nombre, 1, 18), '0') AS cll_nombre
            //    , substr(nvl(personas.prs_nro, '    '), 1, 4) AS nro
            //     , NULL AS bis
            //      , substr(nvl(personas.prs_piso, '  '), 1, 2) AS piso
            //       , substr(nvl(personas.prs_depto, '   '), 1, 3) AS depto
            //        , nvl(personas.prs_torre, ' ') AS torre
            //         , nvl(personas.prs_c_postal, ' ') AS c_postal
            //          , nvl(areas_geograficas.agf_nombre, ' ') AS agf_nombre
            //           , NULL AS cnt_direccion_pago
            //          , '@rowid' AS rowid
            //FROM areas_geograficas
            //INNER JOIN personas ON areas_geograficas.agf_codigo = personas.agf_codigo
            //INNER JOIN calles ON calles.cll_codigo = personas.cll_codigo
            //
            //    AND calles.agf_codigo = personas.agf_codigo
            //WHERE personas.prs_numero = '@'
            //
            //
            //
            //SELECT personas.prs_numero
            //	,substr(personas.prs_razon_social, 1, 25) AS prs_razon_social
            //    , nvl(personas.prs_direccion, ' ') AS prs_direccion
            //     , personas.cfc_codigo
            //	,COALESCE(substr(calles.cll_nombre, 1, 18), '0') AS cll_nombre
            //    , COALESCE(substr(contratos.cnt_nro_pago, 1, 4), '0') AS nro
            //     , COALESCE(contratos.cnt_bis, '0') AS bis
            //      , COALESCE(substr(contratos.cnt_piso_pago, 1, 2), '0') AS piso
            //       , COALESCE(substr(contratos.cnt_depto_pago, 1, 3), '0') AS depto
            //        , NULL AS torre
            //         , COALESCE(nvl(contratos.cnt_c_postal_pago, ' '), '0') AS c_postal
            //          , nvl(areas_geograficas.agf_nombre, ' ') AS agf_nombre
            //           , NULL AS cnt_direccion_pago
            //          , '@rowid' AS rowid
            //FROM areas_geograficas
            //INNER JOIN contratos ON areas_geograficas.agf_codigo = contratos.agf_codigo
            //INNER JOIN personas ON personas.prs_numero = contratos.prs_numero
            //INNER JOIN calles ON calles.agf_codigo = contratos.agf_codigo
            //
            //    AND calles.cll_codigo = contratos.cll_codigo
            //WHERE contratos.srv_codigo = '@'
            //
            //    AND contratos.cnt_numero = '@'
            //
            //
            //
            //
            //SELECT personas.prs_numero
            //	,substr(personas.prs_razon_social, 1, 25) AS prs_razon_social
            //    , nvl(personas.prs_direccion, ' ') AS prs_direccion
            //     , personas.cfc_codigo
            //	,NULL AS cll_nombre
            //	,NULL AS nro
            //	,NULL AS bis
            //	,NULL AS piso
            //	,NULL AS depto
            //	,NULL AS torre
            //	,NULL AS c_postal
            //	,NULL AS agf_nombre
            //	,COALESCE(substr(nvl(regexp_replace(contratos.cnt_direccion_pago, '[[:space:]]+', chr(32)), ' '), 1, 27), '0') AS cnt_direccion_pago
            //          , '@rowid' AS rowid
            //FROM contratos
            //INNER JOIN personas ON personas.prs_numero = contratos.prs_numero
            //WHERE contratos.srv_codigo = '@'
            //
            //    AND contratos.cnt_numero = '@'

            return OrmHandler.GetOrmOrdenativosDatosGeograficos(queryDB, parameters);
        }
    }
}
