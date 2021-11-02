using AutoMapper;
using CreditCardValidator.WebApi.Domain.Models;
using CreditCardValidator.WebApi.Domain.Repositories;
using CreditCardValidator.WebApi.Infrastructure.Data;
using CreditCardValidator.WebApi.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditCardValidator.WebApi.Infrastructure.Repositories
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly CreditCardContext _creditCardContext;
        private readonly IMapper _mapper;
        public CreditCardRepository(IMapper mapper)
        {
            _creditCardContext = new CreditCardContext();
            _mapper = mapper;
        }

        public async Task<IEnumerable<CreditCard>> GetBlackListedCreditCards()
        {
            List<CreditCardModel> lstCreditCard = _creditCardContext.DeserializeInfoCreditCards();
            var result = _mapper.Map<IEnumerable<CreditCard>>(lstCreditCard);
            return result;
        }
    }
}
