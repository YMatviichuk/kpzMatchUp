using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class PlayerScore
    {
        public int Id { get; set; }
        public virtual Player Player { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}