using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> myListyIterator = new ListyIterator<string>();
            
            List<string> command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            if (command.Count == 0)
            {
                myListyIterator = new ListyIterator<string>();
            }
                
            if (command[0] == "Create")
            {
                command.RemoveAt(0);
                myListyIterator = new ListyIterator<string>(command);
            }

            while (true)
            {
                command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (command[0] == "END")
                {
                    break;
                }
                
                if (command[0] == "Move")
                {
                    Console.WriteLine(myListyIterator.Move());
                }
                else if (command[0] == "Print")
                {
                    myListyIterator.Print();
                }
                else if (command[0] == "HasNext")
                {
                    Console.WriteLine(myListyIterator.HasNext());
                }
            }
        }
    }
}