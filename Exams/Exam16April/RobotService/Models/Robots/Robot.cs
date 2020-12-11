namespace RobotService.Models.Robots
{
    using System;

    using Models.Robots.Contracts;
    using Utilities.Messages;

    public abstract class Robot : IRobot
    {
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 100;
        private const string DEFAULT_OWNER_NAME = "Service";

        private int happiness;
        private int energy;

        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.Owner = DEFAULT_OWNER_NAME;
        }

        public string Name { get; }
        public int Happiness 
        { 
            get
            {
                return this.happiness;
            }
            set
            {
                if (value < MIN_VALUE || value > MAX_VALUE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }

                this.happiness = value;
            }
        }

        public int Energy 
        {
            get
            {
                return this.energy;
            }
            set
            {
                if (value < MIN_VALUE || value > MAX_VALUE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }

                this.energy = value;
            }
        }
        public int ProcedureTime { get; set; }
        public string Owner { get; set; }
        public bool IsBought { get; set; }
        public bool IsChipped { get; set; }
        public bool IsChecked { get; set; }

        public override string ToString()
        {
            return $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}