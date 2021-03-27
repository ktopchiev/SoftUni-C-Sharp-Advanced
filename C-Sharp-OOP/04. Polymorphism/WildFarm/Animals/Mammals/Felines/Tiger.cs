﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double GainWeightPerFood => 1.00;

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

        protected override void ValidateFood(Food food)
        {
            if (food.GetType().Name != "Meat")
            {
                InvalidFoodException(food);
            }
        }
    }
}
