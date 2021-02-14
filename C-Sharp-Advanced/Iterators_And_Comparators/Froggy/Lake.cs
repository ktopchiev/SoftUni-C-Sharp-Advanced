using System;
using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class Lake<T> : IEnumerable<T>
    {
        private readonly List<T> _stones;

        public Lake()
        {
            _stones = new List<T>();
        }

        public Lake(params T[] stones)
        {
            _stones = new List<T>();
            
            for (int i = 0; i < stones.Length; i += 2)
            {
                _stones.Add(stones[i]);
            }

            int index = _stones.Count;
            
            for (int i = 1; i < stones.Length ; i +=2)
            {
                _stones.Insert(index, stones[i]);
            }
        }

        public void Print()
        {
            Console.WriteLine(string.Join(", ", _stones));
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _stones.Count; i++)
            {
                yield return _stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}