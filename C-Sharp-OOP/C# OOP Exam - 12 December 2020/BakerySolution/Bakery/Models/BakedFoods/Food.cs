using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Messages;
using System;

namespace Bakery.Models.BakedFoods
{
    public abstract class Food : IBakedFood
    {
        private string name;
        private int portion;
        private decimal price;

        public Food(string name, int portion, decimal price)
        {
            Name = name;
            Portion = portion;
            Price = price;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }
                else
                {
                    name = value;
                }
            }
        }

        public int Portion
        {
            get => portion;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPortion);
                }

                portion = value;
            }
        }

        public decimal Price
        {
            get => price;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }

                price = value;
            }
        }

        public override string ToString()
        {
            return $"{Name}: {Portion}g - {Price:f2}";
        }
    }
}
