using System;
using System.Collections.Generic;

namespace wall_proj.Models
{
    public abstract class BaseEntity {}
    public class User : BaseEntity
    {
        public int userid { get;set; }
        public string first { get; set; }
        public string last { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public List<Message> messages { get;set; }
        public List<Comment> comments { get;set; }
        public User ()
        {
            messages = new List<Message>();
            comments = new List<Comment>();
        }
        
    }
}   