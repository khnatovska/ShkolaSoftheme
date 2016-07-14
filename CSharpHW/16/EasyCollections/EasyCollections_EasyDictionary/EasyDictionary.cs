using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCollections_EasyDictionary
{
    public class EasyDictionary<TKey, TValue>
    {
        List<TKey> KeysList;
        List<TValue> ValuesList;

        public EasyDictionary()
        {
            KeysList = new List<TKey>();
            ValuesList = new List<TValue>();
        }

        public void Add(TKey key, TValue value)
        {
            if (KeysList.Contains(key))
            {
                throw new ArgumentException("Key is already present.");
            }
            KeysList.Add(key);
            ValuesList.Add(value);
        }

        public void Remove(TKey key)
        {
            if (!KeysList.Contains(key))
            {
                throw new ArgumentException("Key is absent.");
            }
            var index = KeysList.IndexOf(key);
            KeysList.RemoveAt(index);
            ValuesList.RemoveAt(index);
        }

        public int Count()
        {
            return KeysList.Count;
        }

        public List<TKey> Keys()
        {
            return KeysList;
        }

        public List<TValue> Values()
        {
            return ValuesList;
        }

        public bool ContainsKey(TKey key)
        {
            if (KeysList.Contains(key))
                return true;
            else
                return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);
            if (KeysList.Contains(key))
            {
                value = ValuesList[KeysList.IndexOf(key)];
                return true;
            }
            return false;
        }

        public TValue this[TKey key]
        {
            get
            {
                TValue value;
                try
                {
                    value = ValuesList[KeysList.IndexOf(key)];
                    return value;
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new KeyNotFoundException("Key is absent.");
                }
            }
            set
            {
                if (KeysList.Contains(key))
                {
                    throw new ArgumentException("Key is already present.");
                }
                KeysList.Add(key);
                ValuesList.Add(value);
            }
        }

        public void Print()
        {
            Console.Write("{");
            for (var i = 0; i < KeysList.Count; i++)
            {
                Console.Write(" {0} : {1}, ", KeysList[i], ValuesList[i]);
            }
            Console.WriteLine(" }");
        }
    }
}
