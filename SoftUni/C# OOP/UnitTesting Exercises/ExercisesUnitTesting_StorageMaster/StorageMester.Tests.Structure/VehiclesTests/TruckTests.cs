

namespace StorageMaster.Tests.Structure.Vehicles.Tests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Vehicles;
    using System;

    [TestFixture]
    public class TruckTests
    {
        private Vehicle truck;

        [SetUp]
        public void Setup()
        {
            this.truck = new Truck();
        }

        [Test]
        public void LoadProduct_ShouldThrowExeptionWhen_IsFull()
        {
            var hardDrive1 = new HardDrive(2.33);
            var hardDrive2 = new HardDrive(2.33);
            var hardDrive3 = new HardDrive(2.33);
            var hardDrive4 = new HardDrive(2.33);
            var hardDrive5 = new HardDrive(2.33);

            this.truck.LoadProduct(hardDrive1);
            this.truck.LoadProduct(hardDrive2);
            this.truck.LoadProduct(hardDrive3);
            this.truck.LoadProduct(hardDrive4);
            this.truck.LoadProduct(hardDrive5);

            Assert.IsTrue(this.truck.IsFull);
            Assert.Throws<InvalidOperationException>(() => this.truck.LoadProduct(new HardDrive(2.55)));
        }

        [Test]
        public void LoadProduct_ShouldAddProductCorrectly()
        {
            var ram1 = new Ram(1.55);
            var ram2 = new Ram(1.55);
            var ram3 = new Ram(1.55);

            this.truck.LoadProduct(ram1);
            this.truck.LoadProduct(ram2);
            this.truck.LoadProduct(ram3);

            Assert.AreEqual(3, this.truck.Trunk.Count);
            Assert.IsFalse(this.truck.IsEmpty);
            Assert.IsFalse(this.truck.IsFull);
        }

        [Test]
        public void Unload_ShouldThrowExceptionWhen_IsEmpty()
        {
            Assert.IsTrue(this.truck.IsEmpty);
            Assert.Throws<InvalidOperationException>(() => this.truck.Unload());
        }

        [Test]
        public void Unload_ShouldWorkCorrectly()
        {
            Product lastProduct = new Ram(1.33);

            this.truck.LoadProduct(lastProduct);

            Assert.AreEqual(lastProduct, this.truck.Unload());
            Assert.AreEqual(0, this.truck.Trunk.Count);
            Assert.IsTrue(this.truck.IsEmpty);

        }
    }
}
