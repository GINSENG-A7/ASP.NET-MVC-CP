using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Models
{
    public class Booking
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Колличество взрослых")]
        public int ValueOfGuests { get; set; }
        [Display(Name = "Колличество детей")]
        public int ValueOfKids { get; set; }
        [Display(Name = "Дата заезда")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Settling { get; set; }
        [Display(Name = "Дата выезда")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Eviction { get; set; }
        public int? ClientId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Client Client { get; set; }
        public int? ApartmentsId { get; set; }
        public Apartments Apartments { get; set; }
    }
}