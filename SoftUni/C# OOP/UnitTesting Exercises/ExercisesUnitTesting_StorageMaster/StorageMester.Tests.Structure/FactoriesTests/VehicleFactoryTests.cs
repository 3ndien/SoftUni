namespace StorageMaster.Tests.Structure.FactoriesTests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Factories;
    using StorageMaster.Entities.Vehicles;
    using System;

    [TestFixture]
    public class VehicleFactoryTests
    {
        private VehicleFactory vehicleFactory;

        [SetUp]
        public void Setup()
        {
            this.vehicleFactory = new VehicleFactory();
        }

        [Test]
        public void CreateVehicle_ShouldThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => this.vehicleFactory.CreateVehicle("SportsCar"), "Invalid vehicle type!");
        }

        [Test]
        [TestCase("Van")]
        [TestCase("Semi")]
        [TestCase("Truck")]
        public void CreateVehicle_ShouldWorkCorrectly(string vehicleType)
        {
            Vehicle actualVehicle = this.vehicleFactory.CreateVehicle(vehicleType);

            Assert.AreEqual(vehicleType, actualVehicle.GetType().Name);
        }
    }
}
