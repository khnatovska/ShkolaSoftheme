using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zodiac_WPF
{
    class SignPair
    {
        public string firstSign { get; set; }
        public string secondSign { get; set; }
        public int lastDayOfFirstSign { get; set; }

        public SignPair(string first, string second, int lastDay)
        {
            firstSign = first;
            secondSign = second;
            lastDayOfFirstSign = lastDay;
        }
    }
}
