using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCollections_EasyStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------- Empty stack ----------");
            var s = new EasyStack<int>();
            s.Print();
            try
            {
                s.Pop();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid operation exception catched.");
            }
            try
            {
                s.Peek();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid operation exception catched.");
            }
            s.Push(199);
            s.Push(205);
            s.Push(451);
            s.Push(913);
            s.Print();
            Console.WriteLine("------- Stack size specified ----------");
            var s2 = new EasyStack<int>(2);
            s2.Print();
            s2.Push(199);
            s2.Print();
            var s3 = new EasyStack<int>(0);
            s3.Print();
            s3.Push(199);
            s3.Print();
            Console.WriteLine("------- Stack content specified ----------");
            var s4 = new EasyStack<int>(new int[] { 2, 4, 5, 6, 33, 0 });
            s4.Print();
            s4.Push(199);
            s4.Print();
            var p = s4.Pop();
            Console.WriteLine("Popped {0}", p);
            var p2 = s4.Pop();
            Console.WriteLine("Popped {0}", p2);
            var p3 = s4.Pop();
            Console.WriteLine("Popped {0}", p3);
            s4.Print();
            var pe = s4.Peek();
            Console.WriteLine("Peeked {0}", pe);
            s4.Print();
            Console.WriteLine("Count {0}", s4.Count());
            Console.WriteLine("Contains 33 {0}", s4.Contains(33));
            Console.WriteLine("Contains 44 {0}", s4.Contains(44));
            Console.WriteLine("------- Clear stack ----------");
            s4.Clear();
            s4.Print();
            Console.ReadLine();
        }
    }
}
