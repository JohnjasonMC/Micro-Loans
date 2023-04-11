using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LoanManagementSystem.ViewModel
{
    public class UpdatePasswordViewModel
    {
        [DisplayName("Current Password")]
        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DisplayName("New Password")]
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DisplayName("Confirm Password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}
