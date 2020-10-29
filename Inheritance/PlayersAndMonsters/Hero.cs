using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        private string username;
        private int level;
        public Hero(string username, int level)
        {
            this.Username = username;
            this.Level = level;
        }

        public string Username 
        { 
            get
            {
                return this.username;
            }
            private set
            {
                this.username = value;
            }
        }
        public int Level { get; set; }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
