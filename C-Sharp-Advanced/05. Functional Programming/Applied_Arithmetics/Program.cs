using System;
using System.Collections.Generic;
using System.Linq;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            Func<List<int>, List<int>> add = AddToList;
            Func<List<int>, List<int>> multiply = MultiplyList;
            Func<List<int>, List<int>> subtract = SubtractList;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }
                
                switch (command)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                }
            }
        }

        static List<int> AddToList(List<int> numbers)
        {
            List<int> raisedNums = numbers.Select(x => x += 1).ToList();
            return raisedNums;
        }

        static List<int> MultiplyList(List<int> numbers)
        {
            List<int> multipliedNums = numbers.Select(x => x *= 2).ToList();
            return multipliedNums;
        }
        
        static List<int> SubtractList(List<int> numbers)
        {
            List<int> subtractedNums = numbers.Select(x => x -= 1).ToList();
            return subtractedNums;
        }
    }
}