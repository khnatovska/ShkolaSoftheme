using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    public class Number
    {
        public int Num { get; set; }

        public Number(int num)
        {
            Num = num;
        }

        public override bool Equals(object obj)
        {
            return (obj is Number) && Equals((Number)obj);
        }

        public bool Equals(Number anotherNumber)
        {
            return Num == anotherNumber.Num;
        }

        public override int GetHashCode()
        {
            return Num.GetHashCode();
        }
    }
}
