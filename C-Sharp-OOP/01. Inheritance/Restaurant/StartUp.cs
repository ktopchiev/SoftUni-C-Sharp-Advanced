using System;

namespace Restaurant
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dessert dessert = new Dessert("revane",5,100,500);

            Console.WriteLine(dessert.Calories);

            Cake cake = new Cake("negarsko dupe");
            Console.WriteLine(cake.Calories);
        }
    }
}
