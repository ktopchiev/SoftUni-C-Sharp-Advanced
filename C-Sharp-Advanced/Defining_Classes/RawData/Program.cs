using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            
            //Fill list of cars with information about them
            for (int i = 0; i < n; i++)
            {
                string[] carInfoInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfoInput[0];
                int engineSpeed = int.Parse(carInfoInput[1]);
                int enginePower = int.Parse(carInfoInput[2]);
                int cargoWeight = int.Parse(carInfoInput[3]);
                string cargoType = carInfoInput[4];
                
                //Get the tires data into array
                string[] tiresInitialData = new string[8];
                for (int j = 0; j < tiresInitialData.Length; j++)
                {
                    tiresInitialData[j] = carInfoInput[5 + j];
                }
                
                //Initialize new car and add it to the list of cars
                Car newCar = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tiresInitialData);
                cars.Add(newCar);
            }
            
            //After data processing get the final command results
            string finalCommand = Console.ReadLine().ToLower();

            switch (finalCommand)
            {
                case "fragile":
                    foreach (var car in cars.Where(x => x.Cargo.Type == "fragile"))
                    {
                        bool lowPressure = car.Tires.Any(x => x.Pressure < 1);
                        
                        if (lowPressure)
                        {
                            Console.WriteLine(car.Model);
                        }
                    }
                    break;
                case "flamable":
                    foreach (var car in cars.Where(x => x.Cargo.Type == "flamable"))
                    {
                        if (car.Engine.Power > 250)
                        {
                            Console.WriteLine(car.Model);
                        }
                    }
                    break;
            }
        }
    }
}