using NUnit.Framework;

namespace Tests
{
    using ExtendedDatabase;
    using System;

    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase db;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CtorShouldThrowException()
        {
            var persons = new Person[17];
            for (int i = 0; i < 17; i++)
            {
                persons[i] = new Person(i, $"Person{i}");
            }

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(persons));

        }

        [Test]
        public void CtorShouldInitializeCorrectly()
        {
            var persons = new Person[16];
            for (int i = 0; i < 16; i++)
            {
                persons[i] = new Person(i, $"Person{i}");
            }

            this.db = new ExtendedDatabase(persons);

            Assert.AreEqual(persons.Length, this.db.Count);
        }

        [Test]
        public void AddPersonShouldThrowException_WhenAddMoreThan_16()
        {
            var persons = new Person[16];
            for (int i = 0; i < 16; i++)
            {
                persons[i] = new Person(i, $"Person{i}");
            }
            this.db = new ExtendedDatabase(persons);

            Assert.Throws<InvalidOperationException>(() => this.db.Add(new Person(126541, "Pesho")), "Array's capacity must be exactly 16 integers!");

        }

        [Test]
        public void AddPersonShouldWorkCorrectly()
        {
            this.db = new ExtendedDatabase();

            for (int i = 0; i < 16; i++)
            {
                this.db.Add(new Person(i, $"Person{i}"));
                Assert.AreEqual(i + 1, this.db.Count);
            }

            Assert.AreEqual(16, this.db.Count);

        }

        [Test]
        public void AddPersonShouldThrowException_WhenUsernameExist()
        {
            var persons = new Person[15];

            for (int i = 0; i < 15; i++)
            {
                persons[i] = new Person(i, $"Person{i}");
            }
            this.db = new ExtendedDatabase(persons);

            Assert.Throws<InvalidOperationException>(() => this.db.Add(new Person(156165, "Person14")), "There is already user with this username!");
        }

        [Test]
        public void AddPersonShouldThrowException_WhenIdExist()
        {
            var persons = new Person[15];

            for (int i = 0; i < 15; i++)
            {
                persons[i] = new Person(i, $"Person{i}");
            }
            this.db = new ExtendedDatabase(persons);

            Assert.Throws<InvalidOperationException>(() => this.db.Add(new Person(14, "Person6516")), "There is already user with this Id!");
        }

        [Test]
        public void RemovePersonShouldThrowException()
        {
            this.db = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => this.db.Remove());
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            var persons = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                persons[i] = new Person(i, $"Person{i}");
            }

            this.db = new ExtendedDatabase(persons);

            for (int i = 15; i >= 0; i--)
            {
                this.db.Remove();

                Assert.AreEqual(i, this.db.Count);
            }

            Assert.AreEqual(0, this.db.Count);
        }

        [Test]
        public void FindByIdShouldThrowException()
        {
            this.db = new ExtendedDatabase();

            this.db.Add(new Person(1, "Pesho"));
            Assert.Throws<ArgumentOutOfRangeException>(() => this.db.FindById(-1));
            Assert.Throws<InvalidOperationException>(() => this.db.FindById(2));
        }

        [Test]
        public void FindByUsernameShouldThrowException()
        {
            this.db = new ExtendedDatabase();

            this.db.Add(new Person(1, "Pesho"));
            Assert.Throws<ArgumentNullException>(() => this.db.FindByUsername(null));
            Assert.Throws<InvalidOperationException>(() => this.db.FindByUsername("Fo"));
        }

        [Test]
        public void FindByIdShouldWorkCorrectly()
        {
            this.db = new ExtendedDatabase(new Person(1, "Pesho"));

            Assert.AreEqual(1, this.db.FindById(1).Id);
            Assert.AreEqual("Pesho", this.db.FindById(1).UserName);
        }

        [Test]
        public void FindByUsernameShouldWorkCorrectly()
        {
            this.db = new ExtendedDatabase(new Person(1, "Pesho"));

            Assert.AreEqual("Pesho", this.db.FindByUsername("Pesho").UserName);
            Assert.AreEqual(1, this.db.FindByUsername("Pesho").Id);
        }
    }
}