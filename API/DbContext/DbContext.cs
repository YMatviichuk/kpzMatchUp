using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using API.Models;

namespace API.DbContext
{
    public class MyContext: System.Data.Entity.DbContext
    {
        public MyContext(): base("connectionString")
        {
        }

        public virtual DbSet<Player> Users { get; set; }
        public virtual DbSet<PlayerScore> PlayerScores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<API.Models.PlayerSave> PlayerSaves { get; set; }
    }
}