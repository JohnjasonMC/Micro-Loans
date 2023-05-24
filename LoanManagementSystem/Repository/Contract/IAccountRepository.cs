using LoanManagementSystem.ViewModel;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Repository.Contract
{
    public interface IAccountRepository
    {
        Task<bool> SignUpUserAsync(RegisterUserViewModel registerUser);
        Task<string> SignInUserAsync(LoginUserViewModel loginUser);
    }
}
