namespace EasterRaces.Models.Drivers
{
    using System;

    using Models.Cars.Contracts;
    using Models.Drivers.Contracts;
    using Utilities.Messages;
    public class Driver : IDriver
    {
        private const int MIN_NAME_LENGHT = 5;

        private string name;
        private bool canParticipate;

        public Driver(string name)
        {
            this.Name = name;
            this.canParticipate = false;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MIN_NAME_LENGHT)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, MIN_NAME_LENGHT));
                }

                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get
            {
                return this.canParticipate;
            }
            private set
            {
                if (this.Car != null)
                {
                    this.canParticipate = true;
                }
                else
                {
                    this.canParticipate = false;
                }
            }
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarInvalid);
            }

            this.Car = car;
            this.CanParticipate = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
