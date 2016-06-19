using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrappedArray
{
    public class WrappedArray
    {
        int[] InnerArray { get; set; }

        public WrappedArray(params int[] arguments)
        {
            if (arguments == null || arguments.Length == 0)
            {
                throw new ArgumentException("Null or empty arguments list");
            }
            InnerArray = arguments;
        }

        public void Add(params int[] arguments)
        {
            if (arguments == null || arguments.Length == 0)
            {
                throw new ArgumentException("Null or empty arguments list");
            }
            var newInnerArray = new int[InnerArray.Length + arguments.Length];
            Array.Copy(InnerArray, newInnerArray, InnerArray.Length);
            Array.Copy(arguments, 0, newInnerArray, InnerArray.Length, arguments.Length);
            InnerArray = newInnerArray;
        }

        public bool Contains(int value)
        {
            foreach (int item in InnerArray)
            {
                if (item == value)
                    return true;
            }
            return false;
        }

        public int GetByIndex(int index)
        {
            if (index < 0 || index >= InnerArray.Length)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
            return InnerArray[index];
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (int item in InnerArray)
            {
                result += item.ToString() + " ";
            }
            return result;
        }
    }
}
