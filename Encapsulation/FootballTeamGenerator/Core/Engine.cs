using FootballTeamGenerator.Common;
using FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }
        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] commandArg = command.Split(';', StringSplitOptions.None).ToArray();

                    string cmdType = commandArg[0];

                    if (cmdType == "Team")
                    {
                        AddTeam(commandArg);
                    }
                    else if (cmdType == "Add")
                    {
                        AddPlayerToTeam(commandArg);
                    }
                    else if (cmdType == "Remove")
                    {
                        RemovePlayer(commandArg);
                    }
                    else if (cmdType == "Rating")
                    {
                        PrintRating(commandArg);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
                
            }
        }

        private void PrintRating(string[] commandArg)
        {
            string teamName = commandArg[1];
            this.ValidateTeamExists(teamName);

            Team team = this.teams.First(t => t.Name == teamName);

            Console.WriteLine(team);
        }

        private void RemovePlayer(string[] commandArg)
        {
            string teamName = commandArg[1];
            string playerName = commandArg[2];

            this.ValidateTeamExists(teamName);
            Team team = this.teams.First(t => t.Name == teamName);

            team.RemovePlayer(playerName);
        }

        private void AddPlayerToTeam(string[] commandArg)
        {
            string teamName = commandArg[1];
            string playerName = commandArg[2];
            this.ValidateTeamExists(teamName);
            Team team = this.teams.First(t => t.Name == teamName);

            Stats stats = this.CreateStats(commandArg.Skip(3).ToArray());

            Player player = new Player(playerName, stats);

            team.AddPlayer(player);
        }

        private Stats CreateStats(string[] cmdArg)
        {
            int endurance = int.Parse(cmdArg[0]);
            int sprint = int.Parse(cmdArg[1]);
            int dribble = int.Parse(cmdArg[2]);
            int passing = int.Parse(cmdArg[3]);
            int shooting = int.Parse(cmdArg[4]);

            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);

            return stats;
        }
        private void ValidateTeamExists(string name)
        {
            if (!this.teams.Any(t => t.Name == name))
            {
                throw new ArgumentException(String.Format(GlobalConstants.MissingTeamExceptionMessage, name));
            }
        }

        private void AddTeam(string[] commandArg)
        {
            string teamName = commandArg[1];

            Team team = new Team(teamName);

            this.teams.Add(team);
        }
    }


}
