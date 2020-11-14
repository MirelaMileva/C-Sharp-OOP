using System;
using Vehicles.Common;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCR = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override double FuelConsumption => base.FuelConsumption;

        public override string Drive(double distance)
        {
            double fuelNeeded = distance * (this.FuelConsumption + FUEL_CONSUMPTION_INCR);

            if (this.FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughFuel, this.GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public override string DriveEmpty(double distance)
        {
            return base.DriveEmpty(distance);
        }

    }
}
