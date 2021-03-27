using System;
using System.Collections.Generic;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<BaseHero> raidGroup = new List<BaseHero>();
            int createdHeroesCounter = 0;

            while(createdHeroesCounter < n)
            {
                string newHeroName = Console.ReadLine().Trim();
                string newHeroType = Console.ReadLine().Trim().ToLower();

                Factory heroFactory = null;

                switch (newHeroType)
                {
                    case "druid":
                        heroFactory = new DruidFactory(newHeroName);
                        createdHeroesCounter++;
                        break;
                    case "paladin":
                        heroFactory = new PaladinFactory(newHeroName);
                        createdHeroesCounter++;
                        break;
                    case "rogue":
                        heroFactory = new RogueFactory(newHeroName);
                        createdHeroesCounter++;
                        break;
                    case "warrior":
                        heroFactory = new WarriorFactory(newHeroName);
                        createdHeroesCounter++;
                        break;
                    default:
                        break;
                }

                BaseHero hero = heroFactory.GetHero();
                raidGroup.Add(hero);
            }

            int bossPower = int.Parse(Console.ReadLine());
            double totalHeroesPower = 0;

            if (raidGroup.Count > 0)
            {
                foreach (var hero in raidGroup)
                {
                    Console.WriteLine(hero.CastAbility());
                    totalHeroesPower += hero.Power;
                }
            }
            

            if (totalHeroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
