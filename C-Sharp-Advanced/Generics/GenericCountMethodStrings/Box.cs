using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStrings
{
    public class Box<T>
        where T : IComparable
    {
        private List<T> box;

        public Box(List<T> newList)
        {
            box = newList;
        }

        public int CountString(T element)
        {
            int counter = 0;
            T elementToCompare = element;
            
            foreach (var item in box)
            {
                if (item.CompareTo(elementToCompare) == 1)
                {
                    counter++;
                }
            }

            return counter;
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{box.GetType()}: ");
            sb.Append($"{box}");
            return sb.ToString();
        }
    }
}