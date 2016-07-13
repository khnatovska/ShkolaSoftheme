using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCollections_EasyQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------- Empty queue ----------");
            var q = new EasyQueue<int>();
            q.Print();
            try
            {
                q.Dequeue();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid operation exception catched.");
            }
            try
            {
                q.Peek();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid operation exception catched.");
            }
            q.Enqueue(199);
            q.Enqueue(205);
            q.Enqueue(451);
            q.Enqueue(913);
            q.Print();
            Console.WriteLine("------- Queue size specified ----------");
            var q2 = new EasyQueue<int>(2);
            q2.Print();
            q2.Enqueue(199);
            q2.Print();
            var q3 = new EasyQueue<int>(0);
            q3.Print();
            q3.Enqueue(199);
            q3.Print();
            Console.WriteLine("------- Queue content specified ----------");
            var q4 = new EasyQueue<int>(new int[] { 2, 4, 5, 6, 33, 0});
            q4.Print();
            q4.Enqueue(199);
            q4.Print();
            var d = q4.Dequeue();
            Console.WriteLine("Dequeued {0}", d);
            q4.Print();
            var p = q4.Peek();
            Console.WriteLine("Peeked {0}", p);
            q4.Print();
            Console.WriteLine("Count {0}", q4.Count());
            Console.WriteLine("Contains 33 {0}", q4.Contains(33));
            Console.WriteLine("Contains 44 {0}", q4.Contains(44));
            Console.WriteLine("------- Clear queue ----------");
            q4.Clear();
            q4.Print();
            Console.ReadLine();
        }
    }
}
