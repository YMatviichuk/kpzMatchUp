using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class PlayerSave
    {
        public int Id { get; set; }
        public virtual Player Player { get; set; }
        public string Save { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SaveName { get; set; }
    }
}