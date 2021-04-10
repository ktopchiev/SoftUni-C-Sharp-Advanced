using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity;
        private readonly List<Item> items;
        private const int defaultValueOfCapacity = 100;

        public Bag(int capacity = 100)
        {
            Capacity = capacity;
            items = new List<Item>();
        }

        public int Capacity
        {
            get => this.capacity;
            set
            {
                if (value < 0 || value > defaultValueOfCapacity)
                {
                    this.capacity = defaultValueOfCapacity;
                }
                this.capacity = value;
            }
        }

        public int Load => items.Sum(item => item.Weight);

        public IReadOnlyCollection<Item> Items => items.ToList().AsReadOnly();

        public void AddItem(Item item)
        {
            if (Load + item.Weight > capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            var item = items.FirstOrDefault(item => item.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            items.Remove(item);

            return item;
        }
    }
}
