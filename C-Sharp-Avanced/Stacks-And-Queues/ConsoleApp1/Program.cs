using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] {1, 2, 3};
            Stack<int> ints = new Stack<int>(nums);

            while (true)
            {
                ints.Pop();
            }
        }
    }
}