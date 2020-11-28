namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTests
    {
        private const int AttackPoints = 10;


        [Test]
        public void AxeShouldLoseDurabilityAfterAttack()
        {
            //Arrange
            var axe = new Axe(AttackPoints, 5);
            var target = new Dummy(100, 500);

            //Act
            axe.Attack(target);

            //Assert
            Assert.That(axe.DurabilityPoints, Is.EqualTo(4));
        }

        [Test]
        public void AxeShouldThrowExceptionIfAnAttackIsMadeWithBrokenWeapon()
        {
            //Arrange
            var axe = new Axe(AttackPoints, 0);
            var target = new Dummy(100, 500);

            //Assert
            Assert
                .That(() => axe.Attack(target), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}
