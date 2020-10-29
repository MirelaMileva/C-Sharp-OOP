using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double CAR_FUEL_CONSUMPRION = 3;
        public Car(int horsePower, double fuel)
            : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption => CAR_FUEL_CONSUMPRION;
    }
}
