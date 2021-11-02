using CreditCardValidator.WebApi.Domain.Models;
using CreditCardValidator.WebApi.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CreditCardValidator.WebApi.Application.Queries.flight.GetFlights
{
    public class GetAvailableFlightsHandler : IRequestHandler<GetAvailableFlights, IEnumerable<Flight>>
    {
        private readonly IFlightRepository _flightRepository;

        public GetAvailableFlightsHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<IEnumerable<Flight>> Handle(GetAvailableFlights request, CancellationToken cancellationToken)
        {
            IEnumerable<Flight> flihts = await _flightRepository.GetAllFlights();
            //var lstAvailableFlights = AvailableFlights(lstFlights, request.Departure);
           
            
            var availableFlights = flihts.Where(x => x.Departure > request.Departure && x.Departure.Subtract(request.Departure).TotalHours <= 5);
            return availableFlights;
        }

        public IEnumerable<Flight> AvailableFlights(IEnumerable<Flight> flights, DateTime departureTime)
        {
            return flights.Where(x => x.Departure > departureTime && x.Departure.AddHours(5) < departureTime);
            #region
            //try
            //{
            //    DateTime dateTime = DateTime.Parse(departure);
            //    DateTime totalDepart = dateTime.AddHours(5);
            //    List<Flight> lstFlightsAvailable = new List<Flight>();
            //    foreach (var fligth in flights)
            //    {
            //        if (DateTime.Parse(fligth.departure) <= totalDepart &&
            //            DateTime.Parse(fligth.departure) >= dateTime)
            //        {
            //            lstFlightsAvailable.Add(fligth);
            //        }
            //    }
            //    return lstFlightsAvailable;
            //}
            //catch (Exception ex)
            //{
            //    throw new FormatException("Invalid format", ex);
            //}
            #endregion


        }
    }
}
