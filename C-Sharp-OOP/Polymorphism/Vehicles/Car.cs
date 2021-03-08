﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {

        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption { get => fuelConsumption; protected set => fuelConsumption = value + 0.9; }

        public override string Drive(double distance)
        {
            return $"{GetType().Name} {base.Drive(distance)}";
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);
        }
    }
}
