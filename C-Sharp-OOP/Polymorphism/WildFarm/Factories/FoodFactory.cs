using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public static class FoodFactory
    {
        public static Food Create(string[] args)
        {
            string type = args[0];
            Food food = null;

            switch (type)
            {
                case "Vegetable":
                    food = new Vegetable(int.Parse(args[1]));
                    break;
                case "Fruit":
                    food = new Fruit(int.Parse(args[1]));
                    break;
                case "Meat":
                    food = new Meat(int.Parse(args[1]));
                    break;
                case "Seeds":
                    food = new Seeds(int.Parse(args[1]));
                    break;
                default:
                    break;
            }

            return food;
        }
    }
}
