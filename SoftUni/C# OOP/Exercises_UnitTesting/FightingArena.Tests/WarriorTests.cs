using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Pesho", 100, 250);
        }

        [Test]
        public void CtorShouldInitializeCorrectly()
        {
            Assert.AreEqual("Pesho", this.warrior.Name);
            Assert.AreEqual(100, this.warrior.Damage);
            Assert.AreEqual(250, this.warrior.HP);
        }

        [TestCase(null, 100, 250)]
        [TestCase(" ", 100, 250)]
        [TestCase("Pesho", 0, 250)]
        [TestCase("Pesho", -100, 250)]
        [TestCase("Pesho", 100, -250)]
        public void AllPropertiesValidationsShouldThrowsExceptions(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        public void ReduceHpPropertyShouldWorkCorrectly()
        {
            var gosho = new Warrior("Gosho", 50, 25000);
            int expected = 250;

            for (int i = 0; i < 4; i++)
            {
                expected -= 50;
                gosho.Attack(this.warrior);

                Assert.AreEqual(expected, this.warrior.HP);
            }
        }

        [TestCase("Gosho", 300, 20, "Pesho", 100, 250)]
        [TestCase("Gosho", 100, 250, "Pesho", 100, 10)]
        [TestCase("Gosho", 100, 60, "Pesho", 1000, 2500)]
        public void AttackMethodShouldThrowsExceptions(string name1, int damage1, int hp1, string name2, int damage2, int hp2)
        {
            this.warrior = new Warrior(name2, damage2, hp2);
            Assert.Throws<InvalidOperationException>(() => new Warrior(name1, damage1, hp1).Attack(this.warrior));
        }

        [TestCase(0, 50)]
        [TestCase(900, 1000)]
        public void AttackMethodShouldWorkCorrectly(int expected, int hp)
        {
            var warrior2 = new Warrior("Gosho", 100, hp);

            this.warrior.Attack(warrior2);
            Assert.AreEqual(expected, warrior2.HP);
        }
    }
}