using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDescriptor
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = new ShapeDescriptor(new Point(), new Point(3, 4));
            var triangle = new ShapeDescriptor(new Point(), new Point(0, 34), new Point(45, 0));
            var square = new ShapeDescriptor(new Point(), new Point(20, 0), new Point(20, 20), new Point(0, 20));

            Console.WriteLine(line.GetShapeType());
            Console.WriteLine(triangle.GetShapeType());
            Console.WriteLine(square.GetShapeType());

            Console.ReadLine();
        }
    }
}
