using System;

namespace wall_proj.Models
{
    public abstract class BaseEntity {}
    public class User : BaseEntity
    {
        public int id { get;set; }
        public string first { get; set; }
        public string last { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime created { get;set; }
        public DateTime updated { get;set; }
    }
}   