using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;
        public int Count => data.Count;
        
        
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        
        public void Add(Racer racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(racer);
            }
        }
        
        public bool Remove(string name)
        {
            bool Car(Racer x) => x.Name == name;

            bool isRemoved = data.Any(Car);

            data.RemoveAll(Car);
            
            return isRemoved;
        }
        
        public Racer GetOldestRacer()
        {
            if (data.Count == 0)
            {
                return null;
            }
            
            return data.OrderByDescending(x => x.Age).First();
        }
        
        public Racer GetRacer(string name)
        {
            bool Car(Racer x) => x.Name == name;

            if (data.Exists(Car))
            {
                return data.FirstOrDefault(Car);
            }
            
            return null;
        }

        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(racer => racer.Car.Speed).First();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Racers participating at {Name}:").AppendLine();

            foreach (var racer in data)
            {
                sb.Append(racer).AppendLine();
            }

            return sb.ToString().Trim();
        }
    }
}