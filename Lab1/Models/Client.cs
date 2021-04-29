using Lab1.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Models
{
    [ClientPassportUniquenessValidation(ErrorMessage = "Клиент с такими серией и номером паспорта уже зарегистрирован")]
    [ClientTelephoneUniquenessValidation(ErrorMessage = "Клиент с таким телефоном уже зарегистрирован")]
    public class Client
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Display(Name = "Номер паспорта")]
        public string PassportNumber { get; set; }
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Display(Name = "Серия паспорта")]
        public string PassportSeries { get; set; }
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Birgthday { get; set; }
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Display(Name = "Номер телефона")]
        public string Telephone { get; set; }
        public ICollection<Living> Livings { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public Client()
        {
            Livings = new List<Living>();
            Bookings = new List<Booking>();
        }
    }
}