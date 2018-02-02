using System;
using System.Collections.Generic;

namespace wall_proj.Models
{
    public class Message : BaseEntity
    {
        public int messageid { get;set; }
        public string message { get;set; }

        public int? userid { get;set; }
        public User user { get;set; }
        public List<Comment> comments { get;set; }
        public Message ()
        {
            comments = new List<Comment>();
        }
    }
}