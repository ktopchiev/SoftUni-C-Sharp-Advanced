using System;
using System.Collections.Generic;

namespace Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            
            for (int i = 0; i < n; i++)
            {
                string[] carInfoInput =
                    Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string modelInput = carInfoInput[0];
                double fuelAmountInput = double.Parse(carInfoInput[1]);
                double fuelConsumptionInput = double.Parse(carInfoInput[2]);

                Car newCar = new Car(modelInput, fuelAmountInput, fuelConsumptionInput);
                
                cars.Add(newCar);
            }

            while (true)
            {
                string[] driveCommand =
                    Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (driveCommand[0] == "End")
                {
                    foreach (var car in cars)
                    {
                        string model = car.Model;
                        double fuelAmount = car.FuelAmount;
                        double distanceTraveled = car.TravelledDistance;

                        Console.WriteLine($"{model} {fuelAmount:f2} {distanceTraveled}");
                    }
                    break;
                }
                
                if (driveCommand[0] == "Drive")
                {
                    string carModel = driveCommand[1];
                    double amountOfKm = double.Parse(driveCommand[2]);

                    Car currentCar = cars.Find(x => x.Model == carModel);
                    
                    currentCar.Drive(amountOfKm);
                }

            }
        }
    }
}