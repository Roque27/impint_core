using AccesoDeDatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class ControladorOrdenativos : ControladorMaestro
    {
        QueryOrdenativos Queryes;

        public ControladorOrdenativos()
        {
            Queryes = new QueryOrdenativos();
        }

        protected override void Dispose(bool disposing)
        {
            if (!base.Disposed)
            {
                if (disposing)
                {
                    this.Queryes = null;
                }
                base.Dispose(disposing);
                base.Disposed = true;
            }
        }

        public DateTime Test()
        {
            return Queryes.PruebaConeccion();
        }
    }
}
