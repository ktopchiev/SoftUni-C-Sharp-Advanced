using System;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack<int> myCustomStack = new CustomStack<int>();

            while (true)
            {
               string[] commands = Console.ReadLine().Split(new []{" ",", " }, StringSplitOptions.RemoveEmptyEntries);

               if (commands[0] == "END")
               {
                   break;
               }
                
               switch (commands[0])
                {
                    case "Push":
                    {
                        for (int i = 1; i < commands.Length; i++)
                        {
                            myCustomStack.Push(int.Parse(commands[i]));
                        }

                        break;
                    }
                    case "Pop":
                        myCustomStack.Pop();
                        break;
                }
            }

            foreach (var element in myCustomStack)
            {
                Console.WriteLine(element);
            }
            
            foreach (var element in myCustomStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}