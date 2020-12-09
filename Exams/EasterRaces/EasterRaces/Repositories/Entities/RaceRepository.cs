namespace EasterRaces.Repositories.Entities
{
    using System.Collections.Generic;

    using Models.Races.Contracts;

    public class RaceRepository : Repository<IRace>
    {
        private readonly List<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

    }    
}