using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardValidator.WebApi.Infrastructure.Models
{
    public class CreditCardModel
    {
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
    }
}
