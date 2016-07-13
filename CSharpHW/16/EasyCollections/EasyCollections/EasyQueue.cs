using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCollections_EasyQueue
{
    public class EasyQueue<T>
    {
        T[] InnerQueue;

        public EasyQueue()
        {
            InnerQueue = new T[0]; 
        }

        public EasyQueue(int size)
        {
            InnerQueue = new T[size];
        }

        public EasyQueue(T[] array)
        {
            InnerQueue = array;
        }

        public void Enqueue(T element)
        {
            var newSize = InnerQueue.Length + 1;
            var newArray = new T[newSize];
            Array.Copy(InnerQueue, newArray, InnerQueue.Length);
            InnerQueue = newArray;
            InnerQueue[InnerQueue.Length - 1] = element;
        }

        public T Dequeue()
        {
            try
            {
                var dequeued = InnerQueue[0];
                var newSize = InnerQueue.Length - 1;
                var newArray = new T[newSize];
                Array.Copy(InnerQueue, 1, newArray, 0, InnerQueue.Length - 1);
                InnerQueue = newArray;
                return dequeued;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Nothing to dequeue.");
                throw new InvalidOperationException();
            }
            
        }

        public T Peek()
        {
            try
            {
                return InnerQueue[0];
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
            foreach (var i in InnerQueue)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine(" }");
        }

        public T[] ToArray()
        {
            return InnerQueue;
        }

        public bool Contains(T element)
        {
            if (InnerQueue.Contains(element))
                return true;
            return false;
        }

        public int Count()
        {
            return InnerQueue.Length;
        }

        public void Clear()
        {
            InnerQueue = new T[0];
        }
    }
}
