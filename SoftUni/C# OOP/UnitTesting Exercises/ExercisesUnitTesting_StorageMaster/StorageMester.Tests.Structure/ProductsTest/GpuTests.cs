
namespace StorageMaster.Tests.Structure.Products.Test
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using System;

    [TestFixture]
    public class ProductsTests
    {
        private Product gpu;

        [SetUp]
        public void Setup()
        {
            this.gpu = new Gpu(12.22);
        }

        [Test]
        public void Constructor_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => new Gpu(-1));
        }

        [Test]
        public void PricePropertyShouldReturnCorrectValue()
        {
            Assert.That(12.22, Is.EqualTo(this.gpu.Price));
        }

    }
}
