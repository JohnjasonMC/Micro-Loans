using LmsAPI.DTO;
using LmsAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace LmsAPI.Repository
{
    public interface IAccountRepository
    {
        Task<ApplicationUser> SignUpUserAsync(ApplicationUser user, string password);
        Task<SignInResult> SignInUserAsync(LoginDTO loginDTO);
        Task<ApplicationUser> FindUserByEmailAsync(string email);
    }
}
