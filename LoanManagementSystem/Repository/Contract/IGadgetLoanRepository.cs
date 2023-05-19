using LoanManagementSystem.Models;

namespace LoanManagementSystem.Repository.Contract
{
    public interface IGadgetLoanRepository
    {
        Task<GadgetLoan> GetGadgetById(int gadgetId);
        Task<List<GadgetLoan>> GetAllGadgets();
        Task<GadgetLoan> AddGadget(GadgetLoan newGadget);
        Task <GadgetLoan?> UpdateGadget(int gadgetId, GadgetLoan updatedGadget);
        //Task<GadgetLoan?> DeleteGadget(int gadgetId);
    }
}
