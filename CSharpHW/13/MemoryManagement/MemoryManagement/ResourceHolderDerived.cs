using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MemoryManagement
{
    class ResourceHolderDerived : ResourceHolderBase, IDisposable
    {
        public bool Disposed = false;

        public override void BaseAction()
        {
            Console.WriteLine("Derived performing an action");
            Resource = new StreamReader("ResourceHolderDerived.txt");
        }

        ~ResourceHolderDerived()
        {
            Console.WriteLine("ResourceHolderDerived is being finalized.");
            this.Dispose();
            base.Dispose();
        }

        public override void Dispose()
        {
            Console.WriteLine("ResourceHolderDerived is being disposed");
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public override void Dispose(bool disposing)
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
