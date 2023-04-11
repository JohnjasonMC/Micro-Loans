using LoanManagementSystem.Models;
using LoanManagementSystem.Repository.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<IActionResult> Profile()
        {
            ApplicationUser currentUser = await this._userRepository.GetCurrentUser();

            return View(currentUser);
        }
    }
}
