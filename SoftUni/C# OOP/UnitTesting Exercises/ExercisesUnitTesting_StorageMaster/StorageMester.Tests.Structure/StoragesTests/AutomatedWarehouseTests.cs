namespace StorageMaster.Tests.Structure.StoragesTests
{
    using StorageMaster.Core;
    using NUnit.Framework;
    using StorageMaster.Entities.Storage;
    using System;
    using System.Linq;
    using StorageMaster.Entities.Products;

    [TestFixture]
    public class AutomatedWarehouseTests
    {
        private Storage automatedWarehouse;
        private StorageMaster storageMaster;

        [SetUp]
        public void SetUp()
        {
            this.storageMaster = new StorageMaster();
            this.automatedWarehouse = new AutomatedWarehouse("Shipment");
        }

        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            Storage warehouse = new AutomatedWarehouse("house");

            Assert.AreEqual(2, warehouse.GarageSlots);
            Assert.AreEqual(1, warehouse.Capacity);
            Assert.AreEqual(1, this.automatedWarehouse.Garage.Count(v => v != null));
        }

        [Test]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(2)]
        public void GetVehicle_ShouldThrowException(int v)
        {
            Assert.Throws<InvalidOperationException>(() => this.automatedWarehouse.GetVehicle(v), "Invalid garage slot!");
            Assert.Throws<InvalidOperationException>(() => this.automatedWarehouse.GetVehicle(v), "No vehicle in this garage slot!");
        }

        [Test]
        public void GetVehicle_ShouldWorkCorrectly()
        {
            this.storageMaster.RegisterStorage(this.automatedWarehouse.GetType().Name, this.automatedWarehouse.Name);           
	        string expectedVan = $"Selected {this.automatedWarehouse.GetVehicle(0).GetType().Name}";
            string actualVan = this.storageMaster.SelectVehicle(this.automatedWarehouse.Name, 0);

            Assert.AreEqual(expectedVan, actualVan);
        }

        [Test]
        public void SendVehicle_ShouldThrowException()
        {
            Storage tempStorage = new AutomatedWarehouse("Temp");

            for (int i = 1; i < tempStorage.Garage.Count; i++)
            {
                this.automatedWarehouse.SendVehicleTo(i % 1, tempStorage);
            }

            Assert.Throws<InvalidOperationException>(() => this.automatedWarehouse.SendVehicleTo(2, tempStorage), "No room in garage!");
        }

        [Test]
        public void SendVehicle_ShouldWorkCorrectly()
        {
            Storage tempStorage = new AutomatedWarehouse("temp");

            Assert.AreEqual(1, this.automatedWarehouse.SendVehicleTo(0, tempStorage));
        }

        [Test]
        public void UnloadVehicle_ShouldThrowException()
        {
            this.automatedWarehouse.GetVehicle(0).LoadProduct(new HardDrive(2.33));
            this.automatedWarehouse.GetVehicle(0).LoadProduct(new HardDrive(2.33));
            this.automatedWarehouse.UnloadVehicle(0);

            Assert.Throws<InvalidOperationException>(() => this.automatedWarehouse.UnloadVehicle(0), "Storage is full!");
            this.automatedWarehouse.GetVehicle(0).Unload();
        }

        [Test]
        public void UnloadVehicle_ShouldWorkCorrectly()
        {
            for (int p = 0; p < this.automatedWarehouse.GetVehicle(0).Capacity; p++)
            {
                this.automatedWarehouse.GetVehicle(0).LoadProduct(new HardDrive(2.33));
            }

            Assert.AreEqual(1, this.automatedWarehouse.UnloadVehicle(0));

        }
    }
}
