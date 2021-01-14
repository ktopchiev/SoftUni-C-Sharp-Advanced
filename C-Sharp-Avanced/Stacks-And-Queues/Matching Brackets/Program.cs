﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            /*We are given an arithmetic expression
            with brackets (with nesting)

            Extract all sub-expressions in brackets*/
            
            string input = Console.ReadLine();

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    int startIndex = stack.Pop();
                    string contents = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(contents);
                }
            }
        }
    }
}