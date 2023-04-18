using LoanManagementSystem.CustomValidation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace LoanManagementSystem.ViewModel
{
    public class RegisterUserViewModel
    {
        [DisplayName("Full Name")]
        [Required]
        public string FullName { get; set; }

        [DisplayName("Email Address")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [MinAge(18)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Phone Number")]
        [Required]
        [RegularExpression(@"^09[0-9]{9}$", ErrorMessage = "Please enter 11 digit valid phone number that starts with '09'.")]
        public string PhoneNumber { get; set; }

        [DisplayName("Address")]
        [Required]
        [StringLength(50, MinimumLength =5, ErrorMessage = "Please enter valid Address")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password Doesn't Match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public char Gender { get; set; }
    }
}
