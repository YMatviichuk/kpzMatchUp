using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Contracts;
using API.DbContext;
using API.Models;

namespace API.Controllers
{
    public class PlayerScoresController : ApiController
    {
        private readonly IPlayerScoresService _playerScoreService;

        public PlayerScoresController(IPlayerScoresService playerScoreService)
        {
            _playerScoreService = playerScoreService;
        }

        // GET: api/PlayerScores
        public IQueryable<PlayerScore> GetPlayerScores()
        {
            return _playerScoreService.GetPlayerScores();
        }

        // GET: api/PlayerScores/5
        [ResponseType(typeof(PlayerScore))]
        public IHttpActionResult GetPlayerScore(int id)
        {
            PlayerScore playerScore = _playerScoreService.GetPlayerScore(id);
            if (playerScore == null)
            {
                return NotFound();
            }

            return Ok(playerScore);
        }

        // PUT: api/PlayerScores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayerScore(int id, PlayerScore playerScore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playerScore.Id)
            {
                return BadRequest();
            }

            if (!PlayerScoreExists(id))
            {
                return NotFound();
            }

            _playerScoreService.UpdatePlayerScore(id, playerScore);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PlayerScores
        [ResponseType(typeof(PlayerScore))]
        public IHttpActionResult PostPlayerScore(PlayerScore playerScore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _playerScoreService.InsertPlayerScore(playerScore);

            return CreatedAtRoute("DefaultApi", new { id = playerScore.Id }, playerScore);
        }

        // DELETE: api/PlayerScores/5
        [ResponseType(typeof(PlayerScore))]
        public IHttpActionResult DeletePlayerScore(int id)
        {
            if (_playerScoreService.DeletePlayerScore(id))
            {
                return Ok();
            }
            return NotFound();
        }
        

        private bool PlayerScoreExists(int id)
        {
            return _playerScoreService.PlayerScoreExists(id);
        }
    }
}