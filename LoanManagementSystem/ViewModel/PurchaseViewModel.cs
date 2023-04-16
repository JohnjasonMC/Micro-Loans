using LoanManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoanManagementSystem.ViewModel
{
    public class PurchaseViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public int GadgetLoanId { get; set; }
        public string GadgetName { get; set; }
        public string Description { get; set; }
        public string GadgetImageURL { get; set; }
        public decimal Price { get; set; }
        public decimal Payment { get; set; }
        public double Interest { get; set; }
        public int PaymentTerm { get; set; }
        public List<IMP> AvailablePaymentTerms { get; set; }
        public DateTime DatePurchased { get; set; }

    }
}
