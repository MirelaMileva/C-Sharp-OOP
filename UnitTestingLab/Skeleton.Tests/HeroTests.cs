namespace Skeleton.Tests
{
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroShouldGainExperienceIfTargetDies()
        {
            const int experience = 200;
            //Arrange

            //var weapon = new FakeWeapon();
            //var target = new FakeTarget();
            //var hero = new Hero("TestHero", weapon);

            var fakeWeapon = Mock.Of<IWeapon>();
            var fakeTarget = new Mock<ITarget>();

            fakeTarget
                .Setup(t => t.IsDead())
                .Returns(true);

            fakeTarget
                .Setup(t => t.GiveExperience())
                .Returns(experience);

            var hero = new Hero("TestHero", fakeWeapon);

            //Act
            hero.Attack(fakeTarget.Object);

            //Assert
            Assert.That(hero.Experience, Is.EqualTo(experience));
        }
    }
}