﻿using System.ComponentModel;
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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }

        [DisplayName("Address")]
        [Required]
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
