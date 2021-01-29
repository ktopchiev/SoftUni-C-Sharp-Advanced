using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] ordersInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(ordersInput);

            if (orders.Any())
            {
                Console.WriteLine(orders.Max());   
            }

            while (true)
            {
                if (orders.Count == 0)
                {
                    Console.WriteLine("Orders complete");
                    break;
                }
                else if (foodQuantity <= 0 && orders.Count >= 0)
                {
                    Console.WriteLine($"Orders left: {string.Join(", ", orders)}");
                    break;
                }

                if (orders.Count > 0)
                {
                    if (orders.Peek() <= foodQuantity)
                    {
                        foodQuantity -= orders.Dequeue();   
                    }
                    else
                    {
                        Console.WriteLine($"Orders left: {string.Join(", ", orders)}");
                        break;
                    }
                }
            }
        }
    }
}