using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConstructor
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = CarConstructor.Construct(new Engine(4, "German"), new Color(), new Transmission());
            Console.WriteLine(car.Describe());

            CarConstructor.Reconstruct(car, new Engine(4, "Japanese"));
            Console.WriteLine(car.Describe());

            Console.ReadLine();
        }
    }
}
