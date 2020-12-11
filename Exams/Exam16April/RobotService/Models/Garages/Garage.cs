namespace RobotService.Models.Garages
{
    using System;
    using System.Collections.Generic;

    using Garages.Contracts;
    using Robots.Contracts;
    using RobotService.Utilities.Messages;

    public class Garage : IGarage
    {
        private const int CAPACITY = 10;
        private readonly Dictionary<string, IRobot> robots;
        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;

        public void Manufacture(IRobot robot)
        {
            if (this.robots.Count == CAPACITY)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (this.robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            this.robots[robotName].Owner = ownerName;
            this.robots[robotName].IsBought = true;
            this.robots.Remove(robotName);
        }
    }
}
