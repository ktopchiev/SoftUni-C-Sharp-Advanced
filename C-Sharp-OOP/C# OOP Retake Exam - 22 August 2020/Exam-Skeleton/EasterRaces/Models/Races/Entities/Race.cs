using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private List<IDriver> drivers;
        private const int NameLength = 5;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            drivers = new List<IDriver>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (!string.IsNullOrEmpty(value) && value.Length >= NameLength)
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName, value));
                }
            }
        }

        public int Laps
        {
            get => laps;

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidNumberOfLaps, value));
                }
                else
                {
                    laps = value;
                }
            }
        }

        public IReadOnlyCollection<IDriver> Drivers { get => drivers.AsReadOnly(); }

        public void AddDriver(IDriver driver)
        {
            if (driver is null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (driver.CanParticipate == false)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriverNotParticipate, driver));
            }

            if (drivers != null && drivers.Any(d => d.Name == driver.Name))
            {
                throw new ArgumentNullException(String.Format(ExceptionMessages.DriverAlreadyAdded, driver, name));
            }

            drivers.Add(driver);
        }
    }
}
