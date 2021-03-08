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
                fuelQuantity = (value > TankCapacity) ? 0 : value;
            }
        }

        public abstract double FuelConsumption { get; protected set; }

        public double TankCapacity { get => tankCapacity; protected set => tankCapacity = value; }


        public virtual string Drive(double distance)
        {

            if (distance * fuelConsumption <= fuelQuantity)
            {
                fuelQuantity -= distance * fuelConsumption;
                return $"travelled {distance} km";
            }

            return "needs refueling";
        }

        public virtual void Refuel(double fuel)
        {

            if (fuel > 0)
            {
                if (fuel + fuelQuantity <= tankCapacity)
                {
                    fuelQuantity += fuel;

                    if (this is Truck)
                    {
                        fuelQuantity += fuel * 0.95;
                    }
                }
                else
                {
                    Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                }
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }
        }
    }
}
