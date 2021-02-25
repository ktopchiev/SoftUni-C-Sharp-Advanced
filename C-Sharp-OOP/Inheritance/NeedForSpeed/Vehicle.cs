﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            DefaultFuelConsumption = 1.25;
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public double DefaultFuelConsumption { get; set; }
        public virtual double FuelConsumption { get; set;}
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            double consumedFuel = kilometers * DefaultFuelConsumption;
            Fuel -= consumedFuel;
        }

    }
}
