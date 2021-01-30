﻿using System;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public void Drive(double distance)
        {
            double consumedFuel = fuelQuantity - (distance * fuelConsumption);

            if (consumedFuel >= 0)
            {
                fuelQuantity -= (distance * fuelConsumption);
            }

            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return $@"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel:
            {this.FuelQuantity:F2}L";
        }
    }
}