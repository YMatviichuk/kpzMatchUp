using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Contracts
{
    public interface IPlayerScoresService
    {
        List<PlayerScore> GetPlayerScores();
        PlayerScore GetPlayerScore(int id);
        bool UpdatePlayerScore(int id, PlayerScore playerScore);
        void InsertPlayerScore(PlayerScore playerScore);
        bool DeletePlayerScore(int id);
        bool PlayerScoreExists(int id);
    }
}
