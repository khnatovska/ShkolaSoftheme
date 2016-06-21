using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    public class Combination
    {
        public Number[] Numbers;
        int position;

        public Combination()
        {
            Numbers = new Number[6];
            position = 0;
        }

        public void AddNumber(int num)
        {
            if (position < Numbers.Length)
            {
                var number = new Number(num);
                Numbers[position] = number;
                position++;
            }            
        }

        public void Generate()
        {
            var random = new Random();
            while (position < Numbers.Length)
            {
                AddNumber(random.Next(1, 10));
            }
        }

        public Number this[int index]
        {
            get
            {
                return Numbers[index];
            }
            set
            {
                Numbers[index] = value;
            }
        }

        public string  PrintNumbers()
        {
            string print = string.Empty;
            foreach (Number num in Numbers)
            {
                if (num != null)
                {
                    print += num.Num + " ";
                }                
            }
            return print;
        }

        public override bool Equals(object obj)
        {
            return (obj is Combination) && Equals((Combination)obj);
        }

        public bool Equals(Combination anotherCombination)
        {
            if (Numbers.Length != anotherCombination.Numbers.Length)
                return false;
            int comparePosition = 0;
            foreach (Number num in Numbers)
            {
                if (num.Equals(anotherCombination[comparePosition]) == false)
                    return false;
                comparePosition++;
            }
            return true;
        }
    }
}
