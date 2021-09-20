using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<GuestsView> _GuestsViews = new List<GuestsView>
        {
            new GuestsView
            {
                Id = 1,
                SurName = "Парфенова",
                FirstName = "Светлана",
                Partronymic = "Алексеевна",
                Age = 48,
                Side = "невесты",
                Relation = "мама"
            },
            new GuestsView
            {
                Id = 2,
                SurName = "Парфенов",
                FirstName = "Сергей",
                Partronymic = "Петрович",
                Age = 52,
                Side = "невесты",
                Relation = "папа"
            },
            new GuestsView
            {
                Id = 3,
                SurName = "Парфенов",
                FirstName = "Дмитрий",
                Partronymic = "Сергеевич",
                Age = 21,
                Side = "невесты",
                Relation = "брат"
            },
            new GuestsView
            {
                Id = 4,
                SurName = "Парфенова",
                FirstName = "Анастасия",
                Partronymic = "Сергееевна",
                Age = 17,
                Side = "невесты",
                Relation = "сестра"
            }
        };

        public IActionResult Details(int? id) //https://localhost:44378/Home/Details
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.Id = id;
            return View(_GuestsViews);
        }
        public IActionResult Index() //https://localhost:44378/Home/Index
        {
            
            return View();
        }
        public IActionResult Guests() //https://localhost:44378/Home/Guests
        {

            return View(_GuestsViews);
        }
    }
}
