namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone("Sony", "Z3");
            this.phone.AddContact("Pesho", "123654");
        }

        [Test]
        public void Constructor_ShouldWorkCorrectly()
        {
            Assert.AreEqual("Sony", this.phone.Make);
            Assert.AreEqual("Z3", this.phone.Model);
        }

        [Test]
        [TestCase("", "z3")]
        [TestCase("sony", "")]
        [TestCase(null, "s10")]
        [TestCase("samsung", null)]
        public void Constructor_ShouldThrowsException(string make, string model)
        {
            Assert.That(() => this.phone = new Phone(make, model), Throws.ArgumentException);
        }

        [Test]
        public void AddContacts_ShouldThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact("Pesho", "123654"));
        }

        [Test]
        public void AddContact_ShouldWorkCorrectly_IncreaseCount()
        {
            for (int i = 1; i <= 4; i++)
            {
                this.phone.AddContact($"Gosho{i}", $"111{i}");

                Assert.AreEqual(i + 1, this.phone.Count);
            }
        }

        [Test]
        public void Call_ShouldThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => this.phone.Call("Jiki"));
        }

        [Test]
        public void Call_ShouldWorkCorrectly()
        {
            Assert.AreEqual($"Calling Pesho - 123654...", this.phone.Call("Pesho"));
        }
    }
}