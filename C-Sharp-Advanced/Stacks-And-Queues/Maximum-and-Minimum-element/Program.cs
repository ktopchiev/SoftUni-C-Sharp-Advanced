using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_and_Minimum_element
{
        /*You have an empty sequence, and you will be given N queries. Each query is one of these three types:

            1 x – Push the element x into the stack.

            2 – Delete the element present at the top of the stack.

            3 – Print the maximum element in the stack.

            4 – Print the minimum element in the stack.

            After you go through all of the queries, print the stack in the following format:

            "{n}, {n1}, {n2} …, {nn}"*/
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            
            for (int i = 0; i < n; i++)
            {
                int[] query = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (query.Length > 1)
                {
                    stack.Push(query[1]);
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        if (query[0] == 2)
                        {
                            stack.Pop();
                        }
                        else if (query[0] == 3)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        else if (query[0] == 4)
                        {
                            Console.WriteLine(stack.Min());
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}