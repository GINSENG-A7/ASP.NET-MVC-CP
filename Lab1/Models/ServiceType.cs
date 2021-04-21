using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    public class ServiceType
    {
        public int Id { get; set; }
        [Display(Name = "Тип услуги")]
        public string Type { get; set; }
        public ICollection<AditionServices> AditionServices { get; set; }
        public ServiceType()
        {
            AditionServices = new List<AditionServices>();
        }
    }
}