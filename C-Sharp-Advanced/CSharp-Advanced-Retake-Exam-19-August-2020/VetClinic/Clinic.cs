using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public int Capacity { get; set; }
        private List<Pet> pets;
        public int Count => pets.Count;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            pets = new List<Pet>(capacity);
        }

        public void Add(Pet pet)
        {
            if (pets.Count < Capacity)
            {
                pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = pets.FirstOrDefault(p => p.Name == name);
            if (pet == null)
            {
                return false;
            }

            pets.Remove(pet);
            return true;
        }

        public Pet GetOldestPet()
        {
            return pets.OrderByDescending(x => x.Age).First();
        }

        public Pet GetPet(string name, string owner)
        {
            bool Pet(Pet x) => x.Name == name && x.Owner == owner;
            
            return !pets.Exists(Pet) ? null : pets.FirstOrDefault(Pet);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"The clinic has the following patients:").AppendLine();

            foreach (var pet in pets)
            {
                sb.Append($"Pet {pet.Name} with owner: {pet.Owner}");
                sb.Append(Environment.NewLine);
            }

            return sb.ToString().Trim();
        }
        
    }
}