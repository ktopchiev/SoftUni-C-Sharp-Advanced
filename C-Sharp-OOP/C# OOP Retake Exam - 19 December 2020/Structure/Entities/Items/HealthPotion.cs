using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int _weight = 5;
        private const int healPoints = 20;

        public HealthPotion()
            : base(_weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            var health = character.Health;

            health += healPoints;

            if (health > character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
            else
            {
                character.Health = health;
            }
        }
    }
}
