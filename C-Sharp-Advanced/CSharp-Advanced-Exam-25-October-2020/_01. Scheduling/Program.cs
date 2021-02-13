using System.Linq;
using System;
using System.Collections.Generic;

namespace _01._Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            //Getting the input
            int[] tasks = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] threads = Console.ReadLine().Split(" ", StringSplitOptions
                .RemoveEmptyEntries).Select(int.Parse).ToArray();

            int taskToBeKilled = int.Parse(Console.ReadLine());
            
            Queue<int> threadsContainer = new Queue<int>(threads);
            Stack<int> tasksContainer = new Stack<int>(tasks);

            while (threadsContainer.Count > 0 && tasksContainer.Count > 0)
            {
                
                if (tasksContainer.Peek() == taskToBeKilled)
                {
                    Console.WriteLine($"Thread with value {threadsContainer.Peek()} killed task {taskToBeKilled}");
                    break;
                }
                
                if (threadsContainer.Peek() >= tasksContainer.Peek())
                {
                    threadsContainer.Dequeue();
                    tasksContainer.Pop();
                }
                else if (threadsContainer.Peek() < tasksContainer.Peek())
                {
                    threadsContainer.Dequeue();
                }
            }

            Console.WriteLine(string.Join(" ", threadsContainer));
        }
    }
}