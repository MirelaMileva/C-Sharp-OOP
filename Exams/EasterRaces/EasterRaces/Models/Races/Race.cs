namespace EasterRaces.Models.Races
{
    using System;
    using System.Collections.Generic;

    using EasterRaces.Utilities.Messages;
    using Models.Drivers.Contracts;
    using Models.Races.Contracts;

    public class Race : IRace
    {
        private const int MIN_NAME_LENGHT = 5;
        private const int MIN_LAPS = 1;

        private string name;
        private int laps;
        private readonly List<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
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

        public int Laps
        {
            get
            {
                return this.laps;
            }
            private set
            {
                if (value < MIN_LAPS)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, MIN_LAPS));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentException(ExceptionMessages.DriverInvalid);
            }
            else if (driver.CanParticipate == false)
            {
                throw new ArgumentException(ExceptionMessages.DriverNotParticipate);
            }
            else if (this.drivers.Contains(driver))
            {
                throw new ArgumentException(ExceptionMessages.DriverAlreadyAdded);
            }

            this.drivers.Add(driver);
        }
    }
}
