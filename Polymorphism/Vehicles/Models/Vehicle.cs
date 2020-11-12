namespace Vehicles.Models
{
    using System;
    using Vehicles.Common;
    using Vehicles.Models.Contracts;
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        private const string SUCC_DRIVED_MSG = "{0} travelled {1} km";
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; private set; }
        public virtual double FuelConsumption { get; }
        public string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughFuel, this.GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;
            return String.Format(SUCC_DRIVED_MSG, this.GetType().Name, distance);
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NegativeFuel);
            }

            this.FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}