using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using API.Contracts;
using API.DbContext;
using API.Models;

namespace API.Services
{
    public class PlayerScoresService: IPlayerScoresService, IDisposable
    {
        private readonly MyContext db = new MyContext();

        public IQueryable<PlayerScore> GetPlayerScores()
        {
            return db.PlayerScores;
        }

        public PlayerScore GetPlayerScore(int id)
        {
            return db.PlayerScores.Find(id);
        }

        public bool UpdatePlayerScore(int id, PlayerScore playerScore)
        {
            db.Entry(playerScore).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerScoreExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public void InsertPlayerScore(PlayerScore playerScore)
        {
            db.PlayerScores.Add(playerScore);
            db.SaveChanges();
        }

        public bool DeletePlayerScore(int id)
        {
            PlayerScore playerScore = db.PlayerScores.Find(id);
            if (playerScore == null)
            {
                return false;
            }

            db.PlayerScores.Remove(playerScore);
            db.SaveChanges();

            return true;
        }

        public bool PlayerScoreExists(int id)
        {
            return db.PlayerScores.Count(e => e.Id == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}