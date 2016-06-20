using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseHolder = new ResourceHolderBase();
            using (baseHolder)
            {
                baseHolder.BaseAction();
            }
            using (var derivedHolder = new ResourceHolderBase())
            {
                derivedHolder.BaseAction();
            }
            baseHolder.Dispose();

                Console.ReadLine();
        }
    }
}
