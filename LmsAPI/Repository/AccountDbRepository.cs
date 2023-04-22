using LmsAPI.DTO;
using LmsAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace LmsAPI.Repository
{
    public class AccountDbRepository : IAccountRepository
    {
        public UserManager<ApplicationUser> _userManager { get; }
        public SignInManager<ApplicationUser> _signInManager { get; }

        public AccountDbRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> SignInUserAsync(LoginDTO loginDTO)
        {
            var loginResult = await _signInManager.PasswordSignInAsync(loginDTO.UserName, loginDTO.Password, loginDTO.RememberMe, false);
            return loginResult;
        }


        public async Task<ApplicationUser> FindUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

    }
}
