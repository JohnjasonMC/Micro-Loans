using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LoanManagementSystem.ViewModel
{
    public class LoginUserViewModel
    {
        [DisplayName("Enter Username/Email Address")]
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
