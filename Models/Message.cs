using System;

namespace wall_proj.Models
{
    public class Message : BaseEntity
    {
        public int id { get;set; }
        public string message { get;set; }
        public int? users_id { get;set; }
        public DateTime created { get;set; }
        public DateTime updated { get;set; }

    }
}