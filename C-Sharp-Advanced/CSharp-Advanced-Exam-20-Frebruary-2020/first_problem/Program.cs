using System;
using System.Collections.Generic;
using System.Linq;

namespace first_problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());

            int[] aragornPlatesInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> plates = new Queue<int>(aragornPlatesInput);
            Stack<int> orcsWave = new Stack<int>();

            for (int i = 1; i <= numberOfWaves; i++)
            {
                int[] orcsWaveInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (plates.Count > 0)
                {
                    orcsWave = new Stack<int>(orcsWaveInput);   
                }
                else
                {
                    break;
                }

                if (i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(newPlate);
                }

                while (orcsWave.Count > 0 && plates.Count > 0)
                {
                    int orcWarrior = orcsWave.Peek();
                    int plate = plates.Peek();

                    if (orcWarrior > plate)
                    {
                        plates.Dequeue();
                        orcsWave.Pop();
                        orcWarrior -= plate;
                        orcsWave.Push(orcWarrior);
                    }
                    else if (plate > orcWarrior)
                    {
                        orcsWave.Pop();
                        plates.Dequeue();
                        plate -= orcWarrior;

                        Queue<int> tempQueue = new Queue<int>();
                        tempQueue.Enqueue(plate);
                        
                        foreach (var value in plates)
                        {
                            tempQueue.Enqueue(value);
                        }
                        
                        plates.Clear();
                        
                        foreach (var value in tempQueue)
                        {
                            plates.Enqueue(value);
                        }
                    }
                    else if (plate == orcWarrior)
                    {
                        orcsWave.Pop();
                        plates.Dequeue();
                    }
                }
            }

            if (orcsWave.Count > 0 && plates.Count == 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.Write("Orcs left: ");
                Console.WriteLine(string.Join(", ", orcsWave));
            }
            else if (orcsWave.Count == 0 && plates.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.Write("Plates left: ");
                Console.WriteLine(string.Join(", ", plates));
            }
            
        }
    }
}