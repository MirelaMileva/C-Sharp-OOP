namespace CounterStrike.Models.Maps
{
    using System.Collections.Generic;
    using System.Linq;
    using CounterStrike.Models.Players;
    using Maps.Contracts;
    using Players.Contracts;

    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players.Where(terrorist => terrorist.GetType() == typeof(Terrorist)).ToList();

            var counterTerrorists = players.Where(counterTerrorist => counterTerrorist.GetType() == typeof(CounterTerrorist)).ToList();

            while (terrorists.Any(x => x.IsAlive) && counterTerrorists.Any(x => x.IsAlive))
            {
                foreach (var terro in terrorists.Where(t => t.IsAlive))
                {
                    foreach (var counterTerro in counterTerrorists.Where(c => c.IsAlive))
                    {
                        counterTerro.TakeDamage(terro.Gun.Fire());
                    }
                }

                foreach (var counterTerro in counterTerrorists.Where(c => c.IsAlive))
                {
                    foreach (var terro in terrorists.Where(t => t.IsAlive))
                    {
                        terro.TakeDamage(counterTerro.Gun.Fire());
                    }
                }
            }

            string result = string.Empty;

            if (terrorists.Any(x => x.IsAlive))
            {
                return "Terrorist wins!"; 
            }
            else
            {
                return "Counter Terrorist wins!";
            }
        }
    }
}
