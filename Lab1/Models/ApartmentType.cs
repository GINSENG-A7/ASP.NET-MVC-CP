using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class ApartmentType
    {
        public int Id { get; set; }
        [Display(Name = "Тип")]
        public string Type { get; set; }
        public ICollection<Apartments> Apartments { get; set; }
        public ApartmentType()
        {
            Apartments = new List<Apartments>();
        }
    }
}