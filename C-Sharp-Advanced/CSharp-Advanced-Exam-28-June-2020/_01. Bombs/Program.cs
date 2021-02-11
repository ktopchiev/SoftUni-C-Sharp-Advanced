using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            //Getting the input
            int[] bombEffects = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int[] bombCasings = Console.ReadLine().Split(", ", StringSplitOptions
                .RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            Queue<int> effects = new Queue<int>(bombEffects);
            Stack<int> casings = new Stack<int>(bombCasings);
            SortedDictionary<string, int> pouch = new SortedDictionary<string, int>();
            pouch.Add("Datura Bombs", 0);
            pouch.Add("Cherry Bombs", 0);
            pouch.Add("Smoke Decoy Bombs", 0);
            

            while (effects.Count > 0 && casings.Count > 0 && pouch.Any(x => x.Value < 3))
            {
                var sum = effects.Peek() + casings.Peek();

                switch (sum)
                {
                    case 40:
                        effects.Dequeue();
                        casings.Pop();
                        pouch["Datura Bombs"] += 1;
                        break;
                    case 60:
                        effects.Dequeue();
                        casings.Pop();
                        pouch["Cherry Bombs"] += 1;
                        break;
                    case 120:
                        effects.Dequeue();
                        casings.Pop();
                        pouch["Smoke Decoy Bombs"] += 1;
                        break;
                    default:
                        var casing = casings.Pop();
                        casing -= 5;
                        casings.Push(casing);
                        break;
                }
            }
            
            if (pouch.Count == 3 && pouch.All(v => v.Value >= 3))
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            Console.WriteLine(PrintSequences(effects, "Bomb Effects"));
            Console.WriteLine(PrintSequences(casings, "Bomb Casings"));

            foreach (var pair in pouch)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

        private static string PrintSequences<T>(T sequence, string content)
        where T : ICollection, IEnumerable
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append($"{content}: ");
            
            if (sequence.Count > 0)
            {
                int counter = 0;

                foreach (var material in sequence)
                {
                    sb.Append($"{material}");
                    counter++;
                    
                    if (sequence.Count - counter > 0)
                    {
                        sb.Append(", ");
                    }
                }
            }
            else
            {
                sb.Append("empty");
            }

            return sb.ToString().Trim();
        }
    }
}