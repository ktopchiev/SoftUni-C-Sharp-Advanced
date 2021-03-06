﻿using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family myFamily = new Family();
            
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                Person newPerson = new Person(age, name);
                
                myFamily.AddMember(newPerson);
            }

            var adultMembers = myFamily.GetOlderThanThirtyMembers();

            foreach (var adult in adultMembers.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{adult.Name} - {adult.Age}");
            }

        }
    }
}