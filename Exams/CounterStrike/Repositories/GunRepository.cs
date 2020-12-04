namespace CounterStrike.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Models.Guns.Contracts;
    using Repositories.Contracts;
    using CounterStrike.Utilities.Messages;

    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models => guns;

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            guns.Add(model);
        }

        public IGun FindByName(string name)
            => this.guns.FirstOrDefault(x => x.Name == name);

        public bool Remove(IGun model)
        {
            return guns.Remove(model);
        }
    }
}
