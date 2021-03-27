using System;
using System.Collections.Generic;

namespace Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");

            Queue<string> songsQueue = new Queue<string>(songs);

            while (songsQueue.Count > 0)
            {
                string[] commandInput = Console.ReadLine().Split();

                string command = commandInput[0];

                if (command == "Play")
                {
                    songsQueue.Dequeue();
                }
                else if (command == "Add")
                {
                    string songName = string.Join(" ", commandInput).Substring(4);

                    if (!songsQueue.Contains(songName))
                    {
                        songsQueue.Enqueue(songName);
                    }
                    else
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}