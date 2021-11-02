using CreditCardValidator.WebApi.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardValidator.WebApi.Application.Queries.creditCard.IsVisaOrMasterCard
{
    public class IsVisaOrMasterCard : IRequest<CreditCardValidation>
    {
        public IsVisaOrMasterCard(string cardNumber, string expirationDate)
        {
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
        }

        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
    }
}
