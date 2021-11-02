using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardValidator.WebApi.Domain.Models
{
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
    }
}
