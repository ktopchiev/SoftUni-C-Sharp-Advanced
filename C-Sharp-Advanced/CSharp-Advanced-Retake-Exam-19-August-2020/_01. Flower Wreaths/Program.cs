using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            //Getting the input
            int[] lilies = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int[] roses = Console.ReadLine().Split(", ", StringSplitOptions
                .RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            Queue<int> rosesSequence = new Queue<int>(lilies);
            Stack<int> liliesSequence = new Stack<int>(roses);
            int wreaths = 0;
            int storedFlowers = 0;
            

            while (rosesSequence.Count > 0 && liliesSequence.Count > 0)
            {
                var sum = rosesSequence.Peek() + liliesSequence.Peek();
                
                if (sum == 15)
                {
                    rosesSequence.Dequeue();
                    liliesSequence.Pop();
                    wreaths += 1;
                }
                
                if (sum > 15)
                {
                    var lilie = liliesSequence.Pop();
                    lilie -= 2;
                    liliesSequence.Push(lilie);
                }

                if (sum < 15)
                {
                    storedFlowers += liliesSequence.Pop() + rosesSequence.Dequeue();
                }

            }

            if (storedFlowers >= 15)
            {
                wreaths += storedFlowers / 15;
            }
            
            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!" );
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}