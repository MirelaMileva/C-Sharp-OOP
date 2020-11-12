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
        public Vehicle CreateVehicle(string type, double fuelQty, double fuelConsumption)
        {
            Vehicle vehicle;
            if (type == "Car")
            {
                vehicle = new Car(fuelQty, fuelConsumption);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQty, fuelConsumption);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidType);
            }

            return vehicle;
        }
    }
}
