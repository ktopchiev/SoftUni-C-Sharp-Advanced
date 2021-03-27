using System;

namespace Speed_Racing
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }

        public void Drive(double amountOfKm)
        {
            double currentConsumption = amountOfKm * FuelConsumptionPerKilometer;

            if (currentConsumption <= FuelAmount)
            {
                TravelledDistance += amountOfKm;
                FuelAmount -= currentConsumption;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}