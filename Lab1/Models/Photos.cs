using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Models
{
    public class Photos
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Display(Name = "Путь к фотографии")]
        public string Photo { get; set; }
        public int? ApartmentsId { get; set; }
        public Apartments Apartments { get; set; }
    }
}