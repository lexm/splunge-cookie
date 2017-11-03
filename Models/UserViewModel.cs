using System;
using System.ComponentModel.DataAnnotations;

namespace splungecookie.Models
{
    public class UserViewModel : BaseEntity
    {
        [Display(Name = "Name")]
        [Required]
        public string name { get; set; }
        [Display(Name = "Alias")]
        [Required]
        public string alias { get; set; }
        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(password))]
        public string confirm { get; set; }
    }
}