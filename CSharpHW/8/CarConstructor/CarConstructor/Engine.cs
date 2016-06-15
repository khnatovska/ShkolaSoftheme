using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConstructor
{
    public class Engine
    {
        public int Cylinders { get; set; }
        public string Origin { get; set; }

        public Engine(int cylinders, string origin)
        {
            Cylinders = cylinders;
            Origin = origin;
        }

        public override string ToString()
        {
            return Origin + " engine with " + Cylinders + " cylinders";
        }
    }
}
