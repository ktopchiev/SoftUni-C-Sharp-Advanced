using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;
        private int toppingsCount => toppings.Count;

        public Pizza()
        {

        }

        public Pizza(string name)
            : this()
        {
            Name = name;
            Toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (value.Length > 15 || string.IsNullOrWhiteSpace(value) || value.Length < 1 || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public Dough Dough
        {
            set
            {
                dough = value;
            }
        }

        private List<Topping> Toppings
        {
            set
            {
                toppings = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppingsCount == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }

        public double GetTotalCalories()
        {
            double sum = 0.0;

            foreach (var topping in toppings)
            {
                sum += topping.GetCalories();
            }

            return dough.GetTotalCalories() + sum;
        }

        public int GetNumberOfToppings()
        {
            return toppingsCount;
        }
    }
}
