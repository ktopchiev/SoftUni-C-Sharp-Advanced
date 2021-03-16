using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; set; }

        protected abstract double GainWeightPerFood { get; }

        public virtual void Feed(Food food)
        {
            ValidateFood(food);

            FoodEaten += food.Quantity;
            GainWeight();
        }

        protected void GainWeight()
        {
            Weight += GainWeightPerFood * FoodEaten;
        }
        

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}";
        }

        protected void InvalidFoodException(Food food)
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        protected abstract void ValidateFood(Food food);
    }
}
