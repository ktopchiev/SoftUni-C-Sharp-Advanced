using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Get the input
            var inputPersons = Console.ReadLine().Split(";");
            var inputProducts = Console.ReadLine().Split(";");

            Dictionary<string, int> peopleData = GetData(inputPersons);
            Dictionary<string, int> productsData = GetData(inputProducts);

            List<Person> peopleList = new List<Person>();
            List<Product> productsList = new List<Product>();

            bool exception = false;

            //Fill lists with persons and products
            foreach (var person in peopleData)
            {
                try
                {
                    Person newPerson = new Person(person.Key, person.Value);
                    peopleList.Add(newPerson);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }   
            }

            foreach (var product in productsData)
            {
                try
                {
                    Product newProduct = new Product(product.Key, product.Value);
                    productsList.Add(newProduct);
                }
                catch (Exception ex)
                { 
                    Console.WriteLine(ex.Message);
                    break;
                }
                
            }

            
            

            //Buying products
            if (exception == false)
            {
                peopleList = BuyProducts(peopleList, productsList);
            }

            PrintList(peopleList);
            
        }

        private static Dictionary<string,int> GetData(string[] inputData)
        {
            Dictionary<string, int> newDictionary = new Dictionary<string, int>();

            foreach (var item in inputData)
            {
                Regex regex = new Regex(@"([A-z])\w+");
                MatchCollection name = regex.Matches(item);

                Regex rgx = new Regex(@"\d+");
                MatchCollection number = rgx.Matches(item);

                if (name.Count != 0 && number.Count != 0)
                {
                    newDictionary.Add(name[0].ToString(), int.Parse(number[0].ToString()));
                }
                else if (name.Count == 0)
                {
                    newDictionary.Add(" ", 0);
                }
                
            }

            return newDictionary;
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
                        break;
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
                sb.Append($"{person.Name.Trim()} - ");

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

                    sb.AppendLine();
                }
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
