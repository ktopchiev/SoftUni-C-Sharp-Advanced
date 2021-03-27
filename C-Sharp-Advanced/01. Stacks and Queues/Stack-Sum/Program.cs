using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().ToLower().Split();
            Stack<int> stack = new Stack<int>(integers);

            while (!command.Contains("end"))
            {
                if (command.Contains("add"))
                {
                    int firstNum = int.Parse(command[1]);
                    int secondNum = int.Parse(command[2]);
                    stack.Push(firstNum);
                    stack.Push(secondNum);
                }
                else if (command.Contains("remove") && stack.Count >= int.Parse(command[1]))
                {
                    int removeCount = int.Parse(command[1]);
                    
                    for (int i = 0; i < removeCount; i++)
                    {
                        stack.Pop();
                    }
                }
                
                command = Console.ReadLine().ToLower().Split();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}