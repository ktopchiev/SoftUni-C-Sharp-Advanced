using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        protected override double GainWeightPerFood => 0.40;

        public override string ProduceSound()
        {
            return "Woof!";
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
