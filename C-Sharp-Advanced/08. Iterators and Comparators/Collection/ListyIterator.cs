using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> _data;
        private int _internalIndexPosition = 0;
        
        public ListyIterator(params T[] input)
        {
            _data = new List<T>(input);
        }

        public bool Move()
        {
            _internalIndexPosition++;
            if (_internalIndexPosition < _data.Count)
            {
                return true;
            }
            
            _internalIndexPosition--;
            return false;
            
        }

        public bool HasNext()
        {
            return _internalIndexPosition + 1 < _data.Count;
        }

        public void Print()
        {
            if (_data.Count > 0)
                Console.WriteLine(_data[_internalIndexPosition]);
            else
                Console.WriteLine("Invalid Operation");
        }

        public void PrintAll()
        {
            foreach (var element in _data)
            {
                Console.Write(element + " ");
            }

            Console.WriteLine();
        }
        
        public ListyIterator(IEnumerable<T> data)
        {
            _data = data.ToList();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _data.Count; i++)
            {
                yield return _data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}