using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private int minHorsePower;
        private int maxHorsePower;

        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            Model = model;
            this.cubicCentimeters = cubicCentimeters;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            HorsePower = horsePower;
        }

        public string Model
        {
            get => model;

            private set
            {
                if (value != null && value != " " && value.Length >= 4)
                {
                    model = value;
                }
                else
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidModel, value, 4));
                }
            }

        }

        public int HorsePower
        {
            get => horsePower;

            private set
            {
                if (value >= minHorsePower && value <= maxHorsePower)
                {
                    horsePower = value;
                }
                else
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                }
            }
        }

        public double CubicCentimeters
        {
            get => cubicCentimeters;
        }

        public double CalculateRacePoints(int laps)
        {
            return cubicCentimeters / horsePower * laps;
        }
    }
}
