namespace MilitaryElite.Contracts
{
    using System.Collections.Generic;
    public interface IComando : ISpecialisedSoldier
    {
        public ICollection<IMission> Missions { get; }
        
    }
}