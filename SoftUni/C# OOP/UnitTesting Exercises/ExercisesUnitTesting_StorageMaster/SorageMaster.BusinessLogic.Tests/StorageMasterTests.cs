namespace SorageMaster.BusinessLogic.Tests
{
    using NUnit.Framework;
    using StorageMaster.Core;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Storage;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class StorageMasterTests
    {
        private StorageMaster storageMaster;

        [SetUp]
        public void SetUp()
        {
            this.storageMaster = new StorageMaster();
            this.storageMaster.RegisterStorage("AutomatedWarehouse", "Shipment");
        }

        [Test]
        [TestCase("HardDrive", 2.50)]
        [TestCase("HardDrive", 2.50)]
        [TestCase("Ram", 1.20)]
        [TestCase("Ram", 1.20)]
        public void AddProduct_ShouldWorkCorrectly(string productType, double price)
        {
            string expected = productType;
            string actual = this.storageMaster.AddProduct(productType, price).Substring("added ".Length, productType.Length);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("Warehouse", "GustavCanon")]
        [TestCase("DistributionCenter", "GrostenHouse")]
        [TestCase("AutomatedWarehouse", "Shipment")]
        public void RegisterStorage_ShouldWorkCorrectly(string storageType, string expectedName)
        {
            string actualName = this.storageMaster.RegisterStorage(storageType, expectedName).Substring("registered ".Length, expectedName.Length);

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        [TestCase("Warehouse", "Shipment", "Semi")]
        [TestCase("DistributionCenter", "GustavCanon", "Van")]
        [TestCase("AutomatedWarehouse", "Carentan", "Truck")]
        public void SelectVehicle_ShouldWorkCorrectli(string storageType, string storageName, string vehicle)
        {
            this.storageMaster.RegisterStorage(storageType, storageName);

            Assert.AreEqual(vehicle, this.storageMaster.SelectVehicle(storageName, 0).Substring("Selected ".Length));
        }
        
        [Test]
        public void LoadVehicle_IfIsFullShouldNotLoadProducts()
        {
            var products = new List<string>
            {
                "HardDrive",
                "HardDrive",
                "HardDrive",
                "HardDrive",
                "HardDrive",
                "Ram"
            };

            for (int i = 0; i < products.Count; i++)
            {
                this.storageMaster.AddProduct("HardDrive", 2.00);
            }
            this.storageMaster.SelectVehicle("Shipment", 0);

            string actual = this.storageMaster.LoadVehicle(products);
            string expected = "Loaded 5/6 products into Truck";

            Assert.AreEqual(expected, actual);

            this.storageMaster.UnloadVehicle("Shipment", 0);
        }

        [Test]
        public void LoadVehicle_ShouldThrowException()
        {
            var products = new List<string>
            {
                "HardDrive",
            };

            this.storageMaster.SelectVehicle("Shipment", 0);

            Assert.Throws<InvalidOperationException>(() => this.storageMaster.LoadVehicle(products), $"HardDrive is out of stock!");
        }

        [Test]
        public void SendVehicleTo_ShouldThrowException_IfDestinationNameNotRegistered()
        {
            Assert.Throws<InvalidOperationException>(() => this.storageMaster.SendVehicleTo("Shipment", 0, "Temp"), "Invalid destination storage!");
        }

        [Test]
        public void SendVehicleTo_ShouldThrowException_IfSourceNameNotRegistered()
        {
            Assert.Throws<InvalidOperationException>(() => this.storageMaster.SendVehicleTo("NotExist", 0, "DoesntExist"));
        }

        [Test]
        public void SendVehicleTo_ShouldWorkCorrectly()
        {
            this.storageMaster.RegisterStorage("Warehouse", "Temp");

            string expected = $"Sent Truck to Temp (slot 3)";
            string actual = this.storageMaster.SendVehicleTo("Shipment", 0, "Temp");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UnloadVehicle_ShouldWorkCorrectly()
        {
            var products = new List<string> { "HardDrive" };

            for (int i = 0; i < products.Count; i++)
            {
                this.storageMaster.AddProduct("HardDrive", 2.00);
            }
            this.storageMaster.SelectVehicle("Shipment", 0);
            this.storageMaster.LoadVehicle(products);

            string expected = $"Unloaded 1/5 products at Shipment";
            string actual = this.storageMaster.UnloadVehicle("Shipment", 0);

            Assert.AreEqual(expected, actual);
        }


    }
}
