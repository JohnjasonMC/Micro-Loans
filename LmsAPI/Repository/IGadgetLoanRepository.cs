using LmsAPI.Models;

namespace LmsAPI.Repository
{
    public interface IGadgetLoanRepository
    {
        Task<GadgetLoan> GetGadgetById(int gadgetId);
        Task<List<GadgetLoan>> GetAllGadgets();
        GadgetLoan AddGadget(GadgetLoan newGadget);
        void UpdateGadget(int gadgetId, GadgetLoan updatedGadget);
        void DeleteGadget(int gadgetId);
    }
}
