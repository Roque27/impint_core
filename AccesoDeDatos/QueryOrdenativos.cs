﻿using Entidades;
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
    }
}
