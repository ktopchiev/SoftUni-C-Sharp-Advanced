using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private readonly List<T> _stack;

        public CustomStack()
        {
            _stack = new List<T>();
        }
        
        public void Push(params T[] elements)
        {
            foreach (var element in elements)
            {
                _stack.Add(element);
            }
        }

        public object Pop()
        {
            object lastElement = null;
            
            if(_stack.Count > 0)
            { 
                lastElement = _stack.Last();
                _stack.RemoveAt(_stack.Count - 1);
            }
            else
            {
                Console.WriteLine("No elements");
            }
            
            return lastElement;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _stack.Count - 1; i >= 0; i--)
            {
                yield return _stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}