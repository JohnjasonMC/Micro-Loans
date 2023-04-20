using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Models
{
    public class PersonalLoanCalculator
    {
        [Range(50000, 500000, ErrorMessage = "Principal Amount must be between 50000 and 500000")]
        public int? PrincipalAmount { get; set; }

        public double? AnualRate { get; set; }

        [RegularExpression("^(12|24|36)$", ErrorMessage = "Loan Term must be 12, 24, or 36 months")]
        public int? NumberOfTerms { get; set; }
        public double? Rate { get; set; }
        [ValidateNever]
        public double? Payment { get; set; }
        public PersonalLoanCalculator()
        {
        }
    }
}
