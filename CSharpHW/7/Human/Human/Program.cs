using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            var human = new Human();
            var anotherhuman = new Human("Tilda", "Swinton", new DateTime(1961, 5, 12));
            var morehuman = new Human("Alison", "Goldfrapp");
            var samehuman = new Human("Victor", "Frankenstein");
            Console.WriteLine(human.WhoAmI());
            Console.WriteLine("Equal to " + anotherhuman.WhoAmI() + "?");
            Console.WriteLine(human.CompareHuman(anotherhuman));

            Console.WriteLine(morehuman.WhoAmI());
            Console.WriteLine("Equal to " + anotherhuman.WhoAmI() + "?");
            Console.WriteLine(morehuman.CompareHuman(anotherhuman));

            Console.WriteLine(samehuman.WhoAmI());
            Console.WriteLine("Equal to " + human.WhoAmI() + "?");
            Console.WriteLine(samehuman.CompareHuman(human));

            Console.ReadLine();
        }
    }
}
