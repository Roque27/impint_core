using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class ControladorMaestro : IDisposable
    {
        protected bool Disposed;

        public ControladorMaestro()
        {
            this.Disposed = false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                    // Los recursos manejados manualmente van aqui.
                }
                // Recursos de los cuales no se posee control sobre ellos.
                this.Disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ControladorMaestro()
        {
            Dispose(false);
        }
    }
}
