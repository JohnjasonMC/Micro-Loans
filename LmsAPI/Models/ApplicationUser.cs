using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LmsAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Enter Name")]
        [MinLength(2, ErrorMessage = "Enter Valid Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Enter Birthdate")]
        [DisplayName("Birthdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Enter Gender")]
        public char Gender { get; set; }
    }
}
