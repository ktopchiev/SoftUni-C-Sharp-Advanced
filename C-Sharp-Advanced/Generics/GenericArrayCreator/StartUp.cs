using System.Collections.Generic;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] pesho = ArrayCreator.Create(5, "Pesho");
            int[] fours = ArrayCreator.Create(10, 4);
            Stack<int>[] stacks = ArrayCreator.Create(5, new Stack<int>());
        }
    }
}