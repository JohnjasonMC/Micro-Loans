using LoanManagementSystem.Models;

namespace LoanManagementSystem.Repository.Contract
{
    public interface IGadgetLoanRepository
    {
        Task<GadgetLoan> GetGadgetById(int gadgetId);
        Task<List<GadgetLoan>> GetAllGadgets(string token);
        Task<GadgetLoan> AddGadget(GadgetLoan newGadget, string token);
        Task <GadgetLoan?> UpdateGadget(int gadgetId, GadgetLoan updatedGadget, string token);
        Task DeleteGadget(int gadgetId, string token);
    }
}
