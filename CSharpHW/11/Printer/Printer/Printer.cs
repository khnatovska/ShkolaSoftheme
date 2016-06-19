using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer
{
    public class Printer
    {
        public virtual void Print(string message)
        {
            Console.WriteLine("Printer printing...");
            Console.WriteLine(message);
        }
    }
}
