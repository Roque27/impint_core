using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core
{
    public class ControladorMaestro : IDisposable
    {
        string JSONfile = @"..\\Core\\RecursosElementos.json";
        public List<CacheElemento> ObtenerCacheDeElementos()
        {
            List<CacheElemento> cache = null;
            using(StreamReader file = File.OpenText(JSONfile))
            {
                JsonSerializer serializer = new JsonSerializer();
                cache = (List<CacheElemento>)serializer.Deserialize(file, typeof(List<CacheElemento>));
            }
            return cache;
        }

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
