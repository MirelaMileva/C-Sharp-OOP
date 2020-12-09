namespace EasterRaces.Core.Entities
{
    using System;
    using System.Linq;
    using System.Text;
    using Core.Contracts;

    using EasterRaces.Models.Races;
    using EasterRaces.Models.Races.Contracts;
    using Models.Cars.Contracts;
    using Models.Cars.Entities;
    using Models.Drivers;
    using Models.Drivers.Contracts;
    using Repositories.Contracts;
    using Repositories.Entities;
    using Utilities.Messages;

    public class ChampionshipController : IChampionshipController
    {
        private const int MIN_PARTICIPANTS = 3;
        private readonly IRepository<IDriver> drivers;
        private readonly IRepository<ICar> cars;
        private readonly IRepository<IRace> races;

        public ChampionshipController()
        {
            this.drivers = new DriverRepository();
            this.cars = new CarRepositoty();
            this.races = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            if (!this.drivers.GetAll().Any(d => d.Name == driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (!this.cars.GetAll().Any(d => d.Model == carModel))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            var driver = this.drivers.GetAll().FirstOrDefault(d => d.Name == driverName);
            var car = this.cars.GetAll().FirstOrDefault(c => c.Model == carModel);
            driver.AddCar(car);

            string message = string.Format(OutputMessages.CarAdded, driverName, carModel);
            return message;
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (!this.races.GetAll().Any(r => r.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (!this.drivers.GetAll().Any(d => d.Name == driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            var race = this.races.GetAll().FirstOrDefault(r => r.Name == raceName);
            var driver = this.drivers.GetAll().FirstOrDefault(d => d.Name == driverName);
            race.AddDriver(driver);

            string message = string.Format(OutputMessages.DriverAdded, driverName, raceName);

            return message;
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.cars.GetAll().Any(c => c.Model == model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            ICar car;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.CarInvalid);
            }

            this.cars.Add(car);

            string result = string.Format(OutputMessages.CarCreated, car.GetType().Name, model);

            return result;

        }

        public string CreateDriver(string driverName)
        {
            if (this.drivers.GetAll().Any(d => d.Name == driverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            Driver driver = new Driver(driverName);

            this.drivers.Add(driver);

            string result = string.Format(OutputMessages.DriverCreated, driverName);
            return result;
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.GetAll().Any(r => r.Name == name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            Race race = new Race(name, laps);

            this.races.Add(race);

            string message = string.Format(OutputMessages.RaceCreated, name);

            return message;
        }

        public string StartRace(string raceName)
        {
            if (!this.races.GetAll().Any(r => r.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IRace race = this.races.GetAll().FirstOrDefault(r => r.Name == raceName);

            if (race.Drivers.Count < MIN_PARTICIPANTS)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, MIN_PARTICIPANTS));
            }

            int laps = race.Laps;
            var bestDrivers = race.Drivers.ToList().OrderByDescending(d => d.Car.CalculateRacePoints(laps)).Take(3).ToList();

            this.races.Remove(race);

            StringBuilder sb = new StringBuilder();
            string result = null;
            int count = 1;

            foreach (var driver in bestDrivers)
            {
                if (count == 1)
                {
                    result = string.Format(OutputMessages.DriverFirstPosition, driver.Name, raceName);
                }
                else if (count == 2)
                {
                    result = string.Format(OutputMessages.DriverSecondPosition, driver.Name, raceName);
                }
                else
                {
                    result = string.Format(OutputMessages.DriverThirdPosition, driver.Name, raceName);
                }

                sb.AppendLine(result);
                count++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}