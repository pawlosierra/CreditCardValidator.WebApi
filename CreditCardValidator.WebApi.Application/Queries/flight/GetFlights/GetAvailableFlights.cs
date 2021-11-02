using CreditCardValidator.WebApi.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardValidator.WebApi.Application.Queries.flight.GetFlights
{
    public class GetAvailableFlights : IRequest<IEnumerable<Flight>>
    {
        public GetAvailableFlights(string timeOfTheDeparture)
        {
            Departure= DateTime.Parse(timeOfTheDeparture);
         //   Departure = DateTime.ParseExact(timeOfTheDeparture, "hh:mm tt", null, System.Globalization.DateTimeStyles.None);
        }

        public DateTime Departure { get; set; }
    }
}
