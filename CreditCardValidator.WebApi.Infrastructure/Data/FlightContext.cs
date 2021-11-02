using CreditCardValidator.WebApi.Infrastructure.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CreditCardValidator.WebApi.Infrastructure.Data
{
    public class FlightContext
    {
        private readonly string _path = @"C:\Users\JuanPawloSierra\source\repos\Projects\CreditCardValidator.WebApi\CreditCardValidator.WebApi.Infrastructure\Data\Flights\json\Flight.json";
        public List<FlightModel> DeserializeInfoCreditCards()
        {
            var jsonFile = File.ReadAllText(_path);
            List<FlightModel> lstFlights = JsonConvert.DeserializeObject<List<FlightModel>>(jsonFile);
            return lstFlights;
        }
    }
}
