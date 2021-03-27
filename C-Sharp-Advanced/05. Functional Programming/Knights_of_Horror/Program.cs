using System;
using System.Collections.Generic;
using System.Linq;

namespace Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            //Print names with "Sir" in the beginning
            List<string> names = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<List<string>> print = message =>
                Console.WriteLine(string.Join("\n", message
                    .Select(name => name.Insert(0, "Sir "))));

            print(names);
        }
    }
}