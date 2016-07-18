using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOperator
{
    public class MobileNumber
    {
        public string CountryCode;
        public string OperatorCode;
        public string Number;

        public MobileNumber(string number)
        {
            CountryCode = number.Substring(0, 2);
            OperatorCode = number.Substring(2, 3);
            Number = number.Substring(5, 7);            
        }

        public MobileNumber(string country, string moboperator, string number)
        {
            CountryCode = country;
            OperatorCode = moboperator;
            Number = number;
        }

        public void Print()
        {
            Console.WriteLine(CountryCode + OperatorCode + Number);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            MobileNumber num = obj as MobileNumber;
            if ((object)num == null)
            {
                return false;
            }
            return (CountryCode == num.CountryCode && OperatorCode == num.OperatorCode && Number == num.Number);
        }

        public bool Equals(MobileNumber other)
        {
            if ((object)other == null)
            {
                return false;
            }
            return (CountryCode == other.CountryCode && OperatorCode == other.OperatorCode && Number == other.Number);
        }

        public override string ToString()
        {
            return CountryCode + " (" + OperatorCode + ") " + Number;
        }

        public string GetFullNumber()
        {
            return CountryCode + OperatorCode + Number;
        }
    }
}
