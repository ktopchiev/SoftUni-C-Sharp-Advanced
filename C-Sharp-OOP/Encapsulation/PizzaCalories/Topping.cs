using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double MinRange = 1;
        private const double MaxRange = 50;
        private const double BaseCalories = 2;
        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce= 0.9;

        private double weight;
        private string toppingType;

        public Topping()
        {

        }

        public Topping(string toppingType, double weight)
            :this()
        {
            ToppingType = toppingType;
            Weight = weight;
        }

        private double Weight
        {
            set
            {
                Validator.ThrowIfNumberIsNotInRange(MinRange,
                    MaxRange,
                    value,
                    $"{toppingType} weight should be in range [{MinRange}..{MaxRange}].");
                
                weight = value;
            }
        }

        private string ToppingType
        {
            set
            {
                Validator.ThrowIfValueIsNotAllowed(new HashSet<string>{ "meat", "cheese", "veggies", "sauce"},
                    value.ToLower(),
                    $"Cannot place {value} on top of your pizza.");

                toppingType = value;
            }
        }

        public double GetCalories()
        {
            double toppingCalories = 0.0;

            switch (toppingType.ToLower())
            {
                case "meat":
                    toppingCalories = Meat;
                    break;
                case "veggies":
                    toppingCalories = Veggies;
                    break;
                case "cheese":
                    toppingCalories = Cheese;
                    break;
                case "sauce":
                    toppingCalories = Sauce;
                    break;
                default:
                    break;
            }

            return BaseCalories * toppingCalories * weight;
        }
    }
}
