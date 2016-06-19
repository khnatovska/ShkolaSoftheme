using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Printer;
using System.Drawing;

namespace ExtendedPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            var printer = new Printer.Printer();
            printer.Multiprint(new string[] { "message one", "message two" });

            var colourPrinter = new ColourPrinter();
            colourPrinter.Multiprint(new string[] { "colour message one", "colour message two" }, ConsoleColor.DarkCyan);

            var photoPrinter = new PhotoPrinter();
            photoPrinter.Multiprint(new Image[] { Image.FromFile("maidukov1.jpg"), Image.FromFile("capricorn.png")});

            Console.ReadLine();
        }
    }
}
