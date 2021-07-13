namespace StorageMaster.Tests.Structure.FactoriesTests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Factories;
    using StorageMaster.Entities.Products;
    using System;


    [TestFixture]
    public class ProductFactoryTests
    {
        private ProductFactory productFactory;

        [SetUp]
        public void Setup()
        {
            this.productFactory = new ProductFactory();
        }

        [Test]
        public void CreateProduct_ShouldThrowException_IfProductDoesntExistOrInvalid()
        {
            Assert.Throws<InvalidOperationException>(() => this.productFactory.CreateProduct("cpu", 320.20), "Invalid product type!");
            Assert.Throws<InvalidOperationException>(() => this.productFactory.CreateProduct("Gpu", -1), "Price cannot be negative!");
        }

        [Test]
        [TestCase("Gpu", 2.20)]
        [TestCase("Ram", 1.50)]
        [TestCase("HardDrive", 1.00)]
        public void CreateProduct_ShouldWorkCorrectly(string productType, double price)
        {
            Product actualProduct = this.productFactory.CreateProduct(productType, price);

            Assert.AreEqual(productType, actualProduct.GetType().Name);
            Assert.AreEqual(price, actualProduct.Price);
        }
    }
}
