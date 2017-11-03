using System;
using System.ComponentModel.DataAnnotations;

namespace splunge_cookie.Models
{
    public abstract class BaseEntity
    {
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class User : BaseEntity
    {
        public int userid { get; set; }
        public string name { get; set; }
        public string alias { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
