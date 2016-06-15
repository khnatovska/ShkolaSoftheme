using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConstructor
{
    public class Car
    {
        public Color _color { get; set; }
        public Engine _engine { get; set; }
        public Transmission _transmision { get; set; }

        public Car(Engine engine, Transmission transmission, Color color)
        {
            _engine = engine;
            _transmision = transmission;
            _color = color;
        }

        public string Describe()
        {
            return _color.ToString() + ", " + _engine.ToString() + ", " + _transmision.ToString();
        }
    }
}
