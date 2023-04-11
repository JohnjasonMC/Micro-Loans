using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Models
{
    public class GLRepayment
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Date { get; set; }
        public double Payment { get; set; }
        public int UGadgetLoanId { get; set; }
        public virtual UGadgetLoan UGadgetLoan { get; set; }  

    }
}
