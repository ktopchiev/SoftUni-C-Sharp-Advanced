using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = parameters[0];
            int s = parameters[1];
            int x = parameters[2];
            
            Stack<int> elements = new Stack<int>();

            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < n; i++)
            {
                elements.Push(nums[i]);
            }

            for (int i = 0; i < s; i++)
            {
                elements.Pop();
            }
            
            if (elements.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                if (elements.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else if (!elements.Contains(x))
                {
                    Console.WriteLine(elements.Min());
                }
            }
        }
    }
}