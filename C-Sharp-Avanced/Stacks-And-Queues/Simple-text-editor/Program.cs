using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_text_editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();
            StringBuilder removedStr = new StringBuilder();
            
            Stack<string> lastDoneCommand = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                //Console.WriteLine($" {text.ToString()} - {n - i} operations left");
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commands.Length > 0 && commands.Length < 3)
                {
                    string command = commands[0];

                    if (command == "1" && commands.Length > 1)
                    {
                        string str = commands[1];
                        text.Append(str);

                        GetLastDoneCommand(lastDoneCommand, command, commands[1]);
                    }
                    else if (commands.Length > 1 && command == "2" &&
                             text.Length >= int.Parse(commands[1]) && int
                                 .Parse
                                     (commands[1]) >= 0)
                    {
                        int count = int.Parse(commands[1]);

                        removedStr.Clear();

                        int startIndex = text.Length - count;

                        string removedText = text.ToString(startIndex, count);

                        removedStr.Append(removedText);

                        text.Remove(startIndex, count);

                        GetLastDoneCommand(lastDoneCommand, command, commands[1]);

                    }
                    else if (commands.Length > 1 && command == "3" && text.Length >= int.Parse(commands[1]) && int
                    .Parse
                        (commands[1]) > 0)
                    {
                        int index = int.Parse(commands[1]) - 1;

                        Console.WriteLine(string.Join("", text[index].ToString()));
                    }
                    else if (command == "4" && lastDoneCommand.Count > 1)
                    {
                        if (lastDoneCommand.Peek() != "1c" && lastDoneCommand.Peek() != "2c")
                        {
                            string str = lastDoneCommand.Pop();

                            if (lastDoneCommand.Peek() == "1c")
                            {
                                lastDoneCommand.Pop();
                                int index = text.Length - str.Length;

                                text.Remove(index, str.Length);
                            }
                            else if (lastDoneCommand.Peek() == "2c")
                            {
                                lastDoneCommand.Pop();
                                text.Append(removedStr);
                            }
                        }
                    }
                }
            }
            
            //Console.WriteLine(text.ToString());
        }

        private static void GetLastDoneCommand(Stack<string> lastDoneCommand, string command,
            string command2)
        {
            lastDoneCommand.Push($"{command}c");
            lastDoneCommand.Push(command2);
        }
    }
}