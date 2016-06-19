using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer
{
    public class ColourPrinter : Printer
    {
        public void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public override void Print(string message)
        {
            Console.WriteLine("Colour printer printing...");
            Console.WriteLine(message);
        }
    }
}
