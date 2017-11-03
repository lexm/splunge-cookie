using System;
using System.ComponentModel.DataAnnotations;

namespace splungecookie.Models
{
    public class IdeaViewModel : BaseEntity
    {
        [MinLength(5)]
        public string text { get; set; }
    }
}