using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splungecookie.Models
{
    public class Idea : BaseEntity
    {
        public int ideaid { get; set; }
        public string text { get; set; }
        public int userid { get; set; }
        public User user { get; set; }
        public List<Like> likes { get; set; }
    }
}