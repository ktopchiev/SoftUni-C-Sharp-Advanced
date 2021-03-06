﻿using System;
using System.Collections.Generic;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Stack<string> reversedStr = new Stack<string>();

            foreach (var ch in input)
            {
                reversedStr.Push(ch.ToString());
            }

            while (reversedStr.Count > 0)
            {
                Console.Write(reversedStr.Pop());
            }
        }
    }
}