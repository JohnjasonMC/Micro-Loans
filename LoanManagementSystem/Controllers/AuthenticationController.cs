using LoanManagementSystem.Models;
using LoanManagementSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace LoanManagementSystem.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configs;

        public AuthenticationController(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                RoleManager<IdentityRole> roleManager, IConfiguration configs)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            _httpClient = new HttpClient();
            _configs = configs;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginUserViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginUser.UserName, loginUser.Password, loginUser.RememberMe, false);

                if (result.Succeeded)
                {
                    var token = await SignInUserAsync(loginUser);

                    if (!string.IsNullOrEmpty(token))
                    {
                        HttpContext.Session.SetString("JWToken", token);
                        return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError(string.Empty, "Invalid login credentials");
                }
            }

            return View(loginUser);
        }

        public async Task<string> SignInUserAsync(LoginUserViewModel loginUserViewModel)
        {
            var newTodoAsString = JsonConvert.SerializeObject(loginUserViewModel);
            var requestBody = new StringContent(newTodoAsString, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("ApiKey", _configs.GetValue<string>("ApiKey"));
            var response = await _httpClient.PostAsync("https://localhost:7259/api/Account/login", requestBody);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var token = JObject.Parse(content)["token"].ToString();

                return token;
            }

            return null;
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
                    Address = registerUser.Address,
                    PhoneNumber = registerUser.PhoneNumber,
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
            ModelState.Clear();
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
 