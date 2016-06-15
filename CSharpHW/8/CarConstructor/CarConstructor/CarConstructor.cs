using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConstructor
{
    public static class CarConstructor
    {
        public static Car Construct(Engine engine, Color color, Transmission transmission)
        {
            return new Car(engine, transmission, color);
        }

        public static Car Reconstruct(Car car, Engine engine)
        {
            car._engine = engine;
            return car;
        }
    }
}
