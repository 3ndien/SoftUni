using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior pesho;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();

            for (int i = 1; i <= 4; i++)
            {
                this.arena.Enroll(new Warrior($"Warr{i}", 200 + i, 300 + i));
            }

            this.pesho = new Warrior("Pesho", 200, 160);
        }

        [Test]
        public void CtorShouldInitializeListOfWarriors()
        {
            this.arena = new Arena();
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void EnrollMethodShouldThrowException()
        {
            this.arena.Enroll(this.pesho);

            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(new Warrior("Pesho", 40, 60)));
        }

        [Test]
        public void EnrollMethodShouldWorkCorrectly()
        {
            for (int i = 1; i <= 4; i++)
            {
                this.arena.Enroll(new Warrior($"Warr1{i}", 210 + i, 310 + i));
            }

            Assert.AreEqual(8, this.arena.Count);
        }

        [TestCase("Warr5", "Warr1")]
        [TestCase("Warr2", "Warr6")]
        [TestCase("Warr5", "Warr6")]
        public void FightMethodShouldThrowsException(string name1, string name2)
        {
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(name1, name2));
        }

        [TestCase("Warr1", "Warr2")]
        public void FightMethodShouldWorkCorrectly(string warr1, string warr2)
        {
            this.arena.Fight(warr1, warr2);
            Assert.AreEqual(99, this.arena.Warriors.First(w => w.Name == "Warr1").HP);
            Assert.AreEqual(101, this.arena.Warriors.First(w => w.Name == "Warr2").HP);

        }
    }
}
