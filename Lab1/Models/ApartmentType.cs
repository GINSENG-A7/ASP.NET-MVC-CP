using Lab1.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Models
{
    //[ApartmentTypeUniquenessValidation(ErrorMessage = "Такой тип апартаментов уже существует")]
    public class ApartmentType
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Display(Name = "Тип")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Display(Name = "Вместимость номера")]
        public int Capacity { get; set; }
        public ICollection<Apartments> Apartments { get; set; }
        public ApartmentType()
        {
            Apartments = new List<Apartments>();
        }
    }
}