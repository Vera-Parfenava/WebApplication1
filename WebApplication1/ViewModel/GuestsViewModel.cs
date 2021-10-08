using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ViewModel
{
    public class GuestsViewModel
    {
        [HiddenInput(DisplayValue = false)] //hidden the value
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        public string SurName { get; set; }
        [Display(Name = "Отчество")]
        public string Partronymic { get; set; }
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        [Display(Name = "Чей родственник?")]
        public string Side { get; set; }
        [Display(Name = "Отношения")]
        public string Relation { get; set; }
    }
}
