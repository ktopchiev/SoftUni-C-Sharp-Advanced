using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            :base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption { get => fuelConsumption; protected set => fuelConsumption = value; }

        public string DriveFull(double distance)
        {
            fuelConsumption += 1.4;
            var drive = base.Drive(distance);
            fuelConsumption -= 1.4;
            return $"{GetType().Name} {drive}";
        }

        public override string Drive(double distance)
        {
            return $"{GetType().Name} {base.Drive(distance)}";
        }
    }
}
