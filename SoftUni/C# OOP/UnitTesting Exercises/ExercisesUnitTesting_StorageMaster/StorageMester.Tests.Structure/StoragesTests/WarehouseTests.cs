namespace StorageMaster.Tests.Structure.StoragesTests
{
    using StorageMaster.Core;
    using NUnit.Framework;
    using StorageMaster.Entities.Storage;
    using System;
    using System.Linq;
    using StorageMaster.Entities.Products;

    [TestFixture]
    public class WarehouseTests
    {
        private Storage warehouse;
        private StorageMaster storageMaster;

        [SetUp]
        public void SetUp()
        {
            this.storageMaster = new StorageMaster();
            this.warehouse = new Warehouse("GustavCanon");
        }

        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            Storage warehouse = new Warehouse("house");

            Assert.AreEqual(10, warehouse.GarageSlots);
            Assert.AreEqual(10, warehouse.Capacity);
            Assert.AreEqual(3, this.warehouse.Garage.Count(v => v != null));
        }

        [Test]
        [TestCase(11)]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(15)]
        [TestCase(3)]
        [TestCase(4)]
        public void GetVehicle_ShouldThrowException(int v)
        {
            Assert.Throws<InvalidOperationException>(() => this.warehouse.GetVehicle(v), "Invalid garage slot!");
            Assert.Throws<InvalidOperationException>(() => this.warehouse.GetVehicle(v), "No vehicle in this garage slot!");
        }

        [Test]
        public void GetVehicle_ShouldWorkCorrectly()
        {
            this.storageMaster.RegisterStorage(this.warehouse.GetType().Name, this.warehouse.Name);
            string expectedSemi = $"Selected {this.warehouse.GetVehicle(2).GetType().Name}";
            string actualSemi = this.storageMaster.SelectVehicle(this.warehouse.Name, 2);

            Assert.AreEqual(expectedSemi, actualSemi);
        }

        [Test]
        public void SendVehicle_ShouldThrowException()
        {
            Storage warehouse3 = new Warehouse("b");
            Storage warehouse2 = new Warehouse("a");
            Storage tempStorage = new Warehouse("Temp");

            for (int i = 3; i < tempStorage.Garage.Count; i++)
            {
                if (i >= 3 && i < 6)
                {
                    this.warehouse.SendVehicleTo(i % 3, tempStorage);
                }
                else if (i >= 6 && i < 9)
                {
                    warehouse2.SendVehicleTo(i % 3, tempStorage);
                }
                else
                {
                    warehouse3.SendVehicleTo(i % 3, tempStorage);
                }
            }

            Assert.Throws<InvalidOperationException>(() => warehouse3.SendVehicleTo(10, tempStorage), "No room in garage!");
        }

        [Test]
        public void SendVehicle_ShouldWorkCorrectly()
        {
            Storage tempStorage = new Warehouse("temp");

            Assert.AreEqual(3, this.warehouse.SendVehicleTo(2, tempStorage));
        }

        [Test]
        public void UnloadVehicle_ShouldThrowException()
        {
            for (int v = 0; v < 3; v++)
            {
                for (int p = 0; p < this.warehouse.GetVehicle(v).Capacity; p++)
                {
                    this.warehouse.GetVehicle(v).LoadProduct(new HardDrive(2.33));
                }
            }

            this.warehouse.UnloadVehicle(0);
            Assert.IsTrue(this.warehouse.IsFull);
            Assert.Throws<InvalidOperationException>(() => this.warehouse.UnloadVehicle(1), "Storage is full!");
        }

        [Test]
        public void UnloadVehicle_ShouldWorkCorrectly()
        {
            for (int p = 0; p < this.warehouse.GetVehicle(0).Capacity; p++)
            {
                this.warehouse.GetVehicle(0).LoadProduct(new HardDrive(2.33));
            }

            Assert.AreEqual(10, this.warehouse.UnloadVehicle(0));
            Assert.AreEqual(10, this.warehouse.Products.Count(p => p != null));

        }
    }
}
