using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class Photos
    {
        public int Id { get; set; }
        [Display(Name = "Путь к фотографии")]
        public string Photo { get; set; }
        public int? ApartmentsId { get; set; }
        public Apartments Apartments { get; set; }
    }
}