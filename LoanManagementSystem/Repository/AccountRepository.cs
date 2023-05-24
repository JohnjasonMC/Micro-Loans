using LoanManagementSystem.ViewModel;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using LoanManagementSystem.Repository.Contract;

namespace LoanManagementSystem.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configs;

        public AccountRepository(IConfiguration configs)
        {
            _httpClient = new HttpClient();
            _configs = configs;
            _httpClient.BaseAddress = new Uri("http://localhost:7259/api/");
        }
        public async Task<bool> SignUpUserAsync(RegisterUserViewModel registerUser)
        {
            var newPasswordmngrAsString = JsonConvert.SerializeObject(registerUser);
            var requestBody = new StringContent(newPasswordmngrAsString, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("ApiKey", _configs.GetValue<string>("ApiKey"));
            var response = await _httpClient.PostAsync("/signup", requestBody);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return true;
            }

            return false;
        }

        public async Task<string> SignInUserAsync(LoginUserViewModel loginUser)
        {
            // rest api call
            var newTodoAsString = JsonConvert.SerializeObject(loginUser);
            var requestBody = new StringContent(newTodoAsString, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("ApiKey", _configs.GetValue<string>("ApiKey"));
            var response = await _httpClient.PostAsync("Account/login", requestBody);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                // extract token from responce and store it in session
                var token = JObject.Parse(content)["token"].ToString();

                return token;
            }

            return null;
        }
    }
}
