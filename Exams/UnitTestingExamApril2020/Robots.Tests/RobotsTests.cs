namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            var robotManager = new RobotManager(100);

            Assert.AreEqual(100, robotManager.Capacity);
        }

        [Test]
        public void CapacityShouldThrowExceptionWhenIsInvalid()
        {
            Assert.Throws<ArgumentException>(
                () => 
                {
                    new RobotManager(-100);
                });
        }

        [Test]
        public void RobotsCountShouldCountProperly()
        {
            var robotManager = new RobotManager(100);
            var robot = new Robot("Gosho", 100);
            robotManager.Add(robot);

            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void RobotManagerAddMethodShouldThrowExceptionForDuplicateRabotNames()
        {
            var robot = new Robot("Pesho", 80);
            var robotManager = new RobotManager(10);

            robotManager.Add(robot);
            
            Assert.Throws<InvalidOperationException>(
                () => { robotManager.Add(robot); });
        }

        [Test]
        public void RobotManagerAddMethodShouldThrowExceptionForInvalidCapacity()
        {
            var robot = new Robot("Pesho", 80);
            var robotManager = new RobotManager(1);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => { robotManager.Add(robot); });
        }

        [Test]
        public void RobotManagerRemoveMethodShouldWorkProperly()
        {
            var robot = new Robot("Pesho", 80);
            var robotManager = new RobotManager(1);

            robotManager.Add(robot);
            robotManager.Remove("Pesho");

            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void RobotManagerRemoveMethodShouldThrowExceptionForInvalidRobotName()
        {
            var robotManager = new RobotManager(1);

            Assert.Throws<InvalidOperationException>(() => { robotManager.Remove("Pesho"); });
        }

        [Test]
        public void WorkMethodShouldDecreaseBattery()
        {
            var robot = new Robot("Pesho", 80);
            var robotManager = new RobotManager(1);

            robotManager.Add(robot);

            robotManager.Work("Pesho", "Cleaning", 20);

            Assert.AreEqual(60, robot.Battery);
        }

        [Test]
        public void WorkMethodShouldThrowExceptionForInvalidRobot()
        {
            var robotManager = new RobotManager(1);

            Assert.Throws<InvalidOperationException>(
                () => { robotManager.Work("Pesho", "Cleaning", 20); });
        }

        [Test]
        public void WorkMethodShouldThrowExceptionWhenRobotDoesNotHaveEnoughBattery()
        {
            var robot = new Robot("Pesho", 10);
            var robotManager = new RobotManager(1);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => { robotManager.Work("Pesho", "Cleaning", 20); });
        }

        [Test]
        public void ChargeShouldThrowExceptionForInvalidRobot()
        {
            var robotManager = new RobotManager(1);

            Assert.Throws<InvalidOperationException>(
                () => { robotManager.Charge("Invalid"); });
        }

        [Test]
        public void ChargeShouldSetToMaximumBattery()
        {
            var robot = new Robot("Pesho", 80);
            var robotManager = new RobotManager(1);

            robotManager.Add(robot);
            robotManager.Work("Pesho", "Cleaning", 20);

            robotManager.Charge("Pesho");

            Assert.AreEqual(80, robot.Battery);
        }
    }
}
