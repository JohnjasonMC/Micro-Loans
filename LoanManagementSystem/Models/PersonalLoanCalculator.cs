using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LoanManagementSystem.Models
{
    public class PersonalLoanCalculator
    {
        public int? PrincipalAmount { get; set; }
        public double? AnualRate { get; set; }
        public int? NumberOfTerms { get; set; }
        public double? Rate { get; set; }
        [ValidateNever]
        public double? Payment { get; set; }
        public PersonalLoanCalculator()
        {
        }
    }
}
