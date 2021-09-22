using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GuestsController : Controller
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

        public IActionResult Index() => View(_GuestsViews);
    }
}
