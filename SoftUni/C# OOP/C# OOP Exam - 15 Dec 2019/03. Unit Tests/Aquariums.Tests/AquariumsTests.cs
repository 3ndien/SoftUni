namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;

        [SetUp]
        public void Setup()
        {
            this.aquarium = new Aquarium("aqua", 30);
        }

        [Test]
        public void CtorShouldInitializeCorrectly()
        {
            Assert.AreEqual("aqua", aquarium.Name);
            Assert.AreEqual(30, aquarium.Capacity);
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void NamePropertyShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 30));
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 20));
        }

        [Test]
        public void NamePropertyShouldWorkCorrectly()
        {
            Assert.AreEqual("aqua", this.aquarium.Name);
        }

        [Test]
        public void CapacityPropertyShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("aqua", -1));
        }

        [Test]
        public void CapacityPropertyShouldWorkCorrectly()
        {
            Assert.AreEqual(30, aquarium.Capacity);
        }

        [Test]
        public void AddMethodShouldThrowException()
        {
            for (int i = 0; i < this.aquarium.Capacity; i++)
            {
                this.aquarium.Add(new Fish($"Fish{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => this.aquarium.Add(new Fish("Riba")));
        }

        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            for (int i = 0; i < this.aquarium.Capacity; i++)
            {
                this.aquarium.Add(new Fish($"Fish{i}"));
            }

            Assert.AreEqual(30, this.aquarium.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowException()
        {
            for (int i = 0; i < this.aquarium.Capacity; i++)
            {
                this.aquarium.Add(new Fish($"Fish{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish("Fish31"));
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            for (int i = 0; i < this.aquarium.Capacity; i++)
            {
                this.aquarium.Add(new Fish($"Fish{i}"));
            }

            this.aquarium.RemoveFish("Fish29");

            Assert.AreEqual(29, this.aquarium.Count);
        }

        [Test]
        public void SellFishMethodShouldThrowException()
        {
            for (int i = 0; i < this.aquarium.Capacity; i++)
            {
                this.aquarium.Add(new Fish($"Fish{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => this.aquarium.SellFish("Fish31"));
        }

        [Test]
        public void SellFishMethodShouldWorkCorrectly()
        {
            for (int i = 0; i < this.aquarium.Capacity; i++)
            {
                this.aquarium.Add(new Fish($"Fish{i}"));
            }
            Fish result = this.aquarium.SellFish("Fish29");

            Assert.AreEqual("Fish29", result.Name);
            Assert.IsFalse(result.Available);
        }

        [Test]
        public void ReportMethodShouldWorkCorrectly()
        {
            this.aquarium.Add(new Fish("Fish1"));
            this.aquarium.Add(new Fish("Fish2"));
            this.aquarium.Add(new Fish("Fish3"));

            var names = new string[] { "Fish1", "Fish2", "Fish3" };
            var expected = $"Fish available at aqua: {string.Join(", ", names)}";

            Assert.AreEqual(expected, this.aquarium.Report());
        }
    }
}
