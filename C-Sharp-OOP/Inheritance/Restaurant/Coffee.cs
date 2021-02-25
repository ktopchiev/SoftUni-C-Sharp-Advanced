using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
     
        public Coffee(string name, double caffeine)
            : base(name, 0, 0)
        {
            Caffeine = caffeine;
        }

        private double CoffeeMililiters { get; set; } = 50;
        private decimal CoffeePrice { get; set; } = 3.5M;
        public double Caffeine { get; set; }

        public override double Mililiters { get => CoffeeMililiters; }

        public override decimal Price { get => CoffeePrice; }
    }
}
