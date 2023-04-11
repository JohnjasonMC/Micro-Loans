using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Models
{
    public class PLRepayment
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }

        public int? PrincipalAmount { get; set; }
        public double? AnualRate { get; set; }
        public int? NumberOfTerms { get; set; }
        public double? Rate { get; set; }

        public string ApplicationUserId { get; set; } 
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
