using System;
using System.Linq;

namespace Froggy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] stonesInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            Lake<int> newLake = new Lake<int>(stonesInput);
            
            newLake.Print();
        }
    }
}