using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            //Getting the input
            int[] inputLiquids = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int[] inputIngredients = Console.ReadLine().Split(" ", StringSplitOptions
                .RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            Queue<int> liquids = new Queue<int>(inputLiquids);
            Stack<int> ingredients = new Stack<int>(inputIngredients);

            SortedDictionary<string, int> cookedFoods = new SortedDictionary<string, int>();
            cookedFoods.Add("Bread", 0);
            cookedFoods.Add("Cake", 0);
            cookedFoods.Add("Pastry", 0);
            cookedFoods.Add("Fruit Pie", 0);
            
            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                var sum = liquids.Peek() + ingredients.Peek();

                switch (sum)
                {
                    case 25:
                        cookedFoods["Bread"] = 1;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    case 50:
                        cookedFoods["Cake"] = 1;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    case 75:
                        cookedFoods["Pastry"] = 1;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    case 100:
                        cookedFoods["Fruit Pie"] = 1;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    default:
                        liquids.Dequeue();
                        var ingredient = ingredients.Pop();
                        ingredient += 3;
                        ingredients.Push(ingredient);
                        break;
                }
            }
            
            if (cookedFoods.Count == 4 && cookedFoods.All(v => v.Value == 1))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            Console.WriteLine(PrintSequences(liquids, "Liquids"));
            Console.WriteLine(PrintSequences(ingredients, "Ingredients"));

            foreach (var pair in cookedFoods)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

        private static string PrintSequences<T>(T sequence, string content)
        where T : ICollection, IEnumerable
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append($"{content} left: ");
            
            if (sequence.Count > 0)
            {
                int counter = 0;

                foreach (var liquid in sequence)
                {
                    sb.Append($"{liquid}");
                    counter++;
                    
                    if (sequence.Count - counter > 0)
                    {
                        sb.Append(", ");
                    }
                }
            }
            else
            {
                sb.Append("none");
            }

            return sb.ToString().Trim();
        }
    }
}