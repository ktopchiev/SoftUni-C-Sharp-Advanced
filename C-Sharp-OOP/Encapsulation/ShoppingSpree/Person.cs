using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        private List<Product> bagOfProducts;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (value == "" || value == " " || value == null)
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public double Money
        {
            get => money;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public IReadOnlyCollection<Product> BagOfProducts
        {
            get => bagOfProducts.AsReadOnly();
        }

        public void AddProductToBag(Product product)
        {
            if (product.Cost <= money)
            {
                money -= product.Cost;
                bagOfProducts.Add(product);
                Console.WriteLine($"{name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{name} can't afford {product.Name}");
            }
        }
    }
}
