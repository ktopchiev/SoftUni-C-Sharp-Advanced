using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double GainWeightPerFood => 0.30;

        public override string ProduceSound()
        {
            return "Meow";
        }

        protected override void ValidateFood(Food food)
        {
            if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Meat")
            {
                InvalidFoodException(food);
            }
        }
    }
}
