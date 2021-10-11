using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ViewModel
{
    public class GuestsViewModel:IValidatableObject
    {
        [HiddenInput(DisplayValue = false)] //hidden the value
        public int Id { get; set; }
        [Display(Name = "Имя")] //Повторяет имя поля( меняет его)
        [Required(ErrorMessage = "Имя не указано")] //Выводит ошибку
        [StringLength(200, MinimumLength = 2,ErrorMessage = "Длина от 2 до 200 символов")] //Длина строки
        [RegularExpression(@"([A-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Неверный формат")]

        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Фамилия не указана")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Длина от 2 до 200 символов")] //Длина строки
        [RegularExpression(@"([A-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Неверный формат")]
        public string SurName { get; set; }
        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Отчество не указано")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Длина от 2 до 200 символов")] //Длина строки
        [RegularExpression(@"([A-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Неверный формат")]
        public string Partronymic { get; set; }
        [Display(Name = "Возраст")]
        [Required(ErrorMessage = "Возраст не указан")]
        [Range(16,80, ErrorMessage = "Возраст должен быть от 18 до 80 лет")]
        public int Age { get; set; }
        [Display(Name = "Чей родственник?")]
        public string Side { get; set; }
        [Display(Name = "Отношения")]
        public string Relation { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext Context)
        {
            switch(Context.MemberName)
            {
                // default: return Enumerable.Empty<ValidationResult>();
                default: return new[] { ValidationResult.Success };
                case nameof(Age):
                    if (Age < 15 || Age > 90) 
                        return new[] { new ValidationResult("Странный возраст", new[] { nameof(Age) }) };
                    return new[] { ValidationResult.Success };
            }
        }
    }
}
