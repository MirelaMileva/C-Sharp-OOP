namespace EasterRaces.Models.Cars
{
    using System;

    using Contracts;
    using EasterRaces.Utilities.Messages;

    public abstract class Car : ICar
    {
        private const int MIN_SYMBOL_FOR_MODEL = 4;

        private string model;

        public Car(string model, int horsePower)
        {
            this.Model = model;
            this.HorsePower = horsePower;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_SYMBOL_FOR_MODEL)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, MIN_SYMBOL_FOR_MODEL));
                }

                this.model = value;
            }
        }
        public abstract int HorsePower { get; protected set; }
        public abstract double CubicCentimeters { get;}

        public double CalculateRacePoints(int laps)
        {
            double result = CubicCentimeters / HorsePower * laps;

            return result;
        }
    }
}