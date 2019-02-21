using GameTracker.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameTracker.Api.Services.IServices
{
    public interface INhlService
    {
        Task<List<NHLTeamContract>> GetNhlTeamsAsync();
        Task<List<NHLGameContract>> GetNhlGamesAsync();
        Task SaveNewNhlGameAsync(NHLGameContract nhlGameContract);
    }
}
