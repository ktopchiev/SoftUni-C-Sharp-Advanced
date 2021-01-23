using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_text_editor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();
            StringBuilder lastErasedStr = new StringBuilder();
            
            Stack<string> lastDoneCommand = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{text.ToString()} - {n - i} operations left");
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commands.Length > 0 && commands.Length < 3)
                {
                    string command = commands[0];

                    if (command == "1" && commands.Length > 1)
                    {
                        AppendString(command, commands[1], lastDoneCommand, text);
                    }
                    else if (commands.Length > 1 &&
                             command == "2" &&
                             text.Length >= int.Parse(commands[1]) &&
                             int.Parse(commands[1]) >= 0)
                    {
                        EraseLastElements(commands[1], command, text, lastErasedStr, lastDoneCommand);
                    }
                    else if (commands.Length > 1 && 
                             command == "3" && 
                             text.Length >= int.Parse(commands[1]) &&
                             int.Parse(commands[1]) > 0)
                    {
                        PrintElementAt(commands[1], text);
                    }
                    else if (command == "4" && lastDoneCommand.Count > 1)
                    {
                        Undo(lastDoneCommand, text, lastErasedStr);
                    }
                }
            }
            
            Console.WriteLine(text.ToString());
        }
        
        //Methods
        private static void GetLastDoneCommand(Stack<string> lastDoneCommand, string command,
            string command2)
        {
            lastDoneCommand.Push($"{command}c");
            lastDoneCommand.Push(command2);
        }

        private static void AppendString(string command, string commandString, Stack<string> 
        lastDoneCommand, 
        StringBuilder text)
        {
            string str = commandString;
            text.Append(str);
            GetLastDoneCommand(lastDoneCommand, command, commandString);
        }

        private static void EraseLastElements(string commandString, string command , StringBuilder 
        text, 
        StringBuilder removedStr, Stack<string> lastDoneCommand)
        {
            int count = int.Parse(commandString);

            removedStr.Clear();

            int startIndex = text.Length - count;

            string removedText = text.ToString(startIndex, count);

            removedStr.Append(removedText);

            text.Remove(startIndex, count);

            GetLastDoneCommand(lastDoneCommand, command, commandString);
        }
        
        private static void PrintElementAt(string commandStr, StringBuilder text)
        {
            int index = int.Parse(commandStr) - 1;

            Console.WriteLine(string.Join("", text[index].ToString()));
        }
        
        private static void Undo(Stack<string> lastDoneCommand, StringBuilder text, StringBuilder
         removedStr)
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