using System;

namespace CarManufacturer
{
    public class Car
    {
        //Fields
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        
        //Constructors
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
        : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
        : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        
        //Properties
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
    }
}