using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption { get => fuelConsumption; protected set => fuelConsumption = value + 1.6; }

        public override string Drive(double distance)
        {
            return $"{GetType().Name} {base.Drive(distance)}";
        }

        public override void Refuel(double fuelAmountToFill)
        {
            if (fuelAmountToFill > 0)
            {
                if (fuelAmountToFill + fuelQuantity <= tankCapacity)
                {
                    fuelQuantity += fuelAmountToFill * 0.95;
                }
                else
                {
                    Console.WriteLine($"Cannot fit {fuelAmountToFill} fuel in the tank");
                }
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }
        }
    }
}
