namespace Vehicles.Core.Factories
{
    using System;
    using Common;
    using Models;

    public class VehicleFactory
    {
        public VehicleFactory()
        {

        }
        public Vehicle CreateVehicle(string type, double fuelQty, double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle;
            if (type == "Car")
            {
                vehicle = new Car(fuelQty, fuelConsumption, tankCapacity);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQty, fuelConsumption, tankCapacity);
            }
            else if (type == "Bus")
            {
                vehicle = new Bus(fuelQty, fuelConsumption, tankCapacity);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidType);
            }

            return vehicle;
        }
    }
}