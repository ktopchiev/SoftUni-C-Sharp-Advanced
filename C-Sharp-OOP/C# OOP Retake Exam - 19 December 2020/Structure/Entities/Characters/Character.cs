using System;
using System.Linq;
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
                if (value < 0 || value > BaseHealth)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.CharacterHealthInvalid, BaseHealth));
                }

                health = value;
            }
        }

        public double Armor
        {
            get => armor;

            set
            {
                if (value < 0 || value > BaseArmor)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.CharacterArmorInvalid, BaseArmor));
                }

                armor = value;
            }
        }

        public double AbilityPoints { get; set; }

        public Bag Bag { get => bag; private set => bag = value; }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            
            EnsureAlive();

            var armor = Armor;
            armor -= hitPoints;

            if (armor <= 0)
            {
                Armor = 0;
                var health = Health;
                health += armor;

                if (health <= 0)
                {
                    IsAlive = false;
                    Health = 0;
                }
                else
                {
                    Health += armor;
                }
            }
            else
            {
                Armor -= hitPoints;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();

            string name = item != null ? item.GetType().Name : "";

            var getItem = Bag.GetItem(name);

            getItem.AffectCharacter(this);
        } 
    }
}