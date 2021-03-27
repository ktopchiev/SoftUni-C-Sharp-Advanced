using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_for_names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Predicate<string> findNames = names => names.Length <= n;
            List<string> names = new List<string>();
            
            Console.WriteLine(string.Join("\n",
                 names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .FindAll(findNames)));
        }
    }
}