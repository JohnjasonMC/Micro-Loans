using LoanManagementSystem.Models;
using LoanManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationController(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await this._userManager.Users.FirstOrDefaultAsync(u => u.Email == loginUser.Username);

                if (user != null)
                {
                    var result = await this._signInManager.PasswordSignInAsync(loginUser.Username,
                    loginUser.Password,
                    loginUser.RememberMe,
                    false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid login credentials");
            }

            return View(loginUser);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            List<object> genderList = new List<object> { new { Id = 'M', Name = "Male" }, new { Id = 'F', Name = "Female" }, };

            ViewData["GenderList"] = new SelectList(genderList, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel registerUser)
        {
            if (ModelState.IsValid)
            {
                var userModel = new ApplicationUser
                {
                    UserName = registerUser.Email,
                    Email = registerUser.Email,
                    FullName = registerUser.FullName,
                    DateOfBirth = registerUser.DateOfBirth,
                    Gender = registerUser.Gender,
                };

                var result = await this._userManager.CreateAsync(userModel, registerUser.Password);

                if (result.Succeeded)
                {
                    bool roleExist = await this._roleManager.RoleExistsAsync(UserRole.Registered);

                    if (!roleExist)
                    {
                        await this._roleManager.CreateAsync(new IdentityRole(UserRole.Registered));
                    }

                    var roleResult = await this._userManager.AddToRoleAsync(userModel, UserRole.Registered);

                    if (!roleResult.Succeeded)
                    {
                        ModelState.AddModelError(String.Empty, "User Role cannot be assigned.");
                    }

                    await _signInManager.SignInAsync(userModel, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }
            }
            return View(registerUser);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await this._signInManager.SignOutAsync();
            return RedirectToAction("Login", "Authentication");
        }

        [HttpGet]
        public async Task<IActionResult> EditPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPassword(UpdatePasswordViewModel userPassword)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            ApplicationUser user = await this._userManager.GetUserAsync(this._signInManager.Context.User);

            if (user == null)
            {
                return RedirectToAction("Login", "Authentication");
            }

            var changePasswordResult = await this._userManager.ChangePasswordAsync(user, userPassword.CurrentPassword, userPassword.NewPassword);

            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View();
            }

            await this._signInManager.RefreshSignInAsync(user);

            return RedirectToAction("Profile", "User");
        }
    }
}
