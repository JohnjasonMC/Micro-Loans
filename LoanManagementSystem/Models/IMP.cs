namespace LoanManagementSystem.Models
{
    public class IMP
    {
        public int Id { get; set; }
        public double Interest { get; set; }
        public int PaymentTerm { get; set; }
        public virtual UGadgetLoan UGadgetLoan { get; set; }
        public IMP() { }
        public IMP(int id, double interest, int paymentterm)
        {
            Id = id;
            Interest = interest;
            PaymentTerm = paymentterm;
        }
    }
}
