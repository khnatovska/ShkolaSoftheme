using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            var vodafone = new Operator();

            var account1 = vodafone.RegisterAccount();
            var account2 = vodafone.RegisterAccount();
            var account3 = vodafone.RegisterAccount();
            var account4 = vodafone.RegisterAccount();
            account2.SaveNumber(account4.Number, "weirdo");
            account2.SaveNumber(account1.Number, "Isabella");
            Console.WriteLine("-----------------");

            account4.Call(account3.Callable());
            Console.WriteLine("-----------------");
            account4.Call(account2.Callable());
            Console.WriteLine("-----------------");
            account4.Call("380660003948");
            Console.WriteLine("-----------------");
            account1.SendMessage(account2.Callable(), "ururu");
            Console.WriteLine("-----------------");

            Console.ReadLine();
        }
        
    }
}
