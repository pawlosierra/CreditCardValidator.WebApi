using AutoMapper;
using CreditCardValidator.WebApi.Domain.Models;
using CreditCardValidator.WebApi.Models;

namespace CreditCardValidator.WebApi.Mappers
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<FlightRequest, Flight>();
            CreateMap<Flight, FlightRequest>();
        }
    }
}
