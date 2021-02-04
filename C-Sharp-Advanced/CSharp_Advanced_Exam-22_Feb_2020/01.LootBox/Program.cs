using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLootItems = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] secondLootItems = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            //Initializing two loot boxes
            Queue<int> firstBox = new Queue<int>();
            Stack<int> secondBox = new Stack<int>();

            //Initializing claimed items collection
            List<int> claimedItems = new List<int>();

            //Populating two loot boxes
            for (int i = 0; i < firstLootItems.Length; i++)
            {
                firstBox.Enqueue(firstLootItems[i]);
            }

            for (int i = 0; i < secondLootItems.Length; i++)
            {
                secondBox.Push(secondLootItems[i]);
            }

            while (true)
            {
                if (firstBox.Count == 0 || secondBox.Count == 0)
                {
                    if (firstBox.Count == 0)
                    {
                        Console.WriteLine("First lootbox is empty");
                    }
                    else if (secondBox.Count == 0)
                    {
                        Console.WriteLine("Second lootbox is empty");
                    }

                    break;
                }

                int sumOfItems = firstBox.Peek() + secondBox.Peek();

                if (sumOfItems % 2 == 0)
                {
                    claimedItems.Add(sumOfItems);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            int qualityOfClaimedItems = claimedItems.Sum();

            if (qualityOfClaimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {qualityOfClaimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {qualityOfClaimedItems}");
            }

        }
    }
}
