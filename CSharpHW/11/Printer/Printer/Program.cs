using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Printer
{
    class Program
    {
        static void Main(string[] args)
        {
            var printer = new Printer();
            printer.Print("regular printer printing a message");
            var colourPrinter = new ColourPrinter();
            colourPrinter.Print("colour printer printing a message in red", ConsoleColor.Red);
            printer.Print("regular printer printing a message again");
            colourPrinter.Print("message without colour");
            colourPrinter.Print("colour printer printing a message in green", ConsoleColor.DarkGreen);
            var photoPrinter = new PhotoPrinter();
            photoPrinter.Print("message without photo");
            photoPrinter.Print(Image.FromFile("maidukov1.jpg"));

            Console.ReadLine();
        }
    }
}
