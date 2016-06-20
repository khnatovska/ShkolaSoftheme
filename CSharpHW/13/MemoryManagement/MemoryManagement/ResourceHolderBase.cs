using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MemoryManagement
{
    public class ResourceHolderBase : IDisposable
    {
        private bool Disposed = false;
        protected StreamReader Resource;

        public virtual void BaseAction()
        {
            Console.WriteLine("Base performing an action.");
            Resource = new StreamReader("ResourceHolderBase.txt");
        }

        ~ResourceHolderBase()
        {
            Console.WriteLine("ResourceHolderBase is being finalized.");
            Dispose();
        }

        public virtual void Dispose()
        {
            Console.WriteLine("ResourceHolderBase is being disposed");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    if (Resource != null)
                    {
                        Resource.Dispose();
                    }
                }
                Disposed = true;
            }
        }
    }
}
