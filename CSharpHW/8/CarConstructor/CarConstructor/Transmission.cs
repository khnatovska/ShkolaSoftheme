using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConstructor
{
    public class Transmission
    {
        public bool Manual = true;

        public override string ToString()
        {
            if (Manual == true)
                return "manual transmission";
            else
                return "automatic transmission";
        }
    }
}
