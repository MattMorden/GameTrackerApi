using GameTracker.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameTracker.Api.Data.IRepositories
{
    public interface INhlRepository
    {
        Task<List<NHLTeamContract>> GetNhlTeamsAsync();
        Task<List<NHLGameContract>> GetNhlGamesAsync();
        Task<int> SaveNewNhlGameAsync(NHLGameContract nhlGameContract);
    }
}
