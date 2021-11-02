using AutoMapper;
using CreditCardValidator.WebApi.Domain.Models;
using CreditCardValidator.WebApi.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardValidator.WebApi.Infrastructure.Mappers
{
    public class CreditCardProfile : Profile
    {
        public CreditCardProfile()
        {
            CreateMap<CreditCardModel, CreditCard>();

            CreateMap<FlightModel, Flight>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Flight))
                .ForMember(d => d.Departure, opt => opt.MapFrom(s => DateTime.Parse(s.Departure)));
        }
    }
}
