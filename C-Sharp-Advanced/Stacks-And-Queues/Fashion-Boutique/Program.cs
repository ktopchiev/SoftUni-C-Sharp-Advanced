using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            int clothesSum = 0;

            int racksCount = 0;

            Stack<int> clothesStack = new Stack<int>(clothesInput.Reverse());

            while (clothesStack.Count > 0)
            {
                if (clothesSum == rackCapacity)
                {
                    racksCount++;
                    clothesSum = 0;
                }
                
                int checkNextPiece = clothesStack.Peek();

                if (checkNextPiece + clothesSum <= rackCapacity)
                {
                    clothesSum += clothesStack.Pop();
                    
                    if (clothesSum == rackCapacity)
                    {
                        racksCount++;
                        clothesSum = 0;
                    }
                }
                else
                {
                    racksCount++;
                    clothesSum = 0;
                }
            }

            if (clothesSum <= rackCapacity && clothesSum > 0)
            {
                racksCount++;
            }
            
            Console.WriteLine(racksCount);
        }
    }
}