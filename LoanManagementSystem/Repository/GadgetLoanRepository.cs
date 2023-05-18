using LoanManagementSystem.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LoanManagementSystem.Repository.Contract;

namespace LoanManagementSystem.Data.Repositories
{
    public class GadgetLoanRepository : IGadgetLoanRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        private readonly string _apiClientKey;
        private readonly string _jwtToken;

        public GadgetLoanRepository(string apiBaseUrl, string apiClientKey, string jwtToken)
        {
            _httpClient = new HttpClient();
            _apiBaseUrl = apiBaseUrl;
            _apiClientKey = apiClientKey;
            _jwtToken = jwtToken;
        }

        public async Task<GadgetLoan> GetGadgetById(int gadgetId)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _jwtToken);
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/gadgets/{gadgetId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var gadget = JsonConvert.DeserializeObject<GadgetLoan>(content);
                return gadget;
            }
            return null;
        }

        public async Task<List<GadgetLoan>> GetAllGadgets()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _jwtToken);
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/gadgets");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var gadgets = JsonConvert.DeserializeObject<List<GadgetLoan>>(content);
                return gadgets;
            }
            return new List<GadgetLoan>();
        }

        public async Task<GadgetLoan> AddGadget(GadgetLoan newGadget)
        {
            var newGadgetAsString = JsonConvert.SerializeObject(newGadget);
            var requestBody = new StringContent(newGadgetAsString, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("ApiKey", _apiClientKey);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _jwtToken);
            var response = await _httpClient.PostAsync($"{_apiBaseUrl}/gadgets", requestBody);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var createdGadget = JsonConvert.DeserializeObject<GadgetLoan>(content);
                return createdGadget;
            }
            return null;
        }

        public async Task UpdateGadget(int gadgetId, GadgetLoan updatedGadget)
        {
            var updatedGadgetAsString = JsonConvert.SerializeObject(updatedGadget);
            var requestBody = new StringContent(updatedGadgetAsString, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("ApiKey", _apiClientKey);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _jwtToken);
            await _httpClient.PutAsync($"{_apiBaseUrl}/gadgets/{gadgetId}", requestBody);
        }

        public async Task DeleteGadget(int gadgetId)
        {
            _httpClient.DefaultRequestHeaders.Add("ApiKey", _apiClientKey);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _jwtToken);
            await _httpClient.DeleteAsync($"{_apiBaseUrl}/gadgets/{gadgetId}");
        }
    }
}
