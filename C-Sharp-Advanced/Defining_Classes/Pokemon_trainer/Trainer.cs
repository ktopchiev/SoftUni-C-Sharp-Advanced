using System.Collections.Generic;

namespace Pokemon_trainer
{
    public class Trainer
    {
        public string Name { get; set; }
        private int badges;
        public List<Pokemon> Pokemons { get; set; }

        public Trainer(string name)
        {
            Name = name;
            badges = 0;
            Pokemons = new List<Pokemon>();
        }

        public void AddToBadge()
        {
            badges += 1;
        }

        public int GetBadges()
        {
            return badges;
        }

        public void AttackPokemons()
        {
            foreach (var pokemon in Pokemons)
            {
                pokemon.Health -= 10;
            }
        }
    }
}