namespace CounterStrike.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Utilities.Messages;
    using Models.Players.Contracts;
    using Contracts;

    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => players;

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            players.Add(model);
        }

        public IPlayer FindByName(string name)
            => this.players.FirstOrDefault(x => x.Username == name);

        public bool Remove(IPlayer model)
        {
            return players.Remove(model);
        }
    }
}