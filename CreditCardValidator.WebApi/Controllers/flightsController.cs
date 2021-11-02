using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CreditCardValidator.WebApi.Application.Queries.flight.GetFlights;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardValidator.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class flightsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public flightsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("flightSearch")]
        public async Task<IActionResult> GetFlightSearch([FromQuery(Name = "timeOfTheDeparture")]
                                                            [Required(ErrorMessage ="The field timeOfTheDepa/rture is required.")]
                                                           /* [RegularExpression(@"^(1[0-2]|0?[1-9]):([0-5]?[0-9])(●?[AP]M)?$", ErrorMessage ="Invalid date format. Requested format is HH:MM AM/PM")] */string timeOfTheDeparture)
        {
            try
            {
                var result = await _mediator.Send(new GetAvailableFlights(timeOfTheDeparture));
                // var t=new DateTime()
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }

        }
    }
}
