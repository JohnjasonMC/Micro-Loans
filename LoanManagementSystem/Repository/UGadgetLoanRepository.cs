/*
using System.Linq;
using System.Threading.Tasks;
using LoanManagementSystem.Data;
using LoanManagementSystem.Models;
using LoanManagementSystem.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Repositories
{
    public class UGadgetLoanRepository : IUGadgetLoanRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UGadgetLoanRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UGadgetLoan> CalculatePayment(int gadgetLoanId, int impId)
        {
            var gadgetLoan = await _dbContext.gadgetloans.FindAsync(gadgetLoanId);
            var imp = await _dbContext.imps.FindAsync(impId);

            double interestRate = imp.Interest / 100.0;
            double totalPayment = gadgetLoan.Price * (1 + interestRate);
            double monthlyPayment = totalPayment / imp.PaymentTerm;

            return new UGadgetLoan
            {
                GadgetLoanId = gadgetLoan.Id,
                GadgetLoan = gadgetLoan,
                IMPId = imp.Id,
                IMP = imp,
                Payment = monthlyPayment
            };
        }
        public async Task<GadgetLoan> GetGadgetLoanById(int id)
        {
            return await _dbContext.gadgetloans.FindAsync(id);
        }
        public async Task<List<IMP>> GetImpList()
        {
            return await _dbContext.imps.ToListAsync();
        }
    }
}
*/