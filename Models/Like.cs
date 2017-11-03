using System;
using System.ComponentModel.DataAnnotations;

namespace splungecookie.Models
{
    public class Like : BaseEntity
    {
        public int likeid { get; set; }
        public int ideaid { get; set; }
        public Idea idea { get; set; }
        public int userid { get; set; }
        public User user { get; set; }
    }
}