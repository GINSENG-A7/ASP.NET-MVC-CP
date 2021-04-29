﻿using Lab1.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1.Models
{
    [ApartmentsPriceLessThenZeroValidation(ErrorMessage = "Цена апартаментов должна быть больше нуля")]
    [ApartmentsNumberLessThenZeroValidation(ErrorMessage = "Номер апартаментов должен быть больше нуля")]
    [ApartmentsNumberUniquenessValidation(ErrorMessage = "Апартаменты с таким номером уже сущевсвуют")]
    public class Apartments
    {
        public int Id { get; set; }
        [Display(Name = "Числовое обозначение")]
        public int Number { get; set; }
        [Display(Name = "Цена за сутки")]
        public int Price { get; set; }
        public int? ApartmentTypeId { get; set; }
        public ApartmentType ApartmentType { get; set; }
        public ICollection<Living> Livings  { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Photos> Photos { get; set; }
        public Apartments()
        {
            Bookings = new List<Booking>();
            Livings = new List<Living>();
            Photos = new List<Photos>();
        }
    }
}