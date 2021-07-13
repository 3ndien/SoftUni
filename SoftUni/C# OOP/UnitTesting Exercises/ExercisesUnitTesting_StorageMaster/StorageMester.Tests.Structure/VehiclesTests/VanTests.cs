

namespace StorageMaster.Tests.Structure.Vehicles.Tests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Vehicles;
    using System;

    [TestFixture]
    public class VanTests
    {
        private Vehicle van;

        [SetUp]
        public void Setup()
        {
            this.van = new Van();
        }

        [Test]
        public void LoadProduct_ShouldThrowExeptionWhen_IsFull()
        {
            var hardDrive1 = new HardDrive(2.33);
            var hardDrive2 = new HardDrive(2.33);

            this.van.LoadProduct(hardDrive1);
            this.van.LoadProduct(hardDrive2);

            Assert.IsTrue(this.van.IsFull);
            Assert.Throws<InvalidOperationException>(() => this.van.LoadProduct(new HardDrive(2.55)));
        }

        [Test]
        public void LoadProduct_ShouldAddProductCorrectly()
        {
            var ram1 = new Ram(1.55);
            var ram2 = new Ram(1.55);
            var ram3 = new Ram(1.55);

            this.van.LoadProduct(ram1);
            this.van.LoadProduct(ram2);
            this.van.LoadProduct(ram3);

            Assert.AreEqual(3, this.van.Trunk.Count);
            Assert.IsFalse(this.van.IsEmpty);
            Assert.IsFalse(this.van.IsFull);
        }

        [Test]
        public void Unload_ShouldThrowExceptionWhen_IsEmpty()
        {
            Assert.IsTrue(this.van.IsEmpty);
            Assert.Throws<InvalidOperationException>(() => this.van.Unload());
        }

        [Test]
        public void Unload_ShouldWorkCorrectly()
        {
            Product lastProduct = new Ram(1.33);

            this.van.LoadProduct(lastProduct);

            Assert.AreEqual(lastProduct, this.van.Unload());
            Assert.AreEqual(0, this.van.Trunk.Count);
            Assert.IsTrue(this.van.IsEmpty);
            
        }
    }
}