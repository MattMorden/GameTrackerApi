using GameTracker.Api.Services.IServices;
using GameTracker.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GameTracker.Api.Controllers
{
    public class NHLController : ApiController
    {
        private readonly INhlService _nhlService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nhlService"></param>
        public NHLController(INhlService nhlService)
        {
            _nhlService = nhlService;
        }

        /// <summary>
        /// Gets a list of NHL teams
        /// </summary>
        /// <returns></returns>
        [Route("api/NHL/GetNhlTeams")]
        [HttpGet]
        public async Task<IHttpActionResult> GetNhlTeams()
        {
            var teams = await _nhlService.GetNhlTeamsAsync();

            if (teams == null)
                return NotFound();

            return Ok(teams);
        }

        /// <summary>
        /// Gets a list of All NHL games
        /// </summary>
        /// <returns></returns>
        [Route("api/NHL/GetNhlGames")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllNhlGames()
        {
            var games = await _nhlService.GetNhlGamesAsync();

            if (games == null)
                return NotFound();

            return Ok(games);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nhlGameContract"></param>
        /// <returns></returns>
        [Route("api/NHL/SaveNewNhlGame")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveNewNhlGame([FromBody] NHLGameContract nhlGameContract)
        {
            if (nhlGameContract == null)
                return BadRequest();

            if (string.IsNullOrEmpty(nhlGameContract.AwayPlayer1) || string.IsNullOrEmpty(nhlGameContract.HomePlayer1) ||
               string.IsNullOrEmpty(nhlGameContract.HomeTeam) || string.IsNullOrEmpty(nhlGameContract.AwayTeam))
            {
                return BadRequest("Invalid Parameter supplied.");
            }

            await _nhlService.SaveNewNhlGameAsync(nhlGameContract);

            return Ok();
        }


    }
}
