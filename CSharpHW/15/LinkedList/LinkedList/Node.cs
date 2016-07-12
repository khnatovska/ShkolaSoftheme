using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            var leftValue = "none";
            var rightValue = "none";
            if (Left != null)
            {
                leftValue = Left.Value.ToString();
            }
            if (Right != null)
            {
                rightValue = Right.Value.ToString();
            }
            return string.Format("Left: {0}, Value: {1}, Right: {2}", leftValue, Value, rightValue);
        }

        public bool HasRight()
        {
            if (Right != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveLeft()
        {
            Left = null;
        }

        public void RemoveRight()
        {
            Right = null;
        }

        public void RightSubstituteBy(Node<T> node)
        {
            if (Right != null && node != null)
            {
                Right = node;
            }
            else
            {
                RemoveRight();
            }
        }

        public void LeftSubstituteBy(Node<T> node)
        {
            if (Left != null && node != null)
            {
                Left = node;
            }
            else
            {
                RemoveLeft();
            }
        }
        
    }
}
