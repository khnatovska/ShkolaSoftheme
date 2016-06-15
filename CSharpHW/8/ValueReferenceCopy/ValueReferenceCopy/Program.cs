using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueReferenceCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            var value = 1;
            var copyV = CopyValue(value);
            Console.WriteLine(value.ToString() + " " + copyV.ToString());
            value = 2;
            Console.WriteLine(value.ToString() + " " + copyV.ToString());

            var reference = new User("mongolia", "qwerty", "lower");
            var copyR = CopyReference(reference);
            Console.WriteLine(reference.GetDepartment() + " " + copyR.GetDepartment());
            reference.ChangeDepartment("upper");
            Console.WriteLine(reference.GetDepartment() + " " + copyR.GetDepartment());

            Console.ReadLine();
        }

        static int CopyValue(int a)
        {
            int copy = a;
            return copy;
        }

        static User CopyReference(User b)
        {
            User copy = b;
            return copy;
        }
    }
}
