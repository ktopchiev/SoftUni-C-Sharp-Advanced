//using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        private string make;
        private string model;
        private double fuelConsumption;
        private double fuelCapacity;

        [SetUp]
        public void Setup()
        {
            make = "Toyota";
            model = "Avensis";
            fuelConsumption = 8;
            fuelCapacity = 60;
            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void CtorAndProperties_Setting_Should_SetProperly()
        {
            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
            Assert.That(car.FuelAmount, Is.Zero);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Property_Make_Should_ThrowException_When_ArgumentIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Property_Model_Should_ThrowExcception_When_ArgumentIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-777)]
        public void Property_FuelConsumption_Should_ThrowException_When_ArgumentIsZeroOrNegative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-777)]
        public void Property_FuelCapacity_Should_ThrowException_When_ArgumentIsZeroOrNegative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase(-69)]
        public void Property_FuelAmount_Should_ThrowException_When_ArgumentIsNegative(double fuelAmount)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelAmount));
        }

        [Test]
        public void Refuel_Should_IncreaseFuelAmount()
        {
            car.Refuel(10);
            Assert.That(car.FuelAmount, Is.EqualTo(10));
        }

        [Test]
        public void Refuel_Should_MakeFuelAmountEqualToFuelCapacity_When_RefuelAmountIsBigger()
        {
            car.Refuel(666);
            Assert.That(car.FuelAmount, Is.EqualTo(car.FuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Refuel_Should_ThrowException_WhenArgumentIsZeroOrNegative(double fuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        public void Drive_Should_CalculateFuelNeededAndSubtractItFromFuelAmount()
        {
            double distance = 100;
            double fuelNeeded = (distance / 100) * fuelConsumption;

            car.Refuel(100);

            double preFuelAmount = car.FuelAmount;

            car.Drive(distance);

            Assert.That(car.FuelAmount, Is.EqualTo(preFuelAmount - fuelNeeded));
        }

        [Test]
        public void Drive_Should_ThrowException_When_FuelNeededIsMoreThanFuelAmount()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(50));
        }

        [Test]
        public void Drive_Should_DecreaseFuelAmount()
        {
            car.Refuel(60);

            car.Drive(100);

            Assert.That(car.FuelAmount, Is.EqualTo(52));
        }
    }
}