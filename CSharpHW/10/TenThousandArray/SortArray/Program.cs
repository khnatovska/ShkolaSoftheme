using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = new int[] { 9, 4, 5, 1 };
            PrintArray(MergeSortArray(first));

            var second = new int[] { 9, 4, 5, 1, 2, 8, 3, 0, 6, 7, 11 };
            PrintArray(MergeSortArray(second));

            var third = new int[] { 5, 85, 0, 4, 1, 56, 11, 2, 4, 96, 4, 115, 18 };
            PrintArray(MergeSortArray(third));

            Console.ReadLine();
        }

        static int[] MergeSortArray(int[] array)
        {
            if (array.Length == 1)
                return array;
            else
            {
                var middle = array.Length / 2;
                var leftArray = new int[middle];
                Array.Copy(array, leftArray, middle);
                var rightArray = new int[array.Length - middle];
                Array.Copy(array, middle, rightArray, 0, array.Length - middle);
                                
                var leftSorted = MergeSortArray(leftArray);
                var rightSorted = MergeSortArray(rightArray);
                var sorted = new int[leftSorted.Length + rightSorted.Length];
                var leftArrayPointer = 0;
                var rightArrayPointer = 0;
                var sortedPointer = 0;

                while ((leftArrayPointer < leftSorted.Length) && (rightArrayPointer < rightSorted.Length))
                    {
                    if (leftSorted[leftArrayPointer] <= rightSorted[rightArrayPointer])
                    {
                        sorted[sortedPointer] = leftSorted[leftArrayPointer];
                        leftArrayPointer++;
                    }
                    else
                    {
                        sorted[sortedPointer] = rightSorted[rightArrayPointer];
                        rightArrayPointer++;
                    }
                    sortedPointer++;
                    }

                if (leftArrayPointer < leftSorted.Length)
                {
                    Array.Copy(leftSorted, leftArrayPointer, sorted, sortedPointer, leftSorted.Length - leftArrayPointer);
                    sortedPointer += leftSorted.Length - leftArrayPointer;
                }
                else
                {
                    Array.Copy(rightSorted, rightArrayPointer, sorted, sortedPointer, rightSorted.Length - rightArrayPointer);
                }
                
                return sorted;
            }
          
        }


        public static void PrintArray(int[] array)
        {
            string result = string.Empty;
            foreach (int item in array)
            {
                result += item.ToString() + " ";
            }
            Console.WriteLine(result);
        }
    }
}
