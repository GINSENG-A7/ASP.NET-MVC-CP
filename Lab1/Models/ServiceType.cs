using Lab1.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Models
{
    //[ServiceTypeUniquenessValidation(ErrorMessage = "Такой тип дополнительных услуг уже существует")]
    public class ServiceType
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Display(Name = "Тип услуги")]
        public string Type { get; set; }
        public ICollection<AditionServices> AditionServices { get; set; }
        public ServiceType()
        {
            AditionServices = new List<AditionServices>();
        }
    }
}