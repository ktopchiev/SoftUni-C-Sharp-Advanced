using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    class ChampionshipController : IChampionshipController
    {
        private Driver driver;
        private ICar car;
        IRepository<IDriver> driverRepository;
        IRepository<ICar> carRepository;
        IRepository<IRace> raceRepository;


        public ChampionshipController()
        {
            driverRepository = new DriverRepository();
            carRepository = new CarRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = null;
            ICar car = null;


            if (driverRepository.GetAll().Any(d => d.Name == driverName) == false)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound,driverName));
            }
            else
            {
               driver = driverRepository.GetAll().First(d => d.Name == driverName);
            }

            if (carRepository.GetAll().Any(c => c.Model == carModel) == false)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, carModel));
            }
            else
            {

                car = carRepository.GetAll().First(c => c.Model == carModel);
            }

            driver.AddCar(car);
            return String.Format(OutputMessages.DriverReceivedCar, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            throw new NotImplementedException();
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            car = null;

            switch (type)
            {
                case "Muscle":
                    car = new MuscleCar(model, horsePower);
                    break;
                case "Sports":
                    car = new SportsCar(model, horsePower);
                    break;
                default:
                    break;
            }

            carRepository.Add(car);

            return $"{type}Car {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            driver = new Driver(driverName);

            driverRepository.Add(driver);

            return OutputMessages.DriverCreated;
        }

        public string CreateRace(string name, int laps)
        {
            throw new NotImplementedException();
        }

        public string StartRace(string raceName)
        {
            throw new NotImplementedException();
        }
    }
}
