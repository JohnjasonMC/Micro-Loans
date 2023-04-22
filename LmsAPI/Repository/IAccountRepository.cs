using LmsAPI.DTO;
using LmsAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace LmsAPI.Repository
{
    public interface IAccountRepository
    {
        Task<SignInResult> SignInUserAsync(LoginDTO loginDTO);
        Task<ApplicationUser> FindUserByEmailAsync(string email);
    }
}
