using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("BMW", "E46", 8.0, 65);
        }

        [Test]
        public void CtorShouldInitializeCorrectly()
        {
            Assert.AreEqual("BMW", this.car.Make);
            Assert.AreEqual("E46", this.car.Model);
            Assert.AreEqual(8.0, this.car.FuelConsumption);
            Assert.AreEqual(65, this.car.FuelCapacity);
            Assert.AreEqual(0, this.car.FuelAmount);
        }

        [Test]
        [TestCase(null, "e46", 8.0, 65)]
        [TestCase("", "e46", 8.0, 65)]
        [TestCase("BMW", null, 8.0, 65)]
        [TestCase("BMW", "", 8.0, 65)]
        [TestCase("BMW", "e46", -8, 65)]
        [TestCase("BMW", "e46", 0, 65)]
        [TestCase("BMW", "e46", 8.0, 0)]
        [TestCase("BMW", "e46", 8.0, -1)]
        public void PropertiesValidationShouldThrowException(string make, string model, double consumption, double capacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, consumption, capacity));

            Assert.Throws<InvalidOperationException>(() => this.car.Drive(10000));
        }
    
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelMethodShouldThrowException(double fuelAmount)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelAmount));
        }

        [Test]
        public void RefuelMethodShouldWorkCorrectly()
        {
            this.car.Refuel(45);
            Assert.AreEqual(45, this.car.FuelAmount);

            this.car.Refuel(45);
            Assert.AreEqual(this.car.FuelCapacity, this.car.FuelAmount);
        }

        [Test]
        public void DriveMethodShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(1000));
        }

        [Test]
        public void DriveMethodShouldWorkCorrectly()
        {
            this.car.Refuel(65);

            this.car.Drive(50);
            var fuelNeeded = (50 / 100) * this.car.FuelConsumption;
            var expected = this.car.FuelAmount - fuelNeeded;

            Assert.AreEqual(expected, this.car.FuelAmount);
        }
    }
}