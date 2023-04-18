using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagementSystem.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int GadgetLoanId { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string GadgetName { get; set; }
        public decimal Payment { get; set; }
        public double Interest { get; set; }
        public DateTime DatePurchased { get; set; }
        public string GadgetImageURL { get; set; }
        public int PaymentTerm { get; set; }
        public bool IsArchived { get; set; }
        public string Status { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual GadgetLoan GadgetLoan { get; set; }
        //public virtual IMP PaymentTerm { get; set; }
    }
}
