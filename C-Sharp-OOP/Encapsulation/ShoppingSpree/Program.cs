using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Get the input
            var people = Console.ReadLine().Split(new [] {';', '='}, StringSplitOptions.RemoveEmptyEntries);
            var products = Console.ReadLine().Split(new[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            Queue<string> peopleQ = new Queue<string>(people);
            Queue<string> productsQ = new Queue<string>(products);

            List<Person> peopleList = new List<Person>();
            List<Product> productsList = new List<Product>();

            bool exception = false;

            //Fill lists with people and products
            while(peopleQ.Count > 0 && exception == false)
            { 
                try
                {   
                    var isDigit = 0.0;
                    var name = double.TryParse(peopleQ.Peek(), out isDigit) ? null : peopleQ.Dequeue();
                    var money = peopleQ.Count > 0 ? double.Parse(peopleQ.Dequeue()) : 0;

                    Person newPerson = new Person(name, money);
                    peopleList.Add(newPerson);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    exception = true;
                }
            }

            while(productsQ.Count > 0 && exception == false)
            {
                try
                {
                    var isDigit = 0.0;
                    var product = double.TryParse(productsQ.Peek(), out isDigit) ? null : productsQ.Dequeue();
                    var cost = productsQ.Count > 0 ? double.Parse(productsQ.Dequeue()) : 0;

                    Product newProduct = new Product(product, cost);

                    productsList.Add(newProduct);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    exception = true;
                }
            }

            //Buying products
            if (exception == false)
            {
                peopleList = BuyProducts(peopleList, productsList);
            }

            PrintList(peopleList);
            
        }


        private static List<Person> BuyProducts(List<Person> peopleList, List<Product> productsList)
        {
            while (true)
            {
                var buyingCommand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (buyingCommand[0] == "END")
                {
                    break;
                }

                var person = buyingCommand[0];
                var productToPurchase = buyingCommand[1];

                var currentPerson = peopleList.FirstOrDefault(p => p.Name == person);
                var currentProduct = productsList.FirstOrDefault(p => p.Name == productToPurchase);

                if (currentPerson != null && currentProduct != null)
                {
                    try
                    {
                        currentPerson.AddProductToBag(currentProduct);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return peopleList;
        }

        private static void PrintList(List<Person> peopleList)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var person in peopleList)
            {
                sb.Append($"{person.Name} - ");

                if (person.BagOfProducts.Count == 0)
                {
                    sb.Append("Nothing bought").AppendLine();
                }
                else
                {
                    var counter = 0;

                    foreach (var product in person.BagOfProducts)
                    {
                        counter++;
                        if (counter == person.BagOfProducts.Count)
                        {
                            sb.Append($"{product.Name}");
                        }
                        else
                        {
                            sb.Append($"{product.Name}, ");
                        }
                    }
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
