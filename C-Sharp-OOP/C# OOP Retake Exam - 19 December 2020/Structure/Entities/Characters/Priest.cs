using System;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        //name,health,armor,abilityPoints,bag
        public Priest(string name)
            : base(name, 50, 25, 40, new Backpack())
        {
        }

        public void Heal(Character character)
        {

            EnsureAlive();

            if (character.IsAlive && IsAlive)
            {
                character.Health += AbilityPoints;
            }

        }
    }
}
