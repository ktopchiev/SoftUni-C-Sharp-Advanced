using System.Collections.Generic;

namespace RawData
{
    public class Car
    {
        //Properties made of other classes
        public string Model { get; }
        public Engine Engine { get; }
        public Cargo Cargo { get; }
        public List<Tire> Tires { get; }
        
        //Constructor
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string 
        cargoType, string[] tiresInitialData)
        {
            Model = model;
            Engine = new Engine(engineSpeed,enginePower);
            Cargo = new Cargo(cargoWeight, cargoType);
            Tires = new List<Tire>();
            //Add tires data from array to list of tires
            AddTires(tiresInitialData);
        }

        private void AddTires(string[] tiresInitialData)
        {
            //Input for the tires data is always in format: {tire(n)Pressure} {tire(n)Age}
            for (int i = 0; i < tiresInitialData.Length; i+= 2)
            {
                double pressure = double.Parse(tiresInitialData[i]);
                int age = int.Parse(tiresInitialData[i + 1]);
                Tires.Add(new Tire(pressure, age));
            }
        }
    }
}