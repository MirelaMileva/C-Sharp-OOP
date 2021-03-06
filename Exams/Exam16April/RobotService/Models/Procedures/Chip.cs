﻿namespace RobotService.Models.Procedures
{
    using System;

    using Models.Robots.Contracts;
    using Utilities.Messages;
    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            if (robot.IsChipped)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AlreadyChipped, robot.Name));
            }

            robot.ProcedureTime -= procedureTime;
            robot.Happiness -= 5;
            robot.IsChipped = true;
            this.Robots.Add(robot);
        }
    }
}