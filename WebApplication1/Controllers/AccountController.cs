using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        }

        public IActionResult Register() => View(new RegisterUserViewModel());

        [HttpPost]
        public IActionResult Register(RegisterUserViewModel Model)
            {
            return RedirectToAction("Index", "Home");
             }
        public IActionResult Login() => View();
        public IActionResult Logout() => RedirectToAction("Index", "Home");
        public IActionResult AccesDenied() => View();

    }
}
