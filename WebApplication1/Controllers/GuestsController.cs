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
        public IActionResult Details(int id)
        {
            var guest = Data.TestData.GuestsViews.FirstOrDefault(e => e.Id == id);
            if (guest is null)
                {
                return NotFound();
                }
            return View(guest);
        }
    }
}

