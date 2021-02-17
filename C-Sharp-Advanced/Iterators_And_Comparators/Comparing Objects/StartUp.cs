﻿using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string[] infoInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                if (infoInput[0] == "END")
                {
                    break;
                }

                int age = int.Parse(infoInput[1]);

                people.Add(new Person(infoInput[0], age, infoInput[2]));
            }

            int nPerson = int.Parse(Console.ReadLine()) - 1;

            int notEqual = 0;
            int matches = 0;

            for (int i = 0; i < people.Count; i++)
            {
                int resultFromCompare = people[nPerson].CompareTo(people[i]);

                if (resultFromCompare == 0)
                {
                    matches++;
                    continue;
                }

                notEqual++;
            }


            if (matches <= 1)
            {
                Console.WriteLine($"No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {notEqual} {people.Count}");
            }
        }
    }
}