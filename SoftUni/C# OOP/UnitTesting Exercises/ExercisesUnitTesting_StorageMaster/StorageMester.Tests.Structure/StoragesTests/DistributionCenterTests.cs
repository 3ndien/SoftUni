
namespace StorageMaster.Tests.Structure.StoragesTests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Storage;
    using StorageMaster.Core;
    using System.Linq;
    using System;
    using StorageMaster.Entities.Products;

    [TestFixture]
    public class DistributionCenterTests
    {
        private Storage distributionCenter;
        private StorageMaster storageMaster;

        [SetUp]
        public void SetUp()
        {
            this.storageMaster = new StorageMaster();
            this.distributionCenter = new DistributionCenter("FlakTower");
        }

        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            Storage warehouse = new DistributionCenter("house");

            Assert.AreEqual(5, warehouse.GarageSlots);
            Assert.AreEqual(2, warehouse.Capacity);
            Assert.AreEqual(3, this.distributionCenter.Garage.Count(v => v != null));
        }

        [Test]
        [TestCase(7)]
        [TestCase(9)]
        [TestCase(6)]
        [TestCase(5)]
        [TestCase(3)]
        [TestCase(4)]
        public void GetVehicle_ShouldThrowException(int v)
        {
            Assert.Throws<InvalidOperationException>(() => this.distributionCenter.GetVehicle(v), "Invalid garage slot!");
            Assert.Throws<InvalidOperationException>(() => this.distributionCenter.GetVehicle(v), "No vehicle in this garage slot!");
        }

        [Test]
        public void GetVehicle_ShouldWorkCorrectly()
        {
            this.storageMaster.RegisterStorage(this.distributionCenter.GetType().Name, this.distributionCenter.Name);
            string expectedVan = $"Selected {this.distributionCenter.GetVehicle(2).GetType().Name}";
            string actualVan = this.storageMaster.SelectVehicle(this.distributionCenter.Name, 2);

            Assert.AreEqual(expectedVan, actualVan);
        }

        [Test]
        public void SendVehicle_ShouldThrowException()
        {
            Storage tempStorage = new DistributionCenter("Temp");

            for (int i = 3; i < tempStorage.Garage.Count; i++)
            {
                this.distributionCenter.SendVehicleTo(i % 3, tempStorage);
            }

            Assert.Throws<InvalidOperationException>(() => this.distributionCenter.SendVehicleTo(5, tempStorage), "No room in garage!");
        }

        [Test]
        public void SendVehicle_ShouldWorkCorrectly()
        {
            Storage tempStorage = new DistributionCenter("temp");

            Assert.AreEqual(3, this.distributionCenter.SendVehicleTo(2, tempStorage));
        }

        [Test]
        public void UnloadVehicle_ShouldThrowException()
        {
            for (int v = 0; v < 3; v++)
            {
                for (int p = 0; p < this.distributionCenter.GetVehicle(v).Capacity; p++)
                {
                    this.distributionCenter.GetVehicle(v).LoadProduct(new HardDrive(2.33));
                }
            }

            this.distributionCenter.UnloadVehicle(0);
            Assert.IsTrue(this.distributionCenter.IsFull);
            Assert.Throws<InvalidOperationException>(() => this.distributionCenter.UnloadVehicle(1), "Storage is full!");
        }

        [Test]
        public void UnloadVehicle_ShouldWorkCorrectly()
        {
            for (int p = 0; p < this.distributionCenter.GetVehicle(0).Capacity; p++)
            {
                this.distributionCenter.GetVehicle(0).LoadProduct(new HardDrive(2.33));
            }

            Assert.AreEqual(2, this.distributionCenter.UnloadVehicle(0));
            Assert.AreEqual(2, this.distributionCenter.Products.Count(p => p != null));

        }
    }
}
