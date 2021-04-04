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
            try
            {
                EnsureAlive();

                var armor = Armor -= hitPoints;

                if (armor <= 0)
                {
                    Armor = 0;
                    var health = Health += armor;

                    if (health <= 0)
                    {
                        IsAlive = false;
                        Health = 0;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            
        }

        public void UseItem(Item item)
        {
            try
            {
                EnsureAlive();

                var health = Health;

                if (item is HealthPotion)
                {
                    health += 20;
                    if (health > BaseHealth)
                    {
                        Health = BaseHealth;
                    }
                    else
                    {
                        Health = health;
                    }
                }
                else if (item is FirePotion)
                {
                    TakeDamage(20);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        } 
    }
}