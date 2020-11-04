using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;
        private Stats stats;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.EmptyNameExceptionMessage);
                }
                this.name = value;
            }
        }
        public Stats Stats
        {
            get
            {
                return this.stats;
            }
            private set
            {
                this.stats = value;
            }
        }

        public double OverallSkill =>
            this.Stats.AverageStats;
    }
}
