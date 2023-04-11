using LoanManagementSystem.Models;
using LoanManagementSystem.Repository.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LoanManagementSystem.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IAdminRepository _adminRepository;

        public AdministratorController(IUserRepository userRepository, IAdminRepository adminRepository)
        {
            this._userRepository = userRepository;
            this._adminRepository = adminRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            ApplicationUser user = await this._userRepository.GetCurrentUser();
            List<ApplicationUser> users = await _adminRepository.GetAllUsersExcept(Guid.Parse(user.Id));

            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid userId)
        {
            ApplicationUser user = await this._adminRepository.GetUserById(userId);
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            bool result = await this._adminRepository.DeleteUserAccount(userId);
            if (!result)
            {
                return NotFound();
            }
            return RedirectToAction("GetAllUsers");
        }
    }
}
