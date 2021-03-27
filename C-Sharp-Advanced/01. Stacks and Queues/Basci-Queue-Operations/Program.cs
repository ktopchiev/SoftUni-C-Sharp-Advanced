using System;
using System.Collections.Generic;
using System.Linq;

namespace Basci_Queue_Operations
{
    /*
     * Play around with a queue. You will be given an integer N representing the number of elements to enqueue (add),
     * an integer S representing the number of elements to dequeue (remove) from the queue and finally an integer X,
     * an element that you should look for in the queue. If it is, print true on the console.
     * If it’s not print the smallest element currently present in the queue.
     * If there are no elements in the sequence, print 0 on the console.
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputParameters = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = inputParameters[0];
            int s = inputParameters[1];
            int x = inputParameters[2];
            
            int[] inputIntegers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> elements = new Queue<int>();
            
            for (int i = 0; i < n; i++)
            {
                elements.Enqueue(inputIntegers[i]);
            }
            
            for (int i = 0; i < s; i++)
            {
                elements.Dequeue();
            }

            if (elements.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                if (elements.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(elements.Min());
                }
            }
        }
    }
}