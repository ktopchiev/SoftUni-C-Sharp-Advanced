using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {

        public Mouse(string name, double weight, string livingRegion)
            :base(name,weight,livingRegion)
        {
        }

        protected override double GainWeightPerFood => 0.10;

        public override string ProduceSound()
        {
            return "Squeak";
        }

        protected override void ValidateFood(Food food)
        {
            if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Fruit")
            {
                InvalidFoodException(food);
            }
        }
    }
}
