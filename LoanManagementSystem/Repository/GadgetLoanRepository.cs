using LoanManagementSystem.Data;
using LoanManagementSystem.Models;
using LoanManagementSystem.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Repository
{
    public class GadgetLoanRepository : IGadgetLoanRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpClientFactory _httpClientFactory;

        private const string ApiKey = "RANDomValuetoDenoteAPIKeyWithNumbers131235";
        private const string BaseUrl = "http://localhost:7259";
        private const string JwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2ODQ0MDQzMzgsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NzI1OSIsImF1ZCI6IlVzZXIifQ.Lc_ELRgOl1BPZcA3fTQHVelrx9DwfEaQM0UJQPzEtHo";

        public GadgetLoanRepository(ApplicationDbContext dbContext, IHttpClientFactory httpClientFactory)
        {
            _dbContext = dbContext;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<GadgetLoan> GetGadgetById(int gadgetId)
        {
            var gadget = await _dbContext.gadgetloans.FindAsync(gadgetId);
            return gadget;
        }

        public async Task<List<GadgetLoan>> GetAllGadgets()
        {
            var gadgets = await _dbContext.gadgetloans.ToListAsync();
            return gadgets;
        }

        public async Task<GadgetLoan> AddGadget(GadgetLoan newGadget)
        {
            _dbContext.gadgetloans.Add(newGadget);
            await _dbContext.SaveChangesAsync();

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("ApiKey", ApiKey);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + JwtToken);

            var newGadgetAsString = Newtonsoft.Json.JsonConvert.SerializeObject(newGadget);
            var requestBody = new StringContent(newGadgetAsString, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"{BaseUrl}/gadgetloans", requestBody);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var createdGadget = Newtonsoft.Json.JsonConvert.DeserializeObject<GadgetLoan>(content);

            return createdGadget;
        }

        public async Task UpdateGadget(int gadgetId, GadgetLoan updatedGadget)
        {
            _dbContext.Entry(updatedGadget).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("ApiKey", ApiKey);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + JwtToken);

            var updatedGadgetAsString = Newtonsoft.Json.JsonConvert.SerializeObject(updatedGadget);
            var requestBody = new StringContent(updatedGadgetAsString, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync($"{BaseUrl}/gadgetloans/{gadgetId}", requestBody);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteGadget(int gadgetId)
        {
            var gadget = await _dbContext.gadgetloans.FindAsync(gadgetId);
            if (gadget != null)
            {
                _dbContext.gadgetloans.Remove(gadget);
                await _dbContext.SaveChangesAsync();

                var httpClient = _httpClientFactory.CreateClient();
                httpClient.DefaultRequestHeaders.Add("ApiKey", ApiKey);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + JwtToken);

                var response = await httpClient.DeleteAsync($"{BaseUrl}/gadgetloans/{gadgetId}");
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
