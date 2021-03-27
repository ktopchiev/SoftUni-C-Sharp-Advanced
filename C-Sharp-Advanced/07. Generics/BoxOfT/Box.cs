using System.Collections.Generic;
using System.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        public int Count => BoxList.Count;
        private List<T> BoxList { get; set; }

        public Box()
        {
            BoxList = new List<T>();
        }
        
        public void Add(T element)
        {
            BoxList.Add(element);
        }

        public T Remove()
        {
            var rem = BoxList.Last();
            BoxList.RemoveAt(BoxList.Count - 1);
            return rem;
        }
    }
}