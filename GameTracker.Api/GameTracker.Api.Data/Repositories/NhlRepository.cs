using GameTracker.Api.Data.IRepositories;
using GameTracker.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Api.Data.Repositories
{
    public class NhlRepository : INhlRepository
    {
        public NhlRepository() { }

        public async Task<List<NHLTeamContract>> GetNhlTeamsAsync()
        {
            return await Task.Factory.StartNew(() => GetNhlTeams());
        }

        private List<NHLTeamContract> GetNhlTeams()
        {
            return new List<NHLTeamContract>
            {
                new NHLTeamContract{ TeamName= "Anaheim Ducks" },
                new NHLTeamContract{ TeamName= "Arizona Coyotes" },
                new NHLTeamContract{ TeamName= "Boston Bruins" },
                new NHLTeamContract{ TeamName= "Buffalo Sabres" },
                new NHLTeamContract{ TeamName= "Calgary Flames" },
                new NHLTeamContract{ TeamName= "Carolina Hurricanes" },
                new NHLTeamContract{ TeamName= "Chicago Blackhawks" },
                new NHLTeamContract{ TeamName= "Colorado Avalanche" },
                new NHLTeamContract{ TeamName= "Columbus Blue Jackets" },
                new NHLTeamContract{ TeamName= "Dallas Stars" },
                new NHLTeamContract{ TeamName= "Detroit Red Wings" },
                new NHLTeamContract{ TeamName= "Edmonton Oilers" },
                new NHLTeamContract{ TeamName= "Florida Panthers" },
                new NHLTeamContract{ TeamName= "Los Angeles Kings" },
                new NHLTeamContract{ TeamName= "Minnesota Wild" },
                new NHLTeamContract{ TeamName= "Montreal Canadiens" },
                new NHLTeamContract{ TeamName= "Nashville Predators" },
                new NHLTeamContract{ TeamName= "New Jersey Devils" },
                new NHLTeamContract{ TeamName= "New York Islanders" },
                new NHLTeamContract{ TeamName= "New York Rangers" },
                new NHLTeamContract{ TeamName= "Ottawa Senators" },
                new NHLTeamContract{ TeamName= "Philadelphia Flyers" },
                new NHLTeamContract{ TeamName= "Pittsburgh Penguins" },
                new NHLTeamContract{ TeamName= "San Jose Sharks" },
                new NHLTeamContract{ TeamName= "St Louis Blues" },
                new NHLTeamContract{ TeamName= "Tampa Bay Lightning" },
                new NHLTeamContract{ TeamName= "Toronto Maple Leafs" },
                new NHLTeamContract{ TeamName= "Vancouver Canucks" },
                new NHLTeamContract{ TeamName= "Vegas Golden Knights" },
                new NHLTeamContract{ TeamName= "Washington Capitals" },
                new NHLTeamContract{ TeamName= "Winnipeg Jets" },
            };
        }

        public async Task<List<NHLGameContract>> GetNhlGamesAsync()
        {
            return await Task.Factory.StartNew(() => GetNhlGames());
        }

        //TODO: Remove this and just hit Database for games
        private List<NHLGameContract> GetNhlGames()
        {
            return new List<NHLGameContract>
            {
                new NHLGameContract{ AwayPlayer1="Away1", HomePlayer1="Home1", HomeScore=3, AwayScore=1, AwayTeam="Anaheim Ducks", HomeTeam="Ottawa Senators"},
                new NHLGameContract{ AwayPlayer1="Matt", HomePlayer1="Scott", HomeScore=3, AwayScore=1, AwayTeam="Toronto Maple Leafs", HomeTeam="Winnipeg Jets"},
            };
        }

        /// <summary>
        /// Saves / updates an NHL game
        /// </summary>
        /// <param name="nhlGameContract"></param>
        /// <returns></returns>
        public async Task<int> SaveNewNhlGameAsync(NHLGameContract nhlGameContract)
        {
            //TODO: Use repo

            return 1;
        }
    }
}
