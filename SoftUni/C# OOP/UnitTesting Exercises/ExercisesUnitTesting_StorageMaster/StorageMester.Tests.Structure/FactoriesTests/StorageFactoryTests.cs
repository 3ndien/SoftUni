
namespace StorageMaster.Tests.Structure.FactoriesTests
{
    using StorageMaster.Core;
    using NUnit.Framework;
    using StorageMaster.Entities.Factories;
    using System;
    using StorageMaster.Entities.Storage;

    [TestFixture]
    public class StorageFactoryTests
    {
        private StorageFactory storageFactory;
        private StorageMaster storageMaster;

        [SetUp]
        public void Setup()
        {
            this.storageFactory = new StorageFactory();
            this.storageMaster = new StorageMaster();
        }

        [Test]
        public void CreateStorage_ShouldThrowException_IfStorageDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.storageFactory.CreateStorage("Varehouse", "Invalid"));
        }

        [Test]
        [TestCase("Warehouse", "Shipment")]
        [TestCase("DistributionCenter", "GrostenHouse")]
        [TestCase("AutomatedWarehouse", "GustavCanon")]
        public void CreateProduct_ShouldWorkCorrectly(string storageType, string storageName)
        {
            Storage actualStorage = this.storageFactory.CreateStorage(storageType, storageName);

            Assert.AreEqual(storageType, actualStorage.GetType().Name);
            Assert.AreEqual(storageName, actualStorage.Name);
        }
    }
}
