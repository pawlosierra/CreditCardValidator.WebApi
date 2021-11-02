using AutoMapper;
using CreditCardValidator.WebApi.Application.Queries.creditCard.IsValidCreditCard;
using CreditCardValidator.WebApi.Application.Queries.flight.GetFlights;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;


namespace CreditCardValidator.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreditCardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("validate")]
        public async Task<IActionResult> ValidateCreditCard([FromQuery(Name = "creditCardNumber")][Required] string numberCreditCard, 
                                                       [FromQuery(Name = "expirationDate")][Required] string dateExpiration)
        {
            try
            {
                var result = await _mediator.Send(new IsValidCreditCard(numberCreditCard, dateExpiration));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
