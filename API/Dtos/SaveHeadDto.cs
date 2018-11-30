using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Dtos
{
    public class SaveHeadDto
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SaveName { get; set; }
    }

    public class PlayerSaveCreateModel
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string Save { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SaveName { get; set; }
    }
}