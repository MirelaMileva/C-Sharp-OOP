namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    public class ArenaTests
    {
        private Arena arena;
        private Warrior w1;
        private Warrior attacker;
        private Warrior defender;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.w1 = new Warrior("Pesho", 10, 50);
            this.attacker = new Warrior("Pesho", 10, 80);
            this.defender = new Warrior("Gosho", 5, 60);
        }
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void EnrollShouldPhysicallyAddTheWarriorToTheArena()
        {
            this.arena.Enroll(this.w1);

            Assert.That(this.arena.Warriors, Has.Member(this.w1));
        }

        [Test]
        public void EnrollShouldIncreaseCount()
        {
            int expectedCount = 2;

            this.arena.Enroll(this.w1);
            this.arena.Enroll(new Warrior("Gosho", 5, 60));

            int actualCount = this.arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void EnrollSameWarriorShouldThrowException()
        {
            //Arrange
            this.arena.Enroll(this.w1);

            Assert
                .Throws<InvalidOperationException>(
                () =>
                {
                    this.arena.Enroll(this.w1);
                });
        }

        [Test]
        public void EnrollTwoWarriorsWithSameNameShouldThrowException()
        {
            Warrior w1Copy = new Warrior(w1.Name, w1.Damage, w1.HP);

            this.arena.Enroll(this.w1);

            Assert
                .Throws<InvalidOperationException>(
                () =>
                {
                    this.arena.Enroll(w1Copy);
                });
        }

        [Test]
        public void TestFightingWithMissingAttaker()
        {
            this.arena.Enroll(this.defender);

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    this.arena.Fight(this.attacker.Name, this.defender.Name);
                });
        }

        [Test]
        public void TestFightingWithMissingDefender()
        {
            this.arena.Enroll(this.attacker);

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    this.arena.Fight(this.attacker.Name, this.defender.Name);
                });
        }

        [Test]
        public void TestFightingBetweenTwoWarriors()
        {
            int expectedAttackerHP = this.attacker.HP - this.defender.Damage;
            int expectedDefenderHP = this.defender.HP - this.attacker.Damage;

            this.arena.Enroll(this.attacker);
            this.arena.Enroll(this.defender);

            this.arena.Fight(this.attacker.Name, this.defender.Name);

            Assert.AreEqual(expectedAttackerHP, this.attacker.HP);
            Assert.AreEqual(expectedDefenderHP, this.defender.HP);
        }

    }
}