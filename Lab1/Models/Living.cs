using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class Living
    {
        public int Id { get; set; }
        [Display(Name = "Колличество взрослых")]
        public int ValueOfGuests { get; set; }
        [Display(Name = "Колличество детей")]
        public int ValueOfKids { get; set; }
        [Display(Name = "Дата заезда")]
        [DataType(DataType.Date)]
        public DateTime Settling { get; set; }
        [Display(Name = "Дата выезда")]
        [DataType(DataType.Date)]
        public DateTime Eviction { get; set; }
        [Display(Name = "Числовое обозначение апартаментов")]
        public int NumberOfApartments { get; set; }
        public Client Client { get; set; }
        public Apartments Apartments { get; set;}
        public ICollection<AditionServices> AditionServices { get; set; }
        public Living()
        {
            AditionServices = new List<AditionServices>();
        }
    }
}