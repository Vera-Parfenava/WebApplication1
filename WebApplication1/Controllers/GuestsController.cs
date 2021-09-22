using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class GuestsController : Controller
    {
        public IActionResult Index() => View(TestData.GuestsViews);
    }
}
