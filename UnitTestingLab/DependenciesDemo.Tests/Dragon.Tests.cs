namespace DependenciesDemo.Tests
{
    using NUnit.Framework;

    using DependenciesDemo.Tests.Fakes;

    [TestFixture]
    public class DragonTests
    {
        [Test]
        public void DragonShouldIntroduceItsName()
        {
            const string name = "Drago";
            //Arrange
            var introducer = new FakeIntroducer();
            var dragon = new Dragon(name, introducer);

            //Act
            dragon.Introduce();

            //Assert
            Assert.That(introducer.Message, Is.EqualTo($"My name is {name}! I am an ancient..."));
        }
    }
}