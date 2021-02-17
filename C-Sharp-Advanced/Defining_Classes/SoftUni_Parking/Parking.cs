using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            cars = new List<Car>();
            this.capacity = capacity;
        }

        public int Count => cars.Count;

        public string AddCar(Car car)
        {
            bool existingRegNumber = cars.Any(c => c.RegistrationNumber == car.RegistrationNumber);

            if (existingRegNumber)
            {
                return "Car with that registration number, already exists!";
            }
            else
            {
                if (cars.Count >= capacity)
                {
                    return "Parking is full!";
                }
                
                cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {
            Car car = cars.FirstOrDefault(car => car.RegistrationNumber == registrationNumber);

            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            
            cars.Remove(car);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string regsitrationNumber)
        {
            return cars.First(c => c.RegistrationNumber == regsitrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var number in RegistrationNumbers)
            {
                RemoveCar(number);
            }
        }
        
    }
}