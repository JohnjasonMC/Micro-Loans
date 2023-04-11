using LmsAPI.Models;

namespace LmsAPI.Repository
{
    public interface IGadgetLoanRepository
    {
        List<GadgetLoan> GetAllGadgets();
        Task<GadgetLoan> GetGadgetById(int Id);
        GadgetLoan AddGadget(GadgetLoan newGadget);
        GadgetLoan UpdateGadget(int gadgetId, GadgetLoan newGadget);
        Task DeleteGadget(int gadgetId);
    }
}
