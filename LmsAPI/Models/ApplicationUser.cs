using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LmsAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
