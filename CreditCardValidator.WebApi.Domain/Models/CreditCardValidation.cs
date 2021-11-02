using System;

namespace CreditCardValidator.WebApi.Domain.Models
{
    public class CreditCardValidation
    {
        public string CardNumber { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public bool IsValid { get; set; }
   
    }
}
