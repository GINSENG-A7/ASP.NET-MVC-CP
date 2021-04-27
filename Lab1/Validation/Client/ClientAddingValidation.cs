using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1.Models.Validation
{
    public class ClientPassportUniquenessValidation : ValidationAttribute
    {
        private ContextModel db = new ContextModel();
        public override bool IsValid(object value)
        {
            IEnumerable<Client> listOfClients = db.Clients;
            Client validatableClient = value as Client;
            foreach (Client c in listOfClients)
            {
                if(validatableClient.PassportNumber == c.PassportNumber && validatableClient.PassportSeries == c.PassportSeries)
                {
                    return false;
                }
            }
            return true;
        }
    }
    public class ClientTelephoneUniquenessValidation : ValidationAttribute
    {
        private ContextModel db = new ContextModel();
        public override bool IsValid(object value)
        {
            IEnumerable<Client> listOfClients = db.Clients;
            Client validatableClient = value as Client;
            foreach (Client c in listOfClients)
            {
                if (validatableClient.Telephone == c.Telephone)
                {
                    return false;
                }
            }
            return true;
        }
    }
}