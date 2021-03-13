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
            //Console.WriteLine(fuelConsumption);
            fuelConsumption += 1.4;
            var drive = base.Drive(distance);
            //Console.WriteLine(fuelConsumption);
            fuelConsumption -= 1.4;
            //Console.WriteLine(fuelConsumption);
            return $"{GetType().Name} {drive}";
        }

        public override string Drive(double distance)
        {
            //Console.WriteLine(fuelConsumption);
            return $"{GetType().Name} {base.Drive(distance)}";
        }
    }
}
