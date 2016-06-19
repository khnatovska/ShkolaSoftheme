using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrappedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = new WrappedArray(1, 2, 3);
            Console.WriteLine(first);
            Console.WriteLine("Contains 4: {0}", first.Contains(4));
            try
            {
                Console.WriteLine("Getting by index 4: {0}", first.GetByIndex(4));
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            first.Add(4, 5);
            Console.WriteLine(first);
            Console.WriteLine("Contains 4: {0}", first.Contains(4));
            Console.WriteLine("Getting by index 4: {0}", first.GetByIndex(4));

            var second = new WrappedArray(new int[] { 3, 4, 5, 6, 2 });
            Console.WriteLine(second);
            Console.WriteLine("Contains 0: {0}", second.Contains(0));
            try
            {
                Console.WriteLine("Getting by index -1: {0}", second.GetByIndex(-1));
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            second.Add(new int[] { 15, 6, 0, 32, 46, 12, 3, 4, 5, 9, 0, 0, 0, 7 });
            Console.WriteLine(second);
            Console.WriteLine("Contains 0: {0}", second.Contains(0));
            Console.WriteLine("Getting by index 2: {0}", second.GetByIndex(2));

            Console.ReadLine();
        }
    }
}
