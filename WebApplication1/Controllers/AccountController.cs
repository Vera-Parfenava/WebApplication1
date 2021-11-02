using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register() => View();
        public IActionResult Login() => View();
        public IActionResult Logout() => RedirectToAction("Index", "Home");
        public IActionResult AccesDenied() => View();

    }
}
