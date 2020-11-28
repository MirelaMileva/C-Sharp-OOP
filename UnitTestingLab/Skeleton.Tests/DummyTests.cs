namespace Skeleton.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyShouldLoseHealthIfAttacked()
        {
            //Arrange
            var dummy = new Dummy(100, 200);

            //Act
            dummy.TakeAttack(30);

            //Assert
            Assert.That(dummy.Health, Is.EqualTo(70));
        }

        [Test]
        public void DummyThrowsExceptionIfAttackedAndWithoutHealth()
        {
            //Arrange
            var dummy = new Dummy(0, 200);

            //Assert
            Assert
                .That(() => dummy.TakeAttack(30), //Act
                Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead.")
                );
        }

        [Test]
        public void DummyShouldGiveExperienceIfDead()
        {
            //Arrange
            var dummy = new Dummy(0, 200);

            //Act
            var experince = dummy.GiveExperience();

            //Assert
            Assert.That(experince, Is.EqualTo(200));
        }

        [Test]
        public void DummyShouldNotGiveExperienceIfAlive()
        {
            //Arrange
            var dummy = new Dummy(100, 200);

            //Assert
            Assert.That(() => dummy.GiveExperience(),
                Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}
