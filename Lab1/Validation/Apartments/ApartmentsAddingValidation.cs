using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1.Models.Validation
{
    public class ApartmentsPriceLessThenZeroValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Apartments validatableApartments = value as Apartments;
            if (validatableApartments.Price < 0)
            {
                return false;
            }
            return true;
        }
    }
    public class ApartmentsNumberLessThenZeroValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Apartments validatableApartments = value as Apartments;
            if (validatableApartments.Number <= 0)
            {
                return false;
            }
            return true;
        }
    }
    public class ApartmentsNumberUniquenessValidation : ValidationAttribute
    {
        private ContextModel db = new ContextModel();
        public override bool IsValid(object value)
        {
            IEnumerable<Apartments> listOfApartments = db.Apartments;
            Apartments validatableApartments = value as Apartments;
            foreach (Apartments a in listOfApartments)
            {
                if (validatableApartments.Number == a.Number)
                {
                    return false;
                }
            }
            return true;
        }
    }
}