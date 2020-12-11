namespace RobotService.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Models.Garages;
    using Models.Garages.Contracts;
    using Models.Robots;
    using Models.Robots.Contracts;
    using Models.Procedures;
    using Models.Procedures.Contracts;
    using Utilities.Messages;
    using Utilities.Enums;

    public class Controller : IController
    {
        private readonly IGarage garage;
        private readonly Dictionary<ProcedureType, IProcedure> procedures;

        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new Dictionary<ProcedureType, IProcedure>();
            this.SeedProcedure();
        }

        public string Charge(string robotName, int procedureTime)
        {
            IRobot robot = this.GetRobotByName(robotName);

            string outputMsg = this.DoService
                (robot,
                procedureTime, 
                ProcedureType.Charge, 
                OutputMessages.ChargeProcedure);

            return outputMsg;
        }

        public string Chip(string robotName, int procedureTime)
        {
            IRobot robot = this.GetRobotByName(robotName);

            string outputMsg = this.DoService
                (robot,
                procedureTime,
                ProcedureType.Chip,
                OutputMessages.ChipProcedure);

            return outputMsg;
        }

        public string History(string procedureType)
        {
            Enum.TryParse(procedureType, out ProcedureType procedureTypeEnum);
            IProcedure procedure = this.procedures[procedureTypeEnum];

            return procedure.History().Trim();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;

            if (robotType == nameof(HouseholdRobot))
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == nameof(PetRobot))
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == nameof(WalkerRobot))
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            this.garage.Manufacture(robot);

            string msg = string.Format(OutputMessages.RobotManufactured, name);
            return msg;
        }

        public string Polish(string robotName, int procedureTime)
        {
            IRobot robot = this.GetRobotByName(robotName);

            string outputMsg = this.DoService
                (robot,
                procedureTime,
                ProcedureType.Polish,
                OutputMessages.PolishProcedure);

            return outputMsg;
        }

        public string Rest(string robotName, int procedureTime)
        {
            IRobot robot = this.GetRobotByName(robotName);

            string outputMsg = this.DoService
                 (robot,
                 procedureTime,
                 ProcedureType.Rest,
                 OutputMessages.RestProcedure);

            return outputMsg;
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = this.GetRobotByName(robotName);

            this.garage.Sell(robotName, ownerName);
            string result = string.Empty;

            if (robot.IsChipped)
            {
                result = string.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                result = string.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }

            return result;
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IRobot robot = this.GetRobotByName(robotName);

            string outputMsg = this.DoService
                (robot,
                procedureTime,
                ProcedureType.TechCheck,
                OutputMessages.TechCheckProcedure);

            return outputMsg;
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = this.GetRobotByName(robotName);

            IProcedure procedure = this.procedures[ProcedureType.Work];
            procedure.DoService(robot, procedureTime);

            string outputMsg = string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
            return outputMsg;
        }

        private string DoService(IRobot robot, int procedureTime, ProcedureType procedureType, string outputTemplate)
        {
            IProcedure procedure = this.procedures[procedureType];
            procedure.DoService(robot, procedureTime);
            string outputMsg = string.Format(outputTemplate, robot.Name);
            return outputMsg;
        }
        private IRobot GetRobotByName(string name)
        {
            if (!this.garage.Robots.ContainsKey(name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, name));
            }

            return this.garage.Robots[name];
        }
        private void SeedProcedure()
        {
            this.procedures.Add(ProcedureType.Charge, new Charge());
            this.procedures.Add(ProcedureType.Chip, new Chip());
            this.procedures.Add(ProcedureType.Polish, new Polish());
            this.procedures.Add(ProcedureType.Rest, new Rest());
            this.procedures.Add(ProcedureType.Work, new Work());
            this.procedures.Add(ProcedureType.TechCheck, new TechCheck());
        }
    }
}
