using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticTuningAtelier
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car();
            Console.WriteLine("Your car:");
            car.Describe();
            TuningAtelier.TuneCar(car);
            Console.WriteLine("Your tuned car:");
            car.Describe();
            Console.ReadLine();
        }
    }
}
