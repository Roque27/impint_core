using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDeDatos
{
    public class QueryOrdenativos
    {
        public QueryOrdenativos()
        {
            
        }

        public List<Ordenativo> ObtenerOrdenativoParaProcesar()
        {
            List<Ordenativo> lista = new List<Ordenativo>();

            //SELECT o.trt_numero
            //	,o.ord_numero
            //	,o.srv_codigo AS SRV_CODIGO
            //	,o.cnt_numero
            //	,nvl(o.tor_codigo, '') AS TOR_CODIGO
            //    , to_char(o.ord_fecha_generacion, 'dd/mm/yyyy') AS ORD_FECHA_GENERACION
            //     , u.scf_codigo
            //	,COALESCE(o.sec_codigo_origen, '0') AS SEC_CODIGO_ORIGEN
            //    , COALESCE(t.tor_grupo, '0') AS TOR_GRUPO
            //     , t.tor_descripcion
            //	,COALESCE(o.prs_numero, 0) AS PRS_NUMERO
            //    , o.rowid
            //	,o.crr_tipo
            //	,o.crr_codigo
            //	,NVL((MAX(cad_numero) OVER(PARTITION BY cd.cad_tipo)) + 1, o.ord_numero || '0') AS numero
            //FROM ordenativos o
            //INNER JOIN tipos_ordenativo t ON o.tor_codigo = t.tor_codigo
            //LEFT JOIN cancel_deuda cd 
            //    ON cd.aviso_nro = o.ord_numero
            //    AND cd.cad_tipo = o.tor_codigo
            //CROSS JOIN usuarios u
            //WHERE t.tor_codigo = '@'
            //  AND u.usr_codigo = '@'
            //  AND o.scf_codigo_origen = '@'
            //  AND o.sec_codigo_origen = '@'
            //  AND o.ord_numero BETWEEN '@' AND '@'
            //  AND o.crr_tipo = '@'
            //  AND o.crr_codigo = '@'
            //  AND o.ord_situacion = 'P'
            //  AND o.ord_estado = 'D'
            //ORDER BY o.ord_numero

            return lista;
        }

        public DateTime PruebaConeccion()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            string queryDB = "SELECT SYSDATE " +
                             "FROM DUAL ";

            DateTime dt = Convert.ToDateTime(QueryHandler.ExecuteScalar(queryDB, parameters));
            return dt;
        }

        public void ObtenerDatosGeograficos()
        {
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
            //FROM contratos
            //INNER JOIN personas ON personas.prs_numero = contratos.prs_numero
            //WHERE contratos.srv_codigo = '@'
            //
            //    AND contratos.cnt_numero = '@'

            return;
        }
    }
}
