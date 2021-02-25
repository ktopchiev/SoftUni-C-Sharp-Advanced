using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public const double grams = 250;
        public const double calories = 1000;

        public Cake(string name)
            : base(name, 0, 0, 0)
        {
            
        }

        private decimal CakePrice { get; set; } = 5;

        public override double Grams { get => grams; }

        public override double Calories { get => calories; }

        public override decimal Price { get => CakePrice; }
    }
}
