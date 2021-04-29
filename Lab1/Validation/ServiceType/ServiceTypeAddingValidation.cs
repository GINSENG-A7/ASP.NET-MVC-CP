using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1.Models.Validation
{
    public class ServiceTypeUniquenessValidation : ValidationAttribute
    {
        private ContextModel db = new ContextModel();
        public override bool IsValid(object value)
        {
            IEnumerable<ApartmentType> listOfServiceTypes = db.ApartmentTypes;
            ApartmentType validatableServiceTypes = value as ApartmentType;
            foreach (ApartmentType a in listOfServiceTypes)
            {
                if (validatableServiceTypes.Type == a.Type)
                {
                    return false;
                }
            }
            return true;
        }
    }
}