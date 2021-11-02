using AutoMapper;
using CreditCardValidator.WebApi.Domain.Models;
using CreditCardValidator.WebApi.Domain.Repositories;
using CreditCardValidator.WebApi.Infrastructure.Data;
using CreditCardValidator.WebApi.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditCardValidator.WebApi.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly FlightContext _flightContext;
        private readonly IMapper _mapper;

        public FlightRepository(IMapper mapper)
        {
            _flightContext = new FlightContext();
            _mapper = mapper;
        }

        public async Task<IEnumerable<Flight>> GetAllFlights()
        {
            List<FlightModel> lstFlights = _flightContext.DeserializeInfoCreditCards();
            var result = _mapper.Map<IEnumerable<Flight>>(lstFlights);
            return result;
        }
    }
}
