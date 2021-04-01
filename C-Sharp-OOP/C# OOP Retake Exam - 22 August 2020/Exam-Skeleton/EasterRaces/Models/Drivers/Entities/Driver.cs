using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private string name;
        private ICar car;
        private bool canParticipate;
        private const int NameLength = 5;

        public Driver(string name)
        {
            Name = name;
            CanParticipate = false;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (value != null && value != "" && value.Length >= NameLength)
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName, value, NameLength));
                }
            }
        }

        public ICar Car
        {
            get => car;

            private set
            {
                if (value != null)
                {
                    car = value;
                    CanParticipate = true;
                }
                else
                {
                    throw new ArgumentException(ExceptionMessages.CarInvalid);
                }
            }
        }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get => canParticipate;

            private set
            {
                canParticipate = value;
            }
        }

        public void AddCar(ICar car)
        {
            Car = car;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
