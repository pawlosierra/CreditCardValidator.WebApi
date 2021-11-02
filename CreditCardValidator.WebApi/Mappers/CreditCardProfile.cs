using AutoMapper;
using CreditCardValidator.WebApi.Domain.Models;
using CreditCardValidator.WebApi.Models;

namespace CreditCardValidator.WebApi.Mappers
{
    public class CreditCardProfile : Profile
    {
        public CreditCardProfile()
        {
            CreateMap<CreditCardResponse, CreditCardValidation>();
            CreateMap<CreditCardValidation, CreditCardResponse>();
        }
    }
}
