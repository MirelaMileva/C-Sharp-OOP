namespace Skeleton.Tests
{
    using NUnit.Framework;

    using Skeleton.Tests.Fake;

    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroShouldGainExperienceIfTargetDies()
        {
            //Arrange
            var weapon = new FakeWeapon();
            var target = new FakeTarget();
            var hero = new Hero("TestHero", weapon);

            //Act
            hero.Attack(target);

            //Assert
            Assert.That(hero.Experience, Is.EqualTo(FakeTarget.DefaultExperience));
        }
    }
}