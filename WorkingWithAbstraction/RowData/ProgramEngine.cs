﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RowData
{
    public class ProgramEngine
    {
        private readonly List<Car> cars;
        private List<Tire> carTires;

        public ProgramEngine()
        {
            this.cars = new List<Car>();
            this.carTires = new List<Tire>();
        }

        public void Run()
        {
            int lines = int.Parse(Console.ReadLine());

            ParseInput(lines);

            PrintOutput();
        }

        private void PrintOutput()
        {
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                    .Select(c => c.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        private void ParseInput(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = parameters[0];
                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];

                Engine engine = this.CreateEngine(engineSpeed, enginePower);
                Cargo cargo = this.CreateCargo(cargoWeight, cargoType);

                ReadTires(parameters);

                Car car = this.CreateCar(model, engine, cargo, carTires);

                this.cars.Add(car);
            }
        }

        private void ReadTires(string[] parameters)
        {
            for (int j = 5; j <= 12; j += 2)
            {
                double currentTirePressure = double.Parse(parameters[j]);
                int currentTireAge = int.Parse(parameters[j + 1]);

                Tire currentTire = CreateTire(currentTirePressure, currentTireAge);

                carTires.Add(currentTire);
            }
        }

        private Car CreateCar(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            Car car = new Car(model, engine, cargo, tires.ToArray());

            return car;
        }
        private Tire CreateTire(double pressure, int age)
        {
            Tire tire = new Tire(pressure, age);

            return tire;
        }
        private Cargo CreateCargo(int weight, string type)
        {
            Cargo cargo = new Cargo(weight, type);

            return cargo;
        }
        private Engine CreateEngine(int speed, int power)
        {
            Engine engine = new Engine(speed, power);

            return engine;
        }

    }
}
