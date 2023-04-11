namespace LoanManagementSystem.ViewModel
{
    public class PurchaseViewModel
    {
        public int GadgetLoanId { get; set; }
        public string GadgetName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Interest { get; set; }
        public int PaymentTerm { get; set; }
        public decimal Payment { get; set; }
        public List<int> AvailablePaymentTerms { get; internal set; }
    }
}
