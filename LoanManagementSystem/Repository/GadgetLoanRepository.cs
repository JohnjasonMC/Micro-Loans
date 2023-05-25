using LoanManagementSystem.Data;
using LoanManagementSystem.Models;
using LoanManagementSystem.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Repository
{
    public class GadgetLoanRepository : IGadgetLoanRepository
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configs;
        ApplicationDbContext _dbContext;

        public GadgetLoanRepository(ApplicationDbContext dbContext, IConfiguration configs)
        {
            httpClient = new HttpClient();
            _configs = configs;
            _dbContext = dbContext;
            httpClient.BaseAddress = new Uri("https://localhost:7259/api/");
        }

        public async Task<GadgetLoan?> GetGadgetById(int gadgetId)
        {
            var response = await httpClient.GetAsync($"GadgetLoan/{gadgetId}");
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var gadgetloan = JsonConvert.DeserializeObject<GadgetLoan>(content);
                return gadgetloan;
            }
            return null;
        }

        public async Task<List<GadgetLoan>> GetAllGadgets(string token)
        {
            httpClient.DefaultRequestHeaders.Add("ApiKey", _configs.GetValue<string>("ApiKey"));
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.GetAsync("https://localhost:7259/api/GadgetLoan");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var gadgetloan = JsonConvert.DeserializeObject<List<GadgetLoan>>(content);
                return gadgetloan ?? new List<GadgetLoan>();
            }
            return new List<GadgetLoan>();

        }

        public async Task<GadgetLoan> AddGadget(GadgetLoan newGadget, string token)
        {
            var newGadgetAsString = JsonConvert.SerializeObject(newGadget);
            var requestBody = new StringContent(newGadgetAsString, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Add("ApiKey", "RANDomValuetoDenoteAPIKeyWithNumbers131235");
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await httpClient.PostAsync($"https://localhost:7259/api/GadgetLoan", requestBody);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var createdGadget = JsonConvert.DeserializeObject<GadgetLoan>(content);

                return createdGadget;
            }
            return null;
        }

        public async Task<GadgetLoan?> UpdateGadget(int gadgetId, GadgetLoan updatedGadget, string token)
        {
            httpClient.DefaultRequestHeaders.Add("ApiKey", _configs.GetValue<string>("ApiKey"));
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var newGadgetAsString = JsonConvert.SerializeObject(updatedGadget);
            var requestBody = new StringContent(newGadgetAsString, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"{gadgetId}", requestBody);
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var updatedgadget = JsonConvert.DeserializeObject<GadgetLoan>(content);
                return updatedgadget;
            }
            return null;
        }

        
        public async Task DeleteGadget(int gadgetId, string token)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("ApiKey", _configs.GetValue<string>("ApiKey"));
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer" + token);
            var response = await httpClient.DeleteAsync($"https://localhost:7259/api/GadgetLoan/{gadgetId}");
            if(response.IsSuccessStatusCode )
            {
                var data = await response.Content.ReadAsByteArrayAsync();
                Console.WriteLine("Delete Password Response: ", data);
            }
        }
    }
}
