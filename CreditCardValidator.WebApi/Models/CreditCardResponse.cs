using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardValidator.WebApi.Models
{
    public class CreditCardResponse
    {
        
        public string CardNumber { get; set; }
        
        public string ExpirationDate { get; set; }
        public bool IsValid { get; set; }
    }
}
