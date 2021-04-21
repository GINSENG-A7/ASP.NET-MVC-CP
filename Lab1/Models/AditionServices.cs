using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class AditionServices
    {
        public int Id { get; set; }
        [Display(Name = "Цена за оказание услуги")]
        public int Price { get; set; }
        [Display(Name = "Дата оказания")]
        [DataType(DataType.Date)]
        public DateTime DateOfService { get; set; }
        //добавить дату оказания услуги
        public Living Living { get; set; }
        public ServiceType ServiceTypes { get; set; }
    }
}