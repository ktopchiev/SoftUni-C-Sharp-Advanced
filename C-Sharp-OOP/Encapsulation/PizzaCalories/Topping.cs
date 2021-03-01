using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double baseCalories = 2;
        private const double meat = 1.2;
        private const double veggies = 0.8;
        private const double cheese = 1.1;
        private const double sauce = 0.9;
        private double weight;
        private string toppingType;
        private const string INVALID_WEIGHT = "{0} weight should be in the range [1..50].";

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
                if (value >= 1 && value <= 50)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException(String.Format(INVALID_WEIGHT, this.toppingType));
                }
            }
        }

        private string ToppingType
        {
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                toppingType = value;
            }
        }

        public double GetCalories()
        {
            double toppingCalories = 0.0;

            switch (toppingType.ToLower())
            {
                case "meat":
                    toppingCalories = meat;
                    break;
                case "veggies":
                    toppingCalories = veggies;
                    break;
                case "cheese":
                    toppingCalories = cheese;
                    break;
                case "sauce":
                    toppingCalories = sauce;
                    break;
                default:
                    break;
            }

            return baseCalories * toppingCalories * weight;
        }
    }
}
