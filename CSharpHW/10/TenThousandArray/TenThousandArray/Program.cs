using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenThousandArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = new int[] { 1, 2, 3, 4, 5, 1, 3, 4, 5 };
            var second = new int[] { 4, 4, 5, 5, 6, 6, 7 };
            var third = new int[] { 0, 4, 2, 9, 5, 14, 0, 5, 9, 2, 4 };

            var firstUnique = FindUniqueValue(first);
            var secondUnique = FindUniqueValue(second);
            var thirdUnique = FindUniqueValue(third);

            Console.WriteLine(firstUnique);
            Console.WriteLine(secondUnique);
            Console.WriteLine(thirdUnique);

            Console.ReadLine();
        }

        static int FindUniqueValue(int[] array)
        {
            var dict = new Dictionary<int, List<int>> { { 1, new List<int>() }, { 2, new List<int>() } };
            foreach (int item in array)
            {
                if (!dict[1].Contains(item))
                {
                    dict[1].Add(item);
                }
                else
                {
                    dict[1].Remove(item);
                    dict[2].Add(item);
                }
            }
            return dict[1][0];
        }
    }
}
