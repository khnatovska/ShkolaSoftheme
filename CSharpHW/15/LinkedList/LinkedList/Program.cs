using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new LinkedList<int>(1);
            list1.Describe();
            list1.RemoveElement(1);
            list1.Describe();

            var list = new LinkedList<int>(1, 2, 4);
            list.Describe();
            list.RemoveElement(2);
            list.Describe();
            list.AddElement(33);
            Console.WriteLine(list.ToArray());

            var list2 = new LinkedList<string>("ma", "ra", "hu");
            //list2.Describe();
            //list2.RemoveElement("hu");
            //list2.RemoveElement("ma");
            //list2.RemoveElement("dondon");
            //list2.Describe();
            list2.AddElement("ururu");
            //list2.Describe();
            //list2.RemoveElement("ra");
            list2.Describe();
            foreach (var item in list2.ToArray())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
