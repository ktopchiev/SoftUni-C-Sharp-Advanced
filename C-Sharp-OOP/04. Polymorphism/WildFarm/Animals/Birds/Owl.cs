﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {

        public Owl(string name, double weight, double wingSize)
            :base(name,weight,wingSize)
        {
            
        }

        protected override double GainWeightPerFood => 0.25;

        public override string ProduceSound()
        {
            return "Hoot Hoot";
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
