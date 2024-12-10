using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MODEL.Entities;
using MVC.Models.AccountVM;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        readonly RoleManager<IdentityRole<int>> _roleManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel appUser)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = appUser.UserName,
                    Email = appUser.Email,
                    Address = appUser.Address
                };

                //Veritabanı kayıt işlemi
                var result = await _userManager.CreateAsync(user, appUser.ConfirmPassword);

                if (result.Succeeded) 
                {
                    #region RolKontrolIslemleri

                    //IdentityRole<int> role = new IdentityRole<int>();
                    //role.Name = "Admin";

                    //IdentityResult  roleResult = await _roleManager.CreateAsync(role);

                    //await _userManager.AddToRoleAsync(user, "Admin");

                    IdentityRole<int> appRole = await _roleManager.FindByNameAsync("Member");
                    if (appRole == null) await _roleManager.CreateAsync(new() { Name = "Member" });
                    await _userManager.AddToRoleAsync(user, "Member");
                    
                    #endregion


                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return View(appUser);
                }
            }
            else
            {
                return View(appUser);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel appUser)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(appUser.UserName);

                if (user != null) 
                {
                    var result = await _signInManager.PasswordSignInAsync(user, appUser.Password, appUser.RememberMe, false);

                    if (result.Succeeded) 
                    {
                        IList<string> roles = await _userManager.GetRolesAsync(user);


                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Category", new { Area = "Dashboard" });
                        }
                       
                        return RedirectToAction("Index","Home");
                    }
                }
            }
            return View(appUser);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                ModelState.AddModelError(string.Empty, "Geçersiz şifre sıfırlama talebi.");
            }

            return View(new ResetPasswordViewModel { Token = token, Email = email });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password); //Sunucu gelen Token'ı doğrular.
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        //Başarılı şifre sıfırlama işlemi
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ViewBag.Message = "Hesap bulunamadı!";
                    return View();
                }

                // Şifre sıfırlamak için token
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callBackUrl = Url.Action(nameof(ResetPassword), "Account", new { token, email = model.Email }, Request.Scheme);

                ViewBag.ResetLink = callBackUrl;

                return View();
            }
            return View(model);
        }
    }
}
