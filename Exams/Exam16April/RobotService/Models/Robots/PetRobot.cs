namespace RobotService.Models.Robots
{
    public class PetRobot : Robot
    {
        public PetRobot(string name, int energy, int happiness, int produceTime) 
            : base(name, energy, happiness, produceTime)
        {

        }
    }
}