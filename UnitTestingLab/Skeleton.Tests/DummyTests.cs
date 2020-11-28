namespace Skeleton.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DummyTests
    {
        private const int Experience = 200;
        private const int AttackPoints = 30;
        private const int DeadDummyHealth = 0;
        private const int AliveDummyHealth = 100;

        private Dummy aliveDummy;
        private Dummy deadDummy;

        [SetUp]
        public void SetDummies()
        {
            this.aliveDummy = new Dummy(AliveDummyHealth, Experience);
            this.deadDummy = new Dummy(DeadDummyHealth, Experience);
        }
        [Test]
        public void DummyShouldLoseHealthIfAttacked()
        {
            //Act
            this.aliveDummy.TakeAttack(AttackPoints);

            //Assert
            Assert.That(this.aliveDummy.Health, Is.EqualTo(70));
        }

        [Test]
        public void DummyThrowsExceptionIfAttackedAndWithoutHealth()
        {
            //Assert
            Assert
                .That(() => this.deadDummy.TakeAttack(AttackPoints), //Act
                Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead.")
                );
        }

        [Test]
        public void DummyShouldGiveExperienceIfDead()
        {
            //Act
            var experince = this.deadDummy.GiveExperience();

            //Assert
            Assert.That(experince, Is.EqualTo(Experience));
        }

        [Test]
        public void DummyShouldNotGiveExperienceIfAlive()
        {
            //Assert
            Assert.That(() => this.aliveDummy.GiveExperience(),
                Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}
