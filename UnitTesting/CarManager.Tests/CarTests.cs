using NUnit.Framework;
using System;

namespace CarManager.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedMake = "Toyota";
            string expectedModel = "Auris";
            double expFuelConsumption = 6.0;
            double expFuelCapacity = 100;

            Car car = new Car(expectedMake, expectedModel, expFuelConsumption, expFuelCapacity);

            string actualMake = car.Make;
            string actualModel = car.Model;
            double actualFuelConsumption = car.FuelConsumption;
            double actualFuelCapacity = car.FuelCapacity;

            Assert.AreEqual(expectedMake, actualMake);
            Assert.AreEqual(expectedModel, actualModel);
            Assert.AreEqual(expFuelConsumption, actualFuelConsumption);
            Assert.AreEqual(expFuelCapacity, actualFuelCapacity);
        }

        [Test]
        public void MakeShouldThrowExceptionIfItsNull()
        {
            string make = null;
            string model = "Auris";
            double fuelConsumption = 6.0;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>(
                () => 
                {
                    Car car = new Car(make, model, fuelConsumption, fuelCapacity);
                });
           
        }

        [Test]
        public void MakeShouldThrowExceptionIfItsEmpty()
        {
            string make = string.Empty;
            string model = "Auris";
            double fuelConsumption = 6.0;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>(
                () =>
                {
                    Car car = new Car(make, model, fuelConsumption, fuelCapacity);
                });

        }
        [Test]
        public void ModelShouldThrowExceptionIfItNull()
        {
            string make = "Toyota";
            string model = null;
            double fuelConsumption = 6.0;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>(
                () =>
                {
                    Car car = new Car(make, model, fuelConsumption, fuelCapacity);
                });

        }

        [Test]
        public void ModelShouldThrowExceptionIfItEmpty()
        {
            string make = "Toyota";
            string model = string.Empty;
            double fuelConsumption = 6.0;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>(
                () =>
                {
                    Car car = new Car(make, model, fuelConsumption, fuelCapacity);
                });

        }

        [Test]
        public void FuelConsumptionShouldThrowExceptionIfZero()
        {
            string make = "Toyota";
            string model = "Auris";
            double fuelConsumption = 0;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>(
                () =>
                {
                    Car car = new Car(make, model, fuelConsumption, fuelCapacity);
                });
        }

        [Test]
        public void FuelConsumptionShouldThrowExceptionIfNegative()
        {
            string make = "Toyota";
            string model = "Auris";
            double fuelConsumption = -5;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>(
                () =>
                {
                    Car car = new Car(make, model, fuelConsumption, fuelCapacity);
                });
        }

        [Test]
        public void FuelCapacityShouldThrowExceptionIfZero()
        {
            string make = "Toyota";
            string model = "Auris";
            double fuelConsumption = 5.5;
            double fuelCapacity = 0;

            Assert.Throws<ArgumentException>(
                () =>
                {
                    Car car = new Car(make, model, fuelConsumption, fuelCapacity);
                });
        }

        [Test]
        public void FuelCapacityShouldThrowExceptionIfNegative()
        {
            string make = "Toyota";
            string model = "Auris";
            double fuelConsumption = 5.5;
            double fuelCapacity = -10;

            Assert.Throws<ArgumentException>(
                () =>
                {
                    Car car = new Car(make, model, fuelConsumption, fuelCapacity);
                });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelShouldThrowExceptionIfPassedVAlueIsBelowOrEqualToZero(double value)
        {
            Car car = new Car("Toyota", "Auris", 10, 1000);

            Assert.Throws<ArgumentException>(
                () =>
                {
                    car.Refuel(value);
                });
        }

        [Test]
        [TestCase(1000, 50, 50)]
        [TestCase(200, 350, 200)]
        public void RefuelShouldIncreaseWithFuelAmount(double fuelCapacity, double fuelAmount, double expectedResult)
        {
            //Arrange
            Car car = new Car("Toyota", "Auris", 10, fuelCapacity);

            //Act
            car.Refuel(fuelAmount);

            //Assert
            var actualResult = car.FuelAmount;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DriveShouldDecreaseFuelAmount()
        {
            //Arrange
            Car car = new Car("Toyota", "Auris", 10, 100);
            car.Refuel(100);

            //Act
            car.Drive(50);

            //Assert
            var expectedResult = 95;
            var actualResult = car.FuelAmount;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DriveShouldThrowExceptionIfNotEnoughFuel()
        {
            //Arrange
            Car car = new Car("Toyota", "Auris", 50, 100);

            //Act
            car.Refuel(10);

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => 
                {
                    car.Drive(600);
                });
        }
    }
}