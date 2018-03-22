using Core;
using System;
using System.Data;

namespace Launcher
{
    class Impint
    {
        static void Main(string[] args)
        {
            Startup startup = new Startup();

            ControladorOrdenativos c = new ControladorOrdenativos();

            DataTable dt = c.Test() as DataTable;

            foreach (DataRow r in dt.Rows)
            {
                Console.WriteLine(r["SRV_CODIGO"].ToString());
                Console.WriteLine(r["SCF_CODIGO"].ToString());
                Console.WriteLine(r["AGE_CODIGO"].ToString());
                Console.WriteLine(r["AGF_CODIGO"].ToString());
            }

            //var cache = c.ObtenerCacheDeElementos();
        }
    }
}