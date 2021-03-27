using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public abstract class Vehicle
    {
        protected double fuelQuantity;
        protected double fuelConsumption;
        protected double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;

            private set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public abstract double FuelConsumption { get; protected set; }

        public double TankCapacity
        {
            get => tankCapacity;

            private set
            {
                tankCapacity = value;
            }
        }


        public virtual string Drive(double distance)
        {

            if (distance * fuelConsumption <= fuelQuantity && distance >= 0)
            {
                fuelQuantity -= distance * fuelConsumption;
                return $"travelled {distance} km";
            }

            return "needs refueling";
        }

        public virtual void Refuel(double fuelAmountToFill)
        {

            if (fuelAmountToFill > 0)
            {
                if (fuelAmountToFill + fuelQuantity <= tankCapacity)
                {
                    fuelQuantity += fuelAmountToFill;
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

        public override string ToString()
        {
            return $"{GetType().Name}: {fuelQuantity:F2}";
        }
    }
}
