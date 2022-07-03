using System;
using System.Collections.Generic;
using System.Linq;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            
            

            Console.WriteLine(String.Join(" ", numbers));

            return;

            List<Animal> animals = new List<Animal>();

            string input;

            int counter = 0;

            Animal animal = null;
            Food food = null;

            while ((input = Console.ReadLine()) != "End")
            {
                if (counter % 2 == 0)
                {
                    animal = AnimalFactory.Create(input.Split(" ", StringSplitOptions.RemoveEmptyEntries));
                    animals.Add(animal);
                    Console.WriteLine(animal.ProduceSound());
                }
                else
                {
                    food = FoodFactory.Create(input.Split(" ", StringSplitOptions.RemoveEmptyEntries));

                    try
                    {
                        animal.Feed(food);
                    }
                    catch (ArgumentException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }

                counter++;

            }

            animals.ForEach(Console.WriteLine);
        }
    }
}
