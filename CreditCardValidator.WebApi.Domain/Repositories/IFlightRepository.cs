using CreditCardValidator.WebApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditCardValidator.WebApi.Domain.Repositories
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetAllFlights();
    }
}
