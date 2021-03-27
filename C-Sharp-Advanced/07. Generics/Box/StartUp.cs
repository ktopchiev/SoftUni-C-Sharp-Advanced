using System;

namespace Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();
                Box<string> newBox = new Box<string>(str);
                Console.WriteLine(newBox.ToString());
            }
        }
    }
}