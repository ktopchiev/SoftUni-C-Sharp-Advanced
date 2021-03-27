using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_trainer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            //Getting data
            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = input[0];

                if (trainerName == "Tournament")
                {
                    break;
                }

                if (input.Length > 3)
                {
                    string pokemonName = input[1];
                    string pokemonElement = input[2];
                    double pokemonHealth = 0;
                    
                    bool isDouble = double.TryParse(input[3], out pokemonHealth);
                    
                    Pokemon newPokemon;

                    if (trainers.All(x => x.Name != trainerName))
                    {
                        Trainer newTrainer = new Trainer(trainerName);
                        newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                        newTrainer.Pokemons.Add(newPokemon);
                        trainers.Add(newTrainer);
                    }
                    else
                    {
                        newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                        var trainer = trainers.Find(x => x.Name == trainerName);
                        trainer.Pokemons.Add(newPokemon);
                    }
                }
            }
            
            //Tournament mode
            while (true)
            {
                string elementInput = Console.ReadLine();

                if (elementInput == "End")
                {
                    break;
                }

                if (elementInput == "Fire" || elementInput == "Water" || elementInput == "Electricity")
                {
                    foreach (var trainer in trainers)
                    {
                        bool hasGivenElement = trainer.Pokemons.Any(x => x.Element == elementInput);

                        if (hasGivenElement)
                        {
                            trainer.AddToBadge();
                        }
                        else
                        {
                            trainer.AttackPokemons();
                        }

                        if (trainer.Pokemons.Count > 0)
                        {
                            trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                        }
                    }   
                }
            }

            
            foreach (var trainer in trainers.OrderByDescending(x => x.GetBadges()))
            {
                Console.Write($"{trainer.Name} {trainer.GetBadges()} {trainer.Pokemons.Count}");
                Console.WriteLine();
            }   
            
        }
    }
}