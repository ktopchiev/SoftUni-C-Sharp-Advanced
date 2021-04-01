using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    class ChampionshipController : IChampionshipController
    {
        private IDriver driver;
        private ICar car;
        private IRace race;
        private DriverRepository driverRepository;
        private CarRepository carRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            driverRepository = new DriverRepository();
            carRepository = new CarRepository();
            raceRepository = new RaceRepository();
            car = null;
        }

        public string AddCarToDriver(string driverName, string carModel)
        {

            driver = driverRepository.GetByName(driverName);
            car = carRepository.GetByName(carModel);

            driver.AddCar(car);

            return String.Format(OutputMessages.DriverReceivedCar, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            race = raceRepository.GetByName(raceName);
            driver = driverRepository.GetByName(driverName);

            race.AddDriver(driver);

            return String.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {

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

            return String.Format(OutputMessages.CarCreated, type, model);
        }

        public string CreateDriver(string driverName)
        {
            driver = new Driver(driverName);

            driverRepository.Add(driver);

            return String.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            race = new Race(name, laps);

            raceRepository.Add(race);

            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            race = raceRepository.GetByName(raceName);

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var sortedDrivers = driverRepository.GetAll().OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).ToArray();

            StringBuilder firstThreeDrivers = new StringBuilder();

            firstThreeDrivers.AppendLine($"Driver {sortedDrivers[0].Name} wins {raceName} race.");
            firstThreeDrivers.AppendLine($"Driver {sortedDrivers[1].Name} is second in {raceName} race.");
            firstThreeDrivers.AppendLine($"Driver {sortedDrivers[2].Name} is third in {raceName} race.");

            raceRepository.Remove(race);

            return firstThreeDrivers.ToString().TrimEnd();
        }
    }
}
