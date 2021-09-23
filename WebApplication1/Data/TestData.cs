using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebApplication1.Data
{
    public static class TestData
    {
        public static  IEnumerable<CollectionEntry> Collections { get; }
        public static List<GuestsView> GuestsViews { get; set; } = new List<GuestsView>
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

        //public static void RemoveGuest (GuestsView guest)
        //{
        //    GuestsViews.Remove(guest);
        //}

        //public static void EditGuest(GuestsView guest)
        //{
        //    guest.SurName = Console.ReadLine();
        //    guest.FirstName = Console.ReadLine();
        //    guest.Partronymic= Console.ReadLine();
        //    _ = int.TryParse(Console.ReadLine(), out int age);
        //    guest.Age = age;
        //    guest.Side = Console.ReadLine();
        //    guest.Relation = Console.ReadLine();
        //}
        //public static void SaveAction()
        //{
        //    GuestsViews.Remove(guest);
        //}
    }
}
