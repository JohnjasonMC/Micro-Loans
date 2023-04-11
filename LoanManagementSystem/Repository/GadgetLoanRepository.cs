using LoanManagementSystem.Data;
using LoanManagementSystem.Models;
using LoanManagementSystem.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Repository
{
    public class GadgetLoanRepository : IGadgetLoanRepository
    {
        ApplicationDbContext _dbcontext;

        public GadgetLoanRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public GadgetLoan DeleteGadget(int gadgetId)
        {
            var gadget = GetGadgetById(gadgetId);
            if (gadget != null)
            {
                _dbcontext.gadgetloans.Remove(gadget);
                _dbcontext.SaveChanges();
            }
            return null;
        }

        public GadgetLoan AddGadget(GadgetLoan newGadget)
        {
            _dbcontext.Add(newGadget);
            _dbcontext.SaveChanges();
            return newGadget;
        }

        public GadgetLoan GetGadgetById(int Id)
        {
            return _dbcontext.gadgetloans.AsNoTracking().ToList().FirstOrDefault(t => t.Id == Id);
        }

        public List<GadgetLoan> GetAllGadgets()
        {
            return _dbcontext.gadgetloans.AsNoTracking().ToList();
        }

        public GadgetLoan UpdateGadget(int gadgetId, GadgetLoan newGadget)
        {

            _dbcontext.gadgetloans.Update(newGadget);
            _dbcontext.SaveChanges();
            return newGadget;
        }
    }
}
