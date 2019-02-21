using GameTracker.Api.Data.IRepositories;
using GameTracker.Api.Services.IServices;
using GameTracker.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Api.Services.Services
{
    public class NhlService : INhlService
    {
        private readonly INhlRepository _nhlRepository;

        public NhlService(INhlRepository nhlRepository)
        {
            _nhlRepository = nhlRepository;
        }

        public async Task<List<NHLTeamContract>> GetNhlTeamsAsync()
        {
            return await _nhlRepository.GetNhlTeamsAsync();
        }

        public async Task<List<NHLGameContract>> GetNhlGamesAsync()
        {
            return await _nhlRepository.GetNhlGamesAsync();
        }

        public async Task SaveNewNhlGameAsync(NHLGameContract gameContract)
        {
            await _nhlRepository.SaveNewNhlGameAsync(gameContract);
        }
    }
}
