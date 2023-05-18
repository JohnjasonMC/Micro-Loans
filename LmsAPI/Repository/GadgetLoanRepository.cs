using LmsAPI.Data;
using LmsAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace LmsAPI.Repository
{
    public class GadgetLoanRepository : IGadgetLoanRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GadgetLoanRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GadgetLoan> GetGadgetById(int gadgetId)
        {
            return await _dbContext.gadgetloans.FromSqlRaw("EXEC dbo.GetGadgetById @GadgetId", new SqlParameter("GadgetId", gadgetId)).FirstOrDefaultAsync();
        }

        public async Task<List<GadgetLoan>> GetAllGadgets()
        {
            return await _dbContext.gadgetloans.FromSqlRaw("EXEC dbo.GetAllGadgets").ToListAsync();
        }

        public GadgetLoan AddGadget(GadgetLoan newGadget)
        {
            var gadgetIdParameter = new SqlParameter("GadgetLoanId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            _dbContext.Database.ExecuteSqlRaw("EXEC dbo.AddGadget @GadgetName, @Description, @Price, @GadgetImageURL, @GadgetLoanId OUT",
                new SqlParameter("GadgetName", newGadget.GadgetName),
                new SqlParameter("Description", newGadget.Description),
                new SqlParameter("Price", newGadget.Price),
                new SqlParameter("GadgetImageURL", newGadget.GadgetImageURL),
                gadgetIdParameter);

            newGadget.Id = (int)gadgetIdParameter.Value;
            return newGadget;
        }

        public void UpdateGadget(int gadgetId, GadgetLoan updatedGadget)
        {
            _dbContext.Database.ExecuteSqlRaw("EXEC dbo.UpdateGadget @GadgetId, @GadgetName, @Description, @Price, @GadgetImageURL",
                new SqlParameter("GadgetId", gadgetId),
                new SqlParameter("GadgetName", updatedGadget.GadgetName),
                new SqlParameter("Description", updatedGadget.Description),
                new SqlParameter("Price", updatedGadget.Price),
                new SqlParameter("GadgetImageURL", updatedGadget.GadgetImageURL));
        }

        public void DeleteGadget(int gadgetId)
        {
            _dbContext.Database.ExecuteSqlRaw("EXEC dbo.DeleteGadget @GadgetId",
                new SqlParameter("GadgetId", gadgetId));
        }
    }
}
