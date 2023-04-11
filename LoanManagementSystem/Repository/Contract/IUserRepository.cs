using LoanManagementSystem.Models;

namespace LoanManagementSystem.Repository.Contract
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetCurrentUser();
    }
}
