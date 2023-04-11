using LmsAPI.Data;
using LmsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace LmsAPI.Repository
{
    public class GadgetLoanRepository : IGadgetLoanRepository
    {

        ApplicationDbContext _dbcontext;

        public GadgetLoanRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public Task DeleteGadget(int gadgetId)
        {
            var gadget = this._dbcontext.gadgetloans.FindAsync(gadgetId);
            if (gadget.Result != null)
            {
                this._dbcontext.gadgetloans.Remove(gadget.Result);
            }
            return this._dbcontext.SaveChangesAsync();
        }

        public GadgetLoan AddGadget(GadgetLoan newGadget)
        {
            _dbcontext.Add(newGadget);
            _dbcontext.SaveChanges();
            return newGadget;
        }

        public Task<GadgetLoan> GetGadgetById(int Id) //KAYA NAG TASK ASYNC KASI NAG HAHANDLE NG MADAMING TRAFFIC NG DATA DI APPLICABLE YUNG GINGAWA SA SYSTEM NATIN NA WALANG ASYNC METHOD
        {
           //return _dbcontext.gadgetloans.AsNoTracking().ToList().FirstOrDefault(t => t.Id == Id);
           var gadget = this._dbcontext.gadgetloans.FirstOrDefaultAsync(x => x.Id == Id);
            if (gadget == null)
                return null;
            return gadget;
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
