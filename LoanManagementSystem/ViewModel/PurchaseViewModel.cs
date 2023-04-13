using LoanManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoanManagementSystem.ViewModel
{
    public class PurchaseViewModel
    {
        public int GadgetLoanId { get; set; }
        public string GadgetName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Interest { get; set; }
        public string GadgetImageURL { get; set; }
        public int PaymentTerm { get; set; }
        public decimal? Payment { get; set; }
        //public bool IsDefault { get; set; }
        //public List<SelectListItem> AvailableIMPs { get; set; }
        public int SelectedIMPId { get; set; }
        public List<IMP> AvailablePaymentTerms { get; set; }
    }
}
