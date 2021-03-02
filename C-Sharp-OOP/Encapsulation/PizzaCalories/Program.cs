using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = new Pizza();

            while (true)
            {
                string[] inputCommands = Console.ReadLine().Split(" ");

                if (inputCommands[0] == "END")
                {
                    Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories():f2} Calories.");
                    break;
                }

                string type , bakingTech;
                double weight;

                Dough dough;
                Topping topping;

                try
                {
                    switch (inputCommands[0])
                    {
                        case "Dough":
                            type = inputCommands[1];
                            bakingTech = inputCommands[2];
                            weight = double.Parse(inputCommands[3]);
                            dough = new Dough(weight, type, bakingTech);
                            pizza.Dough = dough;
                            break;
                        case "Topping":
                            type = inputCommands[1];
                            weight = double.Parse(inputCommands[2]);
                            topping = new Topping(type, weight);
                            pizza.AddTopping(topping);
                            break;
                        case "Pizza":
                            string name = inputCommands[1];
                            pizza = new Pizza(name);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                    when(ex is ArgumentException || ex is InvalidOperationException)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }
    }
}
