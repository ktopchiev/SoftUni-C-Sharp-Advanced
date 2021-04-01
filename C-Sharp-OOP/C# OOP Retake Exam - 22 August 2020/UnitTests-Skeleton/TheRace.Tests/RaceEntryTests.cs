using NUnit.Framework;
using System;
//using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitDriver driver;
        private string driverName;
        private UnitCar car;
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private UnitDriver newDriver;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
            driverName = "Pesho";
            model = "Mazda 3";
            horsePower = 105;
            cubicCentimeters = 1598.00;
            car = new UnitCar(model, horsePower, cubicCentimeters);
            driver = new UnitDriver(driverName, car);
            raceEntry.AddDriver(driver);
            newDriver = new UnitDriver(
                "Kiro",
                new UnitCar("Honda", 300, 2198)
                );
        }

        [Test]
        public void CtorSet_Should_SetPropertiesAndFields()
        {
            Assert.That(raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddDriver_Should_ThrowException_When_UnitDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriver_Should_ThrowExcception_When_RaceEntryContainsDriverWithThisName()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriver_Should_IncreaseCounter_WhenDriverIsAdded()
        {
            raceEntry.AddDriver(newDriver);
            Assert.That(raceEntry.Counter, Is.EqualTo(2));
        }

        [Test]
        public void AddDriver_Should_ReturnAddedDriverName()
        {
            string phrase = $"Driver {newDriver.Name} added in race.";
            Assert.That(raceEntry.AddDriver(newDriver), Is.EqualTo(phrase));
        }

        [Test]
        public void CalculateAverageHorsePower_Should_ThrowException_When_DriverCountIsLessThanRequiredMin()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower_Should_ReturnDoubleAvgHP()
        {
            double preCalculatedAvgHP = 165;
            raceEntry.AddDriver(newDriver);
            raceEntry.AddDriver(new UnitDriver("Tosho", new UnitCar("Opel", 90, 1989)));
            Assert.That(raceEntry.CalculateAverageHorsePower(), Is.EqualTo(preCalculatedAvgHP));
        }
    }
}