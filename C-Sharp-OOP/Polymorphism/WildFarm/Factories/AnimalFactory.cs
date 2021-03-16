using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public static class AnimalFactory
    {
        public static Animal Create(string[] args)
        {
            string type = args[0];
            Animal animal = null;

            switch (type)
            {
                case "Hen":
                    animal = new Hen(args[1], double.Parse(args[2]), double.Parse(args[3]));
                    break;
                case "Owl":
                    animal = new Owl(args[1], double.Parse(args[2]), double.Parse(args[3]));
                    break;
                case "Mouse":
                    animal = new Mouse(args[1], double.Parse(args[2]), args[3]);
                    break;
                case "Dog":
                    animal = new Dog(args[1], double.Parse(args[2]), args[3]);
                    break;
                case "Cat":
                    animal = new Cat(args[1], double.Parse(args[2]), args[3], args[4]);
                    break;
                case "Tiger":
                    animal = new Tiger(args[1], double.Parse(args[2]), args[3], args[4]);
                    break;
                default:
                    break;
            }

            return animal;
        }
    }
}
