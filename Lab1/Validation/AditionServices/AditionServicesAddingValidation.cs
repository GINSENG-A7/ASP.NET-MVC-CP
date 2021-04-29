using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1.Models.Validation
{
    //Возможно тут всё не работает и надо явно указывать ссылку на проживание
    public class AditionServicesDateIsLessThenSettlingValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            AditionServices validatableAditionServices = value as AditionServices;
            if (validatableAditionServices.DateOfService < validatableAditionServices.Living.Settling)
            {
                return false;
            }
            return true;
        }
    }
    public class AditionServicesDateIsBiggerThenSettlingValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            AditionServices validatableAditionServices = value as AditionServices;
            if (validatableAditionServices.DateOfService > validatableAditionServices.Living.Eviction)
            {
                return false;
            }
            return true;
        }
    }
    public class AditionServicesPriceLessThenZeroValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            AditionServices validatableAditionServices = value as AditionServices;
            if (validatableAditionServices.Price < 0)
            {
                return false;
            }
            return true;
        }
    }
}