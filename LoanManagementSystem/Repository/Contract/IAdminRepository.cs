using LoanManagementSystem.Models;

namespace LoanManagementSystem.Repository.Contract
{
    public interface IAdminRepository
    {
        Task<List<ApplicationUser>> GetAllUsers();
        Task<ApplicationUser> GetUserById(Guid userId);
        Task<bool> DeleteUserAccount(Guid userId);
        Task<List<ApplicationUser>> GetAllUsersExcept(Guid excludedUserId);

    }
}
