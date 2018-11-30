using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using API.Contracts;
using API.DbContext;
using API.Models;

namespace API.Services
{
    public class PlayerScoresServiceLINQtoSQL : IPlayerScoresService
    {
        private static readonly string ConnectionString = "Data Source=.;Initial Catalog=matchUpDb;Integrated Security=True;";
        
        private DataContext db = new DataContext(ConnectionString);
        
        public List<PlayerScore> GetPlayerScores()
        {
            return db.GetTable<PlayerScore>().ToList();
        }

        public PlayerScore GetPlayerScore(int id)
        {
            return db.GetTable<PlayerScore>().AsQueryable().FirstOrDefault(x => x.Id == id);
        }

        public bool UpdatePlayerScore(int id, PlayerScore playerScore)
        {
            var record = db.GetTable<PlayerScore>().SingleOrDefault(x => x.Id == id);
            if (record != null)
            {
                record.Date = playerScore.Date;
                record.Score = playerScore.Score;
                db.SubmitChanges();
            }

            return record == null;
        }

        public void InsertPlayerScore(PlayerScore playerScore)
        {
            db.GetTable<PlayerScore>().InsertOnSubmit(playerScore);
            db.SubmitChanges();
        }

        public bool DeletePlayerScore(int id)
        {
            var entity = db.GetTable<PlayerScore>().AsQueryable().FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                db.GetTable<PlayerScore>().DeleteOnSubmit(entity);
                db.SubmitChanges();
            }

            return entity != null;
        }

        public bool PlayerScoreExists(int id)
        {
            return db.GetTable<PlayerScore>().AsQueryable().Any(x => x.Id == id);
        }
    }
}