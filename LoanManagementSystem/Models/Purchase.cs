using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagementSystem.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int GadgetLoanId { get; set; }
        public int PaymentTermId { get; set; }
        public decimal Payment { get; set; }
        public decimal Interest { get; set; }
        public DateTime DatePurchased { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual GadgetLoan GadgetLoan { get; set; }
        public virtual IMP PaymentTerm { get; set; }
    }
}
