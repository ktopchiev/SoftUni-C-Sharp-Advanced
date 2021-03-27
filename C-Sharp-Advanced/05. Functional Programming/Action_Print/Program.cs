using System;
using System.Collections.Generic;
using System.Linq;

namespace Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
            Action<List<string>> print = message => Console.WriteLine(string.Join("\n",message));
            print(names);
        }
    }
}