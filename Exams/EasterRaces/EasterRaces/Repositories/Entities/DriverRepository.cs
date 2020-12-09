namespace EasterRaces.Repositories.Entities
{
    using System.Collections.Generic;

    using Models.Drivers.Contracts;
    public class DriverRepository : Repository<IDriver>
    {
        private readonly List<IDriver> drivers;

        public DriverRepository()
        {
            this.drivers = new List<IDriver>();
        }

    }
}