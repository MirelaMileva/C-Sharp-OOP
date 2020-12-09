namespace TheRace.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RaceEntryTests
    {
        private UnitDriver driver;
        private UnitCar car;

        [SetUp]
        public void Setup()
        {
            this.car = new UnitCar("Toyota", 350, 3000.00);
            this.driver = new UnitDriver("Pesho", this.car);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            RaceEntry race = new RaceEntry();
            int expected = 0;

            Assert.That(race.Counter, Is.EqualTo(expected));
        }

        [Test]
        public void AddDriverShouldIncreaseCount()
        {
            RaceEntry race = new RaceEntry();
            race.AddDriver(driver);

            var excpected = 1;
            Assert.That(race.Counter, Is.EqualTo(excpected));
        }

        [Test]
        public void AddShouldThrowExceptionIfDriverIsNull()
        {
            RaceEntry race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(
                () => 
                {
                    race.AddDriver(null);
                });
        }

        [Test]
        public void AddShouldThrowExceptionWhenDriverExcist()
        {
            RaceEntry race = new RaceEntry();
            UnitCar car = new UnitCar("Toyota", 350, 3000.00);
            UnitDriver driver = new UnitDriver("Pesho", car);
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(
                () => 
                {
                    race.AddDriver(driver);
                });
        }

        [Test]
        public void CalculateAverageHorsePowerShouldWorkCorrectly()
        {
            RaceEntry race = new RaceEntry();
            race.AddDriver(this.driver);
            UnitCar car = new UnitCar("Opel", 250, 2500.00);
            UnitDriver secondDriver = new UnitDriver("Mimi", car);
            race.AddDriver(secondDriver);

            double excpected = (this.car.HorsePower + car.HorsePower) / 2;

            Assert.That(race.CalculateAverageHorsePower, Is.EqualTo(excpected));
        }
        [Test]
        public void CalculateAverageHorsePowerShouldThrowExceptionWhenCountIsUnderMinimum()
        {
            RaceEntry race = new RaceEntry();
            race.AddDriver(this.driver);

            Assert.Throws<InvalidOperationException>(
                () => { race.CalculateAverageHorsePower(); });
        }
    }
}