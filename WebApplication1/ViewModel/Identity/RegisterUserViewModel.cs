﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModel.Identity
{
    public class RegisterUserViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
