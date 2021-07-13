namespace Tests
{
    using NUnit.Framework;
    using Database;
    using System;

    public class DatabaseTests
    {
        private Database databease;

        [SetUp]
        public void Setup()
        {
            this.databease = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        }

        [Test]
        public void CtorInitializeArrayCorrectly()
        {
            var arr = new int[16];

            var db = new Database(arr);

            Assert.AreEqual(16, db.Count);
        }

        [Test]
        public void AddMethodShouldThrowException()
        {
            this.databease.Add(16);

            Assert.Throws<InvalidOperationException>(() => this.databease.Add(17));
        }

        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            Assert.AreEqual(15, this.databease.Count);

            this.databease.Add(16);

            Assert.AreEqual(16, this.databease.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowException()
        {
            int length = this.databease.Count;

            for (int i = 0; i < length; i++)
            {
                this.databease.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => this.databease.Remove());
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            Assert.AreEqual(15, this.databease.Count);

            this.databease.Remove();

            Assert.AreEqual(14, this.databease.Count);
        }

        [Test]
        public void FetchMethodShouldWorkCorrectly()
        {
            var result = this.databease.Fetch();

            Assert.AreEqual(result.Length, this.databease.Count);
        }
    }
}