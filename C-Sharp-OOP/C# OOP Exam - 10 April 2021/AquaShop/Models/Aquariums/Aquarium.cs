using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => Decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => decorations;

        public ICollection<IFish> Fish => fish;

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (Fish.Count >= Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            Fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            string fishInfo;

            if (Fish.Count == 0)
            {
                fishInfo = "none";
            }
            else
            {
                fishInfo = string.Join(", ", Fish.Select(x => x.Name));
            }

            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):")
              .AppendLine($"Fish: {fishInfo}")
              .AppendLine($"Decorations: {this.Decorations.Count}")
              .AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();

        }

        public bool RemoveFish(IFish fish)
        {
            return Fish.Remove(fish);
        }
    }
}