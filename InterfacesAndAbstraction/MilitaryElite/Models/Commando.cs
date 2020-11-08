﻿namespace MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Enums;
    public class Commando : SpecialisedSoldier, IComando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps, ICollection<IMission> missions) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }

        public ICollection<IMission> Missions { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");

            foreach (var currMission in this.Missions)
            {
                sb.AppendLine("  " + currMission.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}