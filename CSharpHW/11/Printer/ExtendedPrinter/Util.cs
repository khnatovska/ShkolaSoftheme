using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Printer;
using System.Drawing;

namespace ExtendedPrinter
{
    public static class Util
    {
        public static void Multiprint(this Printer.Printer printer, string[] messages)
        {
            foreach (string message in messages)
            {
                printer.Print(message);
            }
        }

        public static void Multiprint(this ColourPrinter colourPrinter, string[] messages, ConsoleColor color)
        {
            foreach (string message in messages)
            {
                colourPrinter.Print(message, color);
            }
        }

        public static void Multiprint(this PhotoPrinter photoPrinter, Image[] images)
        {
            foreach (Image image in images)
            {
                photoPrinter.Print(image);
            }
        }
    }
}
