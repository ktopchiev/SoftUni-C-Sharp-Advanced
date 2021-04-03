using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.Drinks;
using Bakery.Models.Tables.Contracts;
using Bakery.Models.Tables;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Models.Drinks.Contracts;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly List<IBakedFood> bakedFoods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;
        private decimal totalIncome = 0;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }

            drinks.Add(drink);

            return String.Format(OutputMessages.DrinkAdded, drink.Name, drink.Brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;

            switch (type)
            {
                case "Bread":
                    food = new Bread(name, price);
                    break;
                case "Cake":
                    food = new Cake(name, price);
                    break;
                default:
                    break;
            }

            bakedFoods.Add(food);

            return String.Format(OutputMessages.FoodAdded, food.Name, food.GetType().Name);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            switch (type)
            {
                case "InsideTable":
                    table = new InsideTable(tableNumber, capacity);
                    break;
                case "OutsideTable":
                    table = new OutsideTable(tableNumber, capacity);
                    break;
                default:
                    break;
            }

            tables.Add(table);

            return String.Format(OutputMessages.TableAdded, table.TableNumber);
        }

        public string GetFreeTablesInfo()
        {
            List<ITable> freeTables = tables.Where(t => t.IsReserved == false).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            return String.Format(OutputMessages.TotalIncome, totalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidTableNumber, tableNumber));
            }

            var bill = table.GetBill();
            totalIncome += bill;
            table.Clear();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {table.TableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var drink = drinks.FirstOrDefault(f => f.Name == drinkName);
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (drink == null)
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);

            return String.Format(OutputMessages.DrinkOrderSuccessful, table.TableNumber, drink.Name, drink.Brand);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var food = bakedFoods.FirstOrDefault(f => f.Name == foodName);
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (food == null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);

            return String.Format(OutputMessages.FoodOrderSuccessful, table.TableNumber, food.Name);
        }

        public string ReserveTable(int numberOfPeople)
        {
            var freeTable = tables.Where(t => t.IsReserved == false).FirstOrDefault(t => t.Capacity >= numberOfPeople);

            if (freeTable == null)
            {
                return String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            freeTable.Reserve(numberOfPeople);

            return String.Format(OutputMessages.TableReserved, freeTable.TableNumber, numberOfPeople);
        }
    }
}
