using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;


namespace Printer
{
    public class PhotoPrinter : Printer
    {
        public void Print(Image image)
        {
            Console.WriteLine(image);
        }

        public override void Print(string message)
        {
            Console.WriteLine("Photo printer printing...");
            Console.WriteLine(message);
        }
    }
}
