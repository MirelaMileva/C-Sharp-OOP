namespace RobotService.Models.Procedures
{
    using Models.Robots.Contracts;
    public class TechCheck : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            robot.Energy -= 8;
            if (!robot.IsChecked)
            {
                robot.IsChecked = true;
            }
            else
            {
                robot.Energy -= 8;
            }

            robot.ProcedureTime -= procedureTime;
            this.Robots.Add(robot);

        }
    }
}