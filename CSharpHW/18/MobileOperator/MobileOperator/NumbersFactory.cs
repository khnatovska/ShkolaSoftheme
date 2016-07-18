using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOperator
{
    public class NumbersFactory
    {
        List<MobileNumber> AvailableNumbers { get; }
        string CountryCode = "38";
        string OperatorCode = "066";

        public NumbersFactory(int size)
        {
            AvailableNumbers = new List<MobileNumber>();
            var random = new Random();
            for (var i = 0; i < size; i++)
            {
                var numberBuilder = string.Empty;
                for (var j = 0; j < 7; j++)
                {
                    numberBuilder += random.Next(0, 10);
                }
                var newNumber = new MobileNumber(CountryCode, OperatorCode, numberBuilder);
                AvailableNumbers.Add(newNumber);
            }
        }

        public MobileNumber GetAvailableNumber()
        {
            var number = AvailableNumbers[0];
            AvailableNumbers.Remove(number);
            return number;
        }

    }
}
