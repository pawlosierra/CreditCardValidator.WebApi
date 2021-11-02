using CreditCardValidator.WebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.WebApi.Domain.Repositories
{
    public interface ICreditCardRepository
    {
        Task<IEnumerable<CreditCard>> GetBlackListedCreditCards();
    }
}
