using LoanManagementSystem.Models;
using LoanManagementSystem.Repository.Contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminRepository(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            List<ApplicationUser> users = await this._userManager.Users.ToListAsync();

            return users;
        }

        public async Task<List<ApplicationUser>> GetAllUsersExcept(Guid excludedUserId)
        {
            return await this._userManager.Users
                .Where(u => u.Id != excludedUserId.ToString())
                .ToListAsync();
        }

        public async Task<ApplicationUser> GetUserById(Guid userId)
        {
            ApplicationUser user = await this._userManager.Users.FirstOrDefaultAsync(u => u.Id == userId.ToString());

            return user;
        }

        public async Task<bool> DeleteUserAccount(Guid userId)
        {
            ApplicationUser user = await this._userManager.Users.FirstOrDefaultAsync(u => u.Id == userId.ToString());

            var result = await this._userManager.DeleteAsync(user);

            return result.Succeeded;
        }
    }
}
