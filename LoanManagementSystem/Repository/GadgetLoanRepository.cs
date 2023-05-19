using LoanManagementSystem.Data;
using LoanManagementSystem.Models;
using LoanManagementSystem.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Repository
{
    public class GadgetLoanRepository : IGadgetLoanRepository
    {
        private readonly HttpClient httpClient;
        ApplicationDbContext _dbContext;
        private const string ApiKey = "RANDomValuetoDenoteAPIKeyWithNumbers131235";
        private const string BaseUrl = "http://localhost:7259";
        private const string JwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2ODQ0MDQzMzgsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NzI1OSIsImF1ZCI6IlVzZXIifQ.Lc_ELRgOl1BPZcA3fTQHVelrx9DwfEaQM0UJQPzEtHo";

        public GadgetLoanRepository(ApplicationDbContext dbContext, IHttpClientFactory httpClientFactory)
        {
            httpClient = new HttpClient();
            _dbContext = dbContext;
        }

        public async Task<GadgetLoan> GetGadgetById(int gadgetId)
        {
            var gadget = await _dbContext.gadgetloans.FindAsync(gadgetId);
            return gadget;
        }

        public async Task<List<GadgetLoan>> GetAllGadgets()
        {
            return _dbContext.gadgetloans.AsNoTracking().ToList();
        }

        public async Task<GadgetLoan> AddGadget(GadgetLoan newGadget)
        {
            var newGadgetAsString = JsonConvert.SerializeObject(newGadget);
            var requestBody = new StringContent(newGadgetAsString, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Add("ApiKey", ApiKey);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + JwtToken);
            var response = await httpClient.PostAsync($"{BaseUrl}/gadgetloans", requestBody);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var createdGadget = JsonConvert.DeserializeObject<GadgetLoan>(content);

                return createdGadget;
            }
            return null;
        }

        public async Task<GadgetLoan?> UpdateGadget(int gadgetId, GadgetLoan updatedGadget)
        {
            var updatedGadgetAsString = JsonConvert.SerializeObject(updatedGadget);
            var requestBody = new StringContent(updatedGadgetAsString, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Add("ApiKey", ApiKey);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + JwtToken);
            var response = await httpClient.PutAsync($"{BaseUrl}/gadgetloans/{gadgetId}", requestBody);
            if(response.IsSuccessStatusCode )
            {
                var content = await response.Content.ReadAsStringAsync();
                var gadgetloan = JsonConvert.DeserializeObject<GadgetLoan>(content);
                return gadgetloan;
            }
            return null;
        }

        /*
        public async Task<GadgetLoan?> DeleteGadget(int gadgetId)
        {
            var gadgetloan = GetGadgetById(gadgetId);
            httpClient.DefaultRequestHeaders.Add("ApiKey", ApiKey);
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + JwtToken);

            await httpClient.DeleteAsync($"{BaseUrl}/gadgetloans/{gadgetId}");

            return gadgetloan;
        }*/
    }
}
