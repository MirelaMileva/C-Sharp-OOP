using EasterRaces.Utilities.Messages;
using System;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double MUSCLE_CUBIC_CENTIMETERS = 5000;
        private const int MIN_HORSEPOWER = 400;
        private const int MAX_HORSEPOWER = 600;
        private int horsePower;
        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower)
        {
            this.CubicCentimeters = MUSCLE_CUBIC_CENTIMETERS;
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
