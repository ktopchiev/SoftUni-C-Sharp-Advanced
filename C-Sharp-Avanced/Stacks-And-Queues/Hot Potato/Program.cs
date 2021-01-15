﻿using System;
using System.Collections.Generic;

namespace Hot_Potato
{   
    /*Hot potato is a game in which children form a circle and start passing a hot potato. The counting starts
    with the fist kid. Every n th toss the child left with the potato leaves the game. When a kid leaves the game, it
    passes the potato along. This continues until there is only one kid left.
    Create a program that simulates the game of Hot Potato. Print every kid that is removed from the circle. In the
    end, print the kid that is left last.*/
    
    class Program
    {
        static void Main(string[] args)
        {
            var children = Console.ReadLine().Split(' ');

            var number = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(children);

            while (queue.Count != 1) {

                for (int i = 1; i < number; i++) {

                    queue.Enqueue(queue.Dequeue());

                }

                Console.WriteLine($"Removed {queue.Dequeue()}");

            }

            Console.WriteLine($"Last in {queue.Dequeue()}");
        }
    }
}