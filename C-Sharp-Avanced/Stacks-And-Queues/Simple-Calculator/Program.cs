using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                int firstNum = int.Parse(stack.Pop());
                string action = stack.Pop();
                int secondNum = int.Parse(stack.Pop());
                int result = 0;
                
                switch (action)
                {
                    case "+":
                        result = firstNum + secondNum;
                        stack.Push(result.ToString());
                        break;
                    case "-":
                        result = firstNum - secondNum;
                        stack.Push(result.ToString());
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}