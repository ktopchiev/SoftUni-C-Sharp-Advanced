using System;
using System.Collections.Generic;

namespace _01.Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string usernameInput = Console.ReadLine();

                usernames.Add(usernameInput);
            }

            foreach (var username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}