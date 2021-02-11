using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private string Type { get; }
        private int Capacity { get; }
        private List<Car> Data { get; }
        public int Count => Data.Count;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Data = new List<Car>();
        }

        public void Add(Car car)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            bool Car(Car x) => x.Manufacturer == manufacturer && x.Model == model;

            bool isRemoved = Data.Any(Car);

            Data.RemoveAll(Car);
            
            return isRemoved;
        }

        public Car GetLatestCar()
        {
            if (Data.Count == 0)
            {
                return null;
            }
            else
            {
                return Data.OrderByDescending(x => x.Year).First();
            }
        }

        public Car GetCar(string manufacturer, string model)
        {
            bool Car(Car x) => x.Manufacturer == manufacturer && x.Model == model;

            if (Data.Exists(Car))
            {
                return Data.FirstOrDefault(Car);
            }
            else
            {
                return null;
            }
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"The cars are parked in {Type}:").AppendLine();

            foreach (var car in Data)
            {
                sb.Append(car).AppendLine();
            }

            return sb.ToString().TrimEnd();
        }
        
    }
}