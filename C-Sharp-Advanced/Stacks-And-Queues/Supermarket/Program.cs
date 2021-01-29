using System;
using System.Collections.Generic;

namespace Supermarket
{
    /*
             * Reads an input consisting of a name and adds it to a queue until "End" is received.
        If you receive "Paid", print every customer name and empty the queue, otherwise we receive 
        a client and we have to add him to the queue. When we receive "End" 
        we have to print the count of the remaining people in the queue in the format: "{count} people
        remaining.".
     */
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();
            
            string input = Console.ReadLine();

            while (input != "End")
            {
                if (input == "Paid")
                {
                    while (names.Count > 0)
                    {
                        Console.WriteLine(names.Dequeue());
                    }
                }
                else if (input != "End")
                {
                    names.Enqueue(input);   
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}