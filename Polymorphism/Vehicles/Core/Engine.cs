namespace Vehicles.Core
{
    using Contracts;
    using Models;
    using System;
    using System.Linq;
    using System.Net.Http.Headers;
    using Vehicles.Core.Factories;

    public class Engine : IEngine
    {
        private VehicleFactory vehicleFactory;

        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
        }
        public void Run()
        {
            Vehicle car = ProcessVehicleInfo();
            Vehicle truck = ProcessVehicleInfo();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];
                string vehicleType = cmdArgs[1];
                double arg = double.Parse(cmdArgs[2]);

                try
                {
                    if (cmdType == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Drive(car, arg);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Drive(truck, arg);
                        }
                    }
                    else if (cmdType == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Refuel(car, arg);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Refuel(truck, arg);
                        }
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
               
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private void Refuel(Vehicle vehicle, double amount)
        {
            vehicle.Refuel(amount);
        }
        private void Drive(Vehicle vehicle, double kilometers)
        {
            Console.WriteLine(vehicle.Drive(kilometers));
        }

        private Vehicle ProcessVehicleInfo()
        {
            string[] vehicleArgs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string vehicleType = vehicleArgs[0];
            double fuelQuantity = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);

            Vehicle vehicle = this.vehicleFactory.CreateVehicle(vehicleType, fuelQuantity, fuelConsumption);

            return vehicle;
        }
    }
}