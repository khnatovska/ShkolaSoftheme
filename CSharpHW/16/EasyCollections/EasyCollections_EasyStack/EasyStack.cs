using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCollections_EasyStack
{
    public class EasyStack<T>
    {
        T[] InnerStack;

        public EasyStack()
        {
            InnerStack = new T[0];
        }

        public EasyStack(int size)
        {
            InnerStack = new T[size];
        }

        public EasyStack(T[] array)
        {
            InnerStack = new T[array.Length];
            var index = array.Length - 1;
            foreach (var item in array)
            {
                InnerStack[index] = item;
                index--;
            }
        }

        public void Push(T element)
        {
            var newSize = InnerStack.Length + 1;
            var newArray = new T[newSize];
            Array.Copy(InnerStack, 0, newArray, 1, InnerStack.Length);
            InnerStack = newArray;
            InnerStack[0] = element;
        }

        public T Pop()
        {
            try
            {
                var popped = InnerStack[0];
                var newSize = InnerStack.Length - 1;
                var newArray = new T[newSize];
                Array.Copy(InnerStack, 1, newArray, 0, InnerStack.Length - 1);
                InnerStack = newArray;
                return popped;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Nothing to pop.");
                throw new InvalidOperationException();
            }

        }

        public T Peek()
        {
            try
            {
                return InnerStack[0];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Nothing to peek at.");
                throw new InvalidOperationException();
            }
        }

        public void Print()
        {
            Console.Write("{");
            foreach (var i in InnerStack)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine(" }");
        }

        public T[] ToArray()
        {
            return InnerStack;
        }

        public bool Contains(T element)
        {
            if (InnerStack.Contains(element))
                return true;
            return false;
        }

        public int Count()
        {
            return InnerStack.Length;
        }

        public void Clear()
        {
            InnerStack = new T[0];
        }
    }
}
