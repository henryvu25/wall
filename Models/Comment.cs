using System;

namespace wall_proj.Models
{
    public class Comment : BaseEntity
    {
        public int id { get;set; }
        public string comment { get;set; }
        public int users_id { get;set; }
        public int messages_id { get;set; }
        public DateTime created { get;set; }
        public DateTime updated { get;set; }

    }
}