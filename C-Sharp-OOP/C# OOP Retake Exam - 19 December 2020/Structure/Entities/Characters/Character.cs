using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;
        private Bag bag;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {   
            Name = name;
            BaseHealth = health;
            BaseArmor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
            Health = health;
            Armor = armor;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double BaseArmor { get; set; }

        public double Health
        {
            get => health;

            set
            {
                if (value > 0 || value <= BaseHealth)
                {
                    health = value;
                }
            }
        }

        public double Armor
        {
            get => armor;

            set
            {
                if (value > 0 || value <= BaseArmor)
                {
                    armor = value;
                }
            }
        }

        public double AbilityPoints { get; set; }

        public Bag Bag { get => bag; private set => bag = value; }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            if (armor >= hitPoints)
            {
                armor -= hitPoints;
            }
            else if (armor < hitPoints)
            {
                hitPoints -= armor;
                armor = 0;
                if (health > hitPoints)
                {
                    health -= hitPoints;
                }
                else
                {
                    health = 0;
                    IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();

            item.AffectCharacter(this);
        } 
    }
}