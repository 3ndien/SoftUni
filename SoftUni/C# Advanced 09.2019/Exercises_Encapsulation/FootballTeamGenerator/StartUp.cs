using FootballTeamGenerator.Stats;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input;
            var teams = new List<Team>();

            while ((input = Console.ReadLine()) != "END")
            {
                var data = input.Split(';');
                var cmd = data[0];

                Team team = null;

                try
                {
                    switch (cmd)
                    {
                        case "Team":
                            team = CreateTeam(teams, data);
                            break;
                        case "Add":
                            CreateAndAddPlayer(teams, data);
                            break;
                        case "Remove":
                            RemovePlayerFromTeam(teams, data);
                            break;
                        case "Rating":
                            PrintTeamRating(teams, data);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void PrintTeamRating(List<Team> teams, string[] data)
        {
            var teamToBePrinted = teams.FirstOrDefault(t => t.Name == data[1]);
            if (teamToBePrinted == null)
            {
                throw new ArgumentException($"Team {data[1]} does not exist.");
            }
            Console.WriteLine($"{teamToBePrinted.Name} - {teamToBePrinted.Rating}");
        }

        private static void RemovePlayerFromTeam(List<Team> teams, string[] data)
        {
            var playerToRemove = teams.FirstOrDefault(t => t.Name == data[1]).Players.FirstOrDefault(p => p.Name == data[2]);
            if (playerToRemove == null)
            {
                throw new ArgumentException($"Player {data[2]} is not in {data[1]} team.");
            }
            teams.First(t => t.Name == data[1]).RemovePlayer(playerToRemove);
        }

        private static void CreateAndAddPlayer(List<Team> teams, string[] data)
        {
            var player = new Player(data[2]);
            var currTeam = teams.FirstOrDefault(t => t.Name == data[1]);
            if (currTeam == null)
            {
                throw new ArgumentException($"Team {data[1]} does not exist.");
            }
            IStat endurance = new Endurance(int.Parse(data[3]));
            IStat sprint = new Sprint(int.Parse(data[4]));
            IStat dribble = new Dribble(int.Parse(data[5]));
            IStat passing = new Passing(int.Parse(data[6]));
            IStat shooting = new Shooting(int.Parse(data[7]));
            player.AddStats(endurance, sprint, dribble, passing, shooting);
            currTeam.AddPlayer(player);
        }

        private static Team CreateTeam(List<Team> teams, string[] data)
        {
            Team team = new Team(data[1]);
            if (teams.Any(t => t.Name == team.Name))
            {
                throw new ArgumentException($"Team {data[1]} does not exist.");
            }
            teams.Add(team);
            return team;
        }
    }
}
