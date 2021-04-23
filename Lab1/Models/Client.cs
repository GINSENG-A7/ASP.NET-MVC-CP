using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Display(Name = "Номер паспорта")]
        public string PassportNumber { get; set; }
        [Display(Name = "Серия паспорта")]
        public string PassportSeries { get; set; }
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime Birgthday { get; set; }
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