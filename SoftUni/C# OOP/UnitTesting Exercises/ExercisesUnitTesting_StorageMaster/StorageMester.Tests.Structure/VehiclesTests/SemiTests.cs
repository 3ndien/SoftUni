
namespace StorageMaster.Tests.Structure.Vehicles.Tests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Vehicles;
    using System;


    [TestFixture]
    public class SemiTests
    {
        private Vehicle semi;

        [SetUp]
        public void Setup()
        {
            this.semi = new Truck();
        }

        [Test]
        public void LoadProduct_ShouldThrowExeptionWhen_IsFull()
        {

            for (int i = 0; i < this.semi.Capacity; i++)
            {
                this.semi.LoadProduct(new HardDrive(2.33));
            }
            

            Assert.IsTrue(this.semi.IsFull);
            Assert.Throws<InvalidOperationException>(() => this.semi.LoadProduct(new HardDrive(2.55)));
        }

        [Test]
        public void LoadProduct_ShouldAddProductCorrectly()
        {
            var ram1 = new Ram(1.55);
            var ram2 = new Ram(1.55);
            var ram3 = new Ram(1.55);

            this.semi.LoadProduct(ram1);
            this.semi.LoadProduct(ram2);
            this.semi.LoadProduct(ram3);

            Assert.AreEqual(3, this.semi.Trunk.Count);
            Assert.IsFalse(this.semi.IsEmpty);
            Assert.IsFalse(this.semi.IsFull);
        }

        [Test]
        public void Unload_ShouldThrowExceptionWhen_IsEmpty()
        {
            Assert.IsTrue(this.semi.IsEmpty);
            Assert.Throws<InvalidOperationException>(() => this.semi.Unload());
        }

        [Test]
        public void Unload_ShouldWorkCorrectly()
        {
            Product lastProduct = new Ram(1.33);

            this.semi.LoadProduct(lastProduct);

            Assert.AreEqual(lastProduct, this.semi.Unload());
            Assert.AreEqual(0, this.semi.Trunk.Count);
            Assert.IsTrue(this.semi.IsEmpty);

        }
    }
}
