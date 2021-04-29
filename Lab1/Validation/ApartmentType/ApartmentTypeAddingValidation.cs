using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1.Models.Validation
{
    public class ApartmentTypeUniquenessValidation : ValidationAttribute
    {
        private ContextModel db = new ContextModel();
        public override bool IsValid(object value)
        {
            IEnumerable<ApartmentType> listOfClients = db.ApartmentTypes;
            ApartmentType validatableApartmentType = value as ApartmentType;
            foreach (ApartmentType a in listOfClients)
            {
                if(validatableApartmentType.Type == a.Type)
                {
                    return false;
                }
            }
            return true;
        }
    }
}