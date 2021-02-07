using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            List<string> myList = new List<string>();
            
            for (int i = 1; i <= n; i++)
            {
                myList.Add(Console.ReadLine().Trim());
            }

            Box<string> myBox = new Box<string>(myList);
            string itemForSearch = Console.ReadLine().Trim();

            Console.WriteLine(myBox.CountString(itemForSearch));
        }
    }
}