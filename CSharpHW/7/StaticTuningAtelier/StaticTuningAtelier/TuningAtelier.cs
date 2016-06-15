using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticTuningAtelier
{
    public static class TuningAtelier
    {
        public static void TuneCar(Car car)
        {
            Console.WriteLine("Tuning your car...");
            car.ChangeColor("Red");
        }
    }
}
