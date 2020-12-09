namespace EasterRaces.Repositories.Entities
{
    using System.Collections.Generic;

    using Models.Cars.Contracts;

    public class CarRepositoty : Repository<ICar>
    {
        private readonly List<ICar> cars;

        public CarRepositoty()
        {
            this.cars = new List<ICar>();
        }
    }
}