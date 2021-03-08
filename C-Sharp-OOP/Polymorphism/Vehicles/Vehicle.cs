using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected double fuelQuantity;
        protected double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        { 
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get => fuelQuantity; private set => fuelQuantity = value; }

        public abstract double FuelConsumption { get; protected set; }

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
            fuelQuantity += fuel;
        }
    }
}
