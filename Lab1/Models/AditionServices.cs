using Lab1.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    [AditionServicesPriceLessThenZeroValidation(ErrorMessage = "Цена услуги не может быть меньше нуля")]
    [AditionServicesDateIsLessThenSettlingValidation(ErrorMessage = "Дата оказания услуги не может быть раньше даты начала проживания")]
    [AditionServicesDateIsBiggerThenSettlingValidation(ErrorMessage = "Дата оказания услуги не может быть позже даты оканчания проживания")]
    public class AditionServices
    {
        public int Id { get; set; }
        [Display(Name = "Цена за оказание услуги")]
        public int Price { get; set; }
        [Display(Name = "Дата оказания")]
        [DataType(DataType.Date)]
        public DateTime DateOfService { get; set; }
        //добавить дату оказания услуги
        public int? LivingsId { get; set; }
        public Living Living { get; set; }
        public int? ServiceTypesId { get; set; }
        public ServiceType ServiceTypes { get; set; }
    }
}