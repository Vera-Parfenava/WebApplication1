using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities.Identity;
using WebApplication1.ViewModel.Identity;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _SingInManager;

        public AccountController(UserManager<User> UserManager, SignInManager<User> SingInManager)
        {
            _SingInManager = SingInManager;
            _UserManager = UserManager;
        }
        #region Register
        public IActionResult Register() => View(new RegisterUserViewModel());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel Model)
        {
            if (!ModelState.IsValid) return View(Model);

            var user = new User
            {
                UserName = Model.UserName,
            };

            var register_result = await _UserManager.CreateAsync(user, Model.Password);
            if (register_result.Succeeded)
            {
                await _SingInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in register_result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(Model);
        }
        #endregion
        #region Login
        public IActionResult Login(string ReturnUrl) => View(new LoginViewModel { ReturnUrl = ReturnUrl });

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel Model)
        {
            if (!ModelState.IsValid) return View(Model);

            var login_result = await _SingInManager.PasswordSignInAsync(
                Model.UserName,
                Model.Password,
                Model.RememberMe,
                false);

            if (login_result.Succeeded)
            {
                return LocalRedirect(Model.ReturnUrl ?? "/");
            }
            ModelState.AddModelError("", "Ошибка ввода имени пользователя или пароля");
            return View(Model);
        }
        #endregion
        public async Task<IActionResult> Logout()
        {
            await _SingInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccesDenied() => View();
    }
}
