using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;
        private int tableNumber;
        private int capacity;
        private decimal pricePerPerson;
        private int numberOfPeople;
        private bool isReserved;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }

        public int TableNumber { get => tableNumber; private set => tableNumber = value; }

        public int Capacity
        {
            get => capacity;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get => pricePerPerson; private set => pricePerPerson = value; }

        public bool IsReserved { get => isReserved; private set => isReserved = value; }

        public decimal Price =>
                drinkOrders.Sum(x => x.Price) +
                foodOrders.Sum(x => x.Price) +
                numberOfPeople * pricePerPerson;

        public void Clear()
        {
            drinkOrders.Clear();
            foodOrders.Clear();
            numberOfPeople = 0;
            IsReserved = false;
        }

        public decimal GetBill()
        {
            return Price;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {capacity}");
            sb.AppendLine($"Price per Person: {pricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
            IsReserved = true;
        }
    }
}
