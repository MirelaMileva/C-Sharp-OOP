using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double SPORTCAR_CUBIC_CENTIMETERS = 3000;
        private const int MIN_HORSEPOWER = 250;
        private const int MAX_HORSEPOWER = 450;
        private int horsePower;
        public SportsCar(string model, int horsePower) 
            : base(model, horsePower)
        {
            this.CubicCentimeters = SPORTCAR_CUBIC_CENTIMETERS;
        }

        public override double CubicCentimeters { get; }
        public override int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            protected set
            {
                if (value < MIN_HORSEPOWER || value > MAX_HORSEPOWER)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }
    }
}
