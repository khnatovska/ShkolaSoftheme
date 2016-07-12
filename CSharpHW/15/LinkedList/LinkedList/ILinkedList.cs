using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public interface ILinkedList<TItem>
    {
        void AddElement(TItem element);
        void RemoveElement(TItem element);
        int CountElements();
        bool CheckElement(TItem element);
        TItem[] ToArray();
    }
}
