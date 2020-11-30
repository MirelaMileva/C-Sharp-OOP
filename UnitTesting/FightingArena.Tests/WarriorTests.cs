namespace FightingArena.Tests
{
    using NUnit.Framework;

    using System;

    public class WarriorTests
    {
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedName = "Pesho";
            int expectedDmg = 50;
            int expectedHP = 100;

            Warrior warrior = new Warrior(expectedName, expectedDmg, expectedHP);

            string actualName = warrior.Name;
            int actualDmg = warrior.Damage;
            int actualHP = warrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDmg, actualDmg);
            Assert.AreEqual(expectedHP, actualHP);
        }

        [Test]
        public void TestWithLikeNullName()
        {
            string name = null;
            int dmg = 50;
            int hp = 100;

            Assert
                .Throws<ArgumentException>(
                () =>
                {
                    Warrior warrior = new Warrior(name, dmg, hp);
                });
        }

        [Test]
        public void TestWithLikeEmptyName()
        {
            string name = String.Empty;
            int dmg = 50;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });
        }

        [Test]
        public void TestWithLikeWhiteSpaceName()
        {
            string name = " ";
            int dmg = 50;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });
        }

        [Test]
        public void TestWithLikeZeroDamage()
        {
            string name = "Pesho";
            int dmg = 0;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });
        }

        [Test]
        public void TestWithLikeNegativeDamage()
        {
            string name = "Pesho";
            int dmg = -10;
            int hp = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });
        }

        [Test]
        public void TestWithLikeNegativeHP()
        {
            string name = "Pesho";
            int dmg = 50;
            int hp = -10;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, dmg, hp);
            });
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackEnemyWhenLowHPShouldThrowException(int attackerHp)
        {
            string attackerName = "Pesho";
            int attackerDmg = 10;

            string defenderName = "Gosho";
            int defenderDmg = 10;
            int defenderHP = 40;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHp);

            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHP);

            Assert
                .Throws<InvalidOperationException>(
                () =>
                {
                    attacker.Attack(defender);
                });
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackEnemyWithLowHPShouldThrowException(int defenderHP)
        {
            string attackerName = "Pesho";
            int attackerDmg = 10;
            int attackerHP = 100;

            string defenderName = "Gosho";
            int defenderDmg = 10;


            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);

            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHP);

            Assert
                .Throws<InvalidOperationException>(
                () => 
                {
                    attacker.Attack(defender);
                });
        }

        [Test]
        public void AttackStrongerEnemyShouldThrowException()
        {
            string attackerName = "Pesho";
            int attackerDmg = 10;
            int attackerHP = 35;

            string defenderName = "Gosho";
            int defenderDmg = 40;
            int defenderHP = 35;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);

            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHP);

            Assert
                .Throws<InvalidOperationException>(
                () => 
                {
                    attacker.Attack(defender);
                });
        }

        [Test]
        public void AttackShouldDecreaseHPWhenSuccessfull()
        {
            string attackerName = "Pesho";
            int attackerDmg = 10;
            int attackerHP = 40;

            string defenderName = "Gosho";
            int defenderDmg = 5;
            int defenderHP = 50;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);

            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHP);

            int expectedAttackerHP = attackerHP - defenderDmg;
            int expectedDefenderHP = defenderHP - attackerDmg;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [Test]
        public void TestKillingEnemyWithAttack()
        {
            string attackerName = "Pesho";
            int attackerDmg = 80;
            int attackerHP = 100;

            string defenderName = "Gosho";
            int defenderDmg = 10;
            int defenderHP = 60;

            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);

            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHP);

            int expectedAttackerHP = attackerHP - defenderDmg;
            int expectedDefenderHP = 0;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }
    }
}
