using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LoanManagementSystem.ViewModel
{
    public class UpdatePasswordViewModel
    {
        [DisplayName("Current Password")]
        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DisplayName("New Password")]
        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage ="Required Field")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "New Password and Confirm Password Doesn't Match")]
        public string ConfirmPassword { get; set; }
    }
}
