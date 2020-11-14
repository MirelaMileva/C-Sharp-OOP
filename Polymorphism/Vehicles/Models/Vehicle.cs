namespace Vehicles.Models
{
    using System;
    using Common;
    using Models.Contracts;
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        private const string SUCC_DRIVED_MSG = "{0} travelled {1} km";

        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }
        public double FuelQuantity 
        { 
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }

                this.fuelQuantity = value;
            }
        }
        public virtual double FuelConsumption { get; private set; }
        public double TankCapacity { get; private set; }
        public virtual string Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NotEnoughFuel, this.GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;
            return String.Format(SUCC_DRIVED_MSG, this.GetType().Name, distance);
        }

        public virtual string DriveEmpty(double distance)
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
            else if (amount + this.fuelQuantity > this.TankCapacity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NoSpaceInTank, amount));
            }
            else
            {
                this.FuelQuantity += amount;
            }
            
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}