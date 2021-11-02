using CreditCardValidator.WebApi.Domain.Models;
using MediatR;
using System;

namespace CreditCardValidator.WebApi.Application.Queries.creditCard.IsValidCreditCard
{
    public class IsValidCreditCard : IRequest<CreditCardValidation>
    {
        public IsValidCreditCard(string cardNumber, string expirationDate)
        {
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
        }

        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }

    }
}
