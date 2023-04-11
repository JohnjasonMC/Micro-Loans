namespace LoanManagementSystem.Models
{
    public class UGadgetLoan
    {
        public int Id { get; set; }
        public bool? Status { get; set; }
        public double? AnnualRate { get; set; }
        public double Payment { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int GadgetLoanId { get; set; }
        public virtual GadgetLoan GadgetLoan { get; set;}
        public int IMPId { get; set; }
        public virtual IMP IMP { get; set; }
        public virtual GLRepayment GLRepayment { get; set; }
    }
}
