namespace DependenciesDemo.Tests
{
    using NUnit.Framework;

    using Moq;

    [TestFixture]
    public class DragonTests
    {
        [Test]
        public void DragonShouldIntroduceItsName()
        {
            const string name = "Drago";

            //Arrange

            //var introducer = new FakeIntroducer();
            //var dragon = new Dragon(name, introducer);

            var fakeIntroducer = new Mock<IIntroducer>();
            var introducedMessage = string.Empty;

            fakeIntroducer
                .Setup(i => i.Introduce(It.IsAny<string>()))
                .Callback((string message) => introducedMessage = message);

            var dragon = new Dragon(name, fakeIntroducer.Object);

            //Act
            dragon.Introduce();

            //Assert
            Assert.That(introducedMessage, Is.EqualTo($"My name is {name}! I am an ancient..."));
        }
    }
}