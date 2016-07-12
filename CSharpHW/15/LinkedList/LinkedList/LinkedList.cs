using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList<TItem> : ILinkedList<TItem>
    {
        Node<TItem> Head { get; set; }
        Node<TItem> Tail { get; set; }
        Node<TItem> Current { get; set; }
        int Count = 0;

        
        public LinkedList(params TItem[] elements)
        {
            Head = Tail = Current = null;
            foreach (TItem element in elements)
            {
                AddElement(element);
            }

        }

        public void AddElement(TItem element)
        {
            var NewElement = new Node<TItem>(element);

            if (Count == 0)
            {
                Head = NewElement;
                Tail = NewElement;
                Current = NewElement;
            }
            else
            {
                Tail.Right = NewElement;
                NewElement.Left = Tail;
                Tail = NewElement;
                Current = Tail;
            }
            Count++;

        }

        public bool CheckElement(TItem element)
        {
            var pointerNode = Head;
            for (var i = 1; i <= Count; i++)
            {
                if (pointerNode.Value.Equals(element))
                {
                    return true;
                }
                pointerNode = pointerNode.Right;
            }
            return false;
        }

        public int CountElements()
        {
            return Count;
        }

        public void RemoveElement(TItem element)
        {
            var pointerNode = Head;
            for (var i = 1; i <= Count; i++)
            {
                if (pointerNode.Value.Equals(element))
                {
                    if (pointerNode.Left != null)
                    {
                        pointerNode.Left.RightSubstituteBy(pointerNode.Right);
                    }
                    if (pointerNode.Right != null)
                    {
                        pointerNode.Right.LeftSubstituteBy(pointerNode.Left);
                    }
                    
                    if (pointerNode == Head)
                    {
                        Head = pointerNode.Right;
                    }
                    if (pointerNode == Tail)
                    {
                        Tail = pointerNode.Left;
                    }
                    Count--;
                    return;
                }
                pointerNode = pointerNode.Right;
            }
        }

        public TItem[] ToArray()
        {
            var pointerNode = Head;
            var array = new TItem[Count];
            for (var i = 0; i < Count; i++)
            {
                array[i] = pointerNode.Value;
                pointerNode = pointerNode.Right;
            }
            return array;
        }
        
        public void Describe()
        {
            var described = Head;
            Console.WriteLine("--------");
            for (var i = 1; i <= Count; i++)
            {
                Console.WriteLine(described);
                described = described.Right;
            }
            Console.WriteLine("--------");
        }
    }
}
