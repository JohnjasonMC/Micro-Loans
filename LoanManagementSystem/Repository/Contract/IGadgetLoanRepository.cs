using LoanManagementSystem.Models;

namespace LoanManagementSystem.Repository.Contract
{
    public interface IGadgetLoanRepository
    {
        List<GadgetLoan> GetAllGadgets();
        GadgetLoan GetGadgetById(int Id);
        GadgetLoan AddGadget(GadgetLoan newGadget);
        GadgetLoan UpdateGadget(int gadgetId, GadgetLoan newGadget);
        GadgetLoan DeleteGadget(int gadgetId);
    }
}
