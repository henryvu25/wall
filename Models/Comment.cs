using System;

namespace wall_proj.Models
{
    public class Comment : BaseEntity
    {
        public int commentid { get;set; }
        public string comment { get;set; }

        public int? userid { get;set; }
        public User user { get;set; }
        public int messageid { get;set; }
        public Message message { get;set; }

    }
}